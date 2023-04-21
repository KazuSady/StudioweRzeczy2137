using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmodem
{
    internal class Receiver
    {
        public static byte SOH = 0x1;
        public static byte EOT = 0x4;
        public static byte[] ACK = { 0x6 };
        public static byte[] NAK = { 0x15 };
        public static byte CAN = 0x18;
        public static byte[] C = { 0x43 };
        public SerialPort port = new SerialPort();
        String _fileName = "received.txt";
        String _pathToSave;

        public Receiver(String portName)
        {
            port.PortName = portName;
            port.ReadTimeout = 10000;
            port.Open();
            _pathToSave = Path.Combine(Environment.CurrentDirectory, _fileName);
            if(File.Exists(_pathToSave))
            {
                File.Delete(_pathToSave);
            }
        }

        //Metoda do obliczenia sumy kontrolnej - odbiornik porównuje ją z tą obliczoną przez nadajnik
        public int Checksum(byte[] data)
        {
            int checksum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                checksum += data[i];
            }
            checksum %= 256;
            return checksum;
        }

        //Metoda do obliczenia sumy kontrolnej - odbiornik porównuje ją z tą obliczoną przez nadajnik
        public byte[] Calcrc(byte[] data)
        {
            int crc = 0;
            byte[] result = new byte[2];
            for(int i = 0;i < data.Length;i++)
            {
                crc = (int)(crc ^ data[i] << 8);
                for(byte j = 0; j < 8; j++)
                {
                    if ((crc & 0x8000) != 0) crc = (int)(crc << 1 ^ 0x1021);
                    else crc = (int)(crc << 1);
                }
            }
            result[0] = (byte)(crc >> 8);
            result[1] = (byte)(crc & 0x00FF);
            return result;
        }

        public void WriteToFile(byte[] message, String fileName)
        {
            int textSize = message.Length;
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == 0)
                {
                    textSize = i;
                    break;
                }
            }
            byte[] newMessage = new byte[textSize];
            Array.Copy(message, newMessage, textSize);
            String str = Encoding.GetEncoding("UTF-8").GetString(newMessage);
            if(!File.Exists(_pathToSave))
            {
                File.Create(_pathToSave).Close();
                File.AppendAllText(_pathToSave, str);
            }
            else if(File.Exists(_pathToSave)) File.AppendAllText(str, _pathToSave);
        }

        public async void Listening(String xmodemType)
        {
            byte[] message = new byte[128];
            bool end = false;
            bool toSave = false;
            int blockNr = 1;


            for(int i = 0; i < 6; i++)
            {
                //Wysyłamy informację o gotowości do odbierania danych
                if (xmodemType == "1")
                {
                    port.Write(NAK, 0, 1);  //Wysłano NAK

                }
                else
                {
                    port.Write(C, 0, 1);    //Wysłano C
                }
                System.Threading.Thread.Sleep(1000);
                if(port.BytesToRead > 0)    //Otrzymano C lub SOH
                {
                    break;
                }    
            }

            while (!end)
            {
                if (blockNr == 256) blockNr = 0;
                if((port.BytesToRead > 132 && xmodemType == "1") || port.BytesToRead >= 133 && xmodemType == "2") 
                {
                    try
                    {
                        byte[] isEOT = new byte[1];
                        port.Read(isEOT, 0, 1);
                        //Sprawdzenie, czy przesłane zostały wszystkie bloki. Znak EOT oznacza koniec przesyłania ostatniego bajtu.
                        if (isEOT[0] == EOT)
                        {
                            end = true;
                            port.Write(ACK, 0, 1);  //Wysłano ACK
                        }
                        //Sprawdzenie, czy otrzymaliśmy początek nagłówka - SOH lub C i rozpoczęcie nasłuchiwania
                        else if (isEOT[0] == SOH || isEOT[0] == C[0])   //Otrzymano SOH lub C
                        {
                            bool listening = true;
                            while(listening)
                            {
                                try
                                {
                                    byte[] header = new byte[2];
                                    port.Read(header, 0, 2);
                                    if (blockNr == header[0] && header[0] + header[1] == 255)   //Sprawdzenie, czy nagłówek jest prawidłowy
                                    {
                                        toSave = true;
                                    }
                                    listening = false;
                                }
                                catch (TimeoutException) { }
                            }
                            listening = true;
                            while (listening)
                            {
                                try
                                {
                                    port.Read(message, 0, 128);
                                    bool isControlled = true;
                                    byte[] control;
                                    if (xmodemType == "1")
                                    {
                                        control = new byte[1];
                                        port.Read(control, 0, 1);
                                        if (Checksum(message) != control[0])    //Sprawdzanie poprawności checksumy
                                        {
                                            isControlled = false;
                                        }
                                    }
                                    else
                                    {
                                        control = new byte[2];
                                        byte[] controlCheck = Calcrc(message);
                                        port.Read(control, 0, 2);
                                        if (control[0] != controlCheck[0] || control[1] != controlCheck[1]) //Sprawdzanie poprawności CRC
                                        {
                                            isControlled = false;
                                        }
                                    }
                                    //Wysyłamy NAK, gdy suma kontrolna się nie zgadza
                                    if (isControlled == false || toSave == false) 
                                    {
                                        toSave = false;
                                        port.Write(NAK, 0, 1);  //Wysłano NAK
                                    }
                                    //Wysyłamy ACK, gotowi do przyjęcia kolejnego bloku danych
                                    if (toSave)
                                    {
                                        port.Write(ACK, 0, 1);  //Wysłano ACK
                                        WriteToFile(message, _fileName);
                                        blockNr += 1;
                                        toSave = false;
                                    }
                                    listening = false;
                                }
                                catch (TimeoutException) { }
                            }
                        }
                    }
                    catch (TimeoutException) { }
                }
            }
        }
    }
}
