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
    internal class Sender
    {
        private TcpClient _sender;
        private StreamWriter _writer;
        private StreamReader _reader;
        private Int32 _port = 13000;

        public void StartConnection(string ip)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, _port);

            _sender = new TcpClient();
            _sender.Connect(remoteEP);
            Console.WriteLine("Mam odbiornik");
            //_reader = new StreamReader(_sender.GetStream());
            _writer = new StreamWriter(_sender.GetStream());
        }

        public void StopConnection() 
        {
            //_reader.Close();
            _writer.Close();
            _sender.Close();
        }

        public void Send(string mes)
        {
            Huffman huf = new Huffman(mes);
            StreamWriter dictWrite = new StreamWriter("dictionary.txt");
            dictWrite.Write(huf.GetDictionaryString());
            dictWrite.Close();
            _writer.WriteLine(huf.GetEncode());
            _writer.WriteLine(huf.GetDictionaryString());
            //string response = _reader.ReadToEnd();
        }
            
            
        
    }
}
