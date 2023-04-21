using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmodem
{
    internal class Sender
    {
        public static byte SOH = 0x1;
        public static byte EOT = 0x4;
        public static byte ACK = 0x6;
        public static byte NAK = 0x15;
        public static byte CAN = 0x18;
        public static byte C = 0x43;
        public SerialPort port = new SerialPort();

        public Sender(String portName)
        {
            port.PortName = portName;
            port.ReadTimeout = 10000;
            port.Open();
        }
        //Metoda do obliczenia sumy kontrolnej - odbiornik porównuje ją z tą obliczoną przez nadajnik
        public int Checksum(byte[] data, int size)
        {
            int checksum = 0;
            for (int i = 0; i < size; i++)
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
            for (int i = 0; i < data.Length; i++)
            {
                crc = (int)(crc ^ data[i] << 8);
                for (byte j = 0; j < 8; j++)
                {
                    if ((crc & 0x8000) != 0) crc = (int)(crc << 1 ^ 0x1021);
                    else crc = (int)(crc << 1);
                }
            }
            result[0] = (byte)(crc >> 8);
            result[1] = (byte)(crc & 0x00FF);
            return result;
        }

        public void Read(String fileName, String xmodemType)
        {
            try
            {
                BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open));
                int blockNr = 1;
                int counter;
                bool sendAgain = true;
                byte[] buffer = new byte[128];
                byte[] header = new byte[3];
                while ((counter = reader.Read(buffer, 0, buffer.Length)) != 0)
                {
                    if (blockNr ==256) blockNr = 0;         
                    if (buffer.Length == 0) throw new Exception();
                    while(sendAgain)
                    {
                        byte[] data;
                        if (xmodemType == "1")
                        {
                            data = new byte[132];
                            data[0] = SOH;
                        }
                        else
                        {
                            data = new byte[133];
                            data[0] = C;
                        }
                        //Tworzymy nagłówek
                        data[1] = Convert.ToByte(blockNr);
                        data[2] = Convert.ToByte(255 - blockNr);
                        Buffer.BlockCopy(buffer, 0, data, 3, counter);
                        if (xmodemType == "1") data[131] = Convert.ToByte(Checksum(buffer, counter));
                        else
                        {
                            byte[] tmpZero = new byte[128];
                            Array.Copy(buffer, tmpZero, counter);
                            byte[] crc = Calcrc(tmpZero);
                            data[131] = crc[0];
                            data[132] = crc[1];
                        }
                        port.Write(data, 0, data.Length);
                        try
                        {
                            byte[] received = new byte[1];
                            port.Read(received, 0, 1);
                            if (received[0] == ACK) //Otrzymano ACK - odbiornik potwierdził odbiór danych
                            {
                                sendAgain = false;
                            }
                            else if (received[0] == NAK)    //Otrzymano NAK - odbiornik nie dostał danych/są błędne. Należy ponowić przesył
                            {
                                sendAgain = true;
                            }
                        }
                        catch(TimeoutException) { }
                    }
                    blockNr++;
                    sendAgain = true;
                }
                reader.Close();
                byte[] tmp = new byte[132];
                tmp[0] = EOT;
                while(true)
                {
                    byte[] received1 = new byte[1];
                    try
                    {
                        port.Read(received1, 0, 1);
                        if (received1[0] == ACK)    //Otrzymano ACK
                        {
                            break;
                        }
                    }
                    catch (TimeoutException) { }
                    port.Write(tmp, 0, 132);    //Wysłano EOT - poinformowano o końcu przesyłu danych
                }
            }
            catch(FileNotFoundException) { }
            catch(DirectoryNotFoundException) { }
        }
    }
}
