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

        public void StartListening()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            _serverSocket = new TcpListener(localEndPoint);
            _serverSocket.Start();

            _clientSocket = _serverSocket.AcceptTcpClient();
            Console.WriteLine("Mam klienta");
            _reader = new StreamReader(_clientSocket.GetStream());
            _writer = new StreamWriter(_clientSocket.GetStream());
            while (true)
            { 
                string mes = _reader.ReadLine();
                Huffman huf = new Huffman(mes, "dictionary.txt");
                Console.WriteLine("Received: " + mes);
                Console.WriteLine("Decoded: " + huf.message);
                _writer.WriteLine("ACK");
                break;
            }
        }

        public void StopListening()
        {
            _writer.Close();
            _reader.Close();
            _clientSocket.Close();
            _serverSocket.Stop();
        }
    }
}
