using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    internal class Receiver
    {
        private StreamReader _reader;
        private StreamWriter _writer;
        private TcpClient _clientSocket;
        private TcpListener _serverSocket;
        private Int32 _port = 13000;

        public void StartListening(string ip)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(ip), _port);
            _serverSocket = new TcpListener(localEndPoint);
            _serverSocket.Start();

            _clientSocket = _serverSocket.AcceptTcpClient();
            Console.WriteLine("Mam nadajnik");
            _reader = new StreamReader(_clientSocket.GetStream());
            //_writer = new StreamWriter(_clientSocket.GetStream());
            while (true)
            {
                string mes = _reader.ReadLine();
                StreamWriter mesWrite = new StreamWriter("encode.txt");
                mesWrite.Write(mes);
                mesWrite.Close();
                string dic = _reader.ReadToEnd();
                StreamWriter dictWrite = new StreamWriter("dictionary.txt");
                dictWrite.Write(dic);
                dictWrite.Close();
                Huffman huf = new Huffman(mes, "dictionary.txt");
                Console.WriteLine("Decoded: " + huf.message);
                StreamWriter decodedWrite = new StreamWriter("decoded.txt");
                decodedWrite.Write(huf.message);
                decodedWrite.Close();
                //_writer.WriteLine("ACK");
                break;
            }
        }

     

        public void StopListening()
        {
            //_writer.Close();
            _reader.Close();
            _clientSocket.Close();
            _serverSocket.Stop();
        }
    }
}
