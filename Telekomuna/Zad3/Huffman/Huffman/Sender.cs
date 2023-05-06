﻿using System;
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

        public void StartConnection(string ip)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
            Console.WriteLine(remoteEP.ToString());
            _sender = new TcpClient(remoteEP);
            Console.WriteLine("Mam serwer");
            _reader = new StreamReader(_sender.GetStream());
            _writer = new StreamWriter(_sender.GetStream());
        }

        public void StopConnection() 
        {
            _reader.Close();
            _writer.Close();
            _sender.Close();
        }

        public string Send(string mes)
        {
            Huffman huf = new Huffman(mes);
            
            StreamWriter dictWrite = new StreamWriter("directory.txt");
            dictWrite.Write(huf.GetDictionaryString());
            dictWrite.Close();
            _writer.WriteLine(huf.GetEncode());
            string response = _reader.ReadToEnd();
            return response;
        }
            
            
        
    }
}
