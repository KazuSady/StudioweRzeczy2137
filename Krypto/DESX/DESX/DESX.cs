using PdfSharp.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DESX
{
    internal class DESX
    {
        private Permutation permutation = new Permutation();
        private string result;
        List<byte[]> messageBlocks = new List<byte[]>();

        public string encrypt(string message, string key, bool decrypt)
        {
            string tmpResult = "";
            string messagePadding = addPadding(message);
            divideBlocks(messagePadding);
            char[] desKey = key.ToCharArray();
            for(int i = 0; i < messageBlocks.Count; i++)
            {
                DES des = new DES();
                result += permutation.showASCII(des.enryptBlock(messageBlocks.ElementAt(i), permutation.charToByteArray(desKey,64), decrypt));
            }

            if (decrypt)
            {
                int trim = message.Length - (int)result[result.Length - 1];
                if (trim < 0)
                {
                    trim = message.Length;
                }
                for (int i = 0; i < trim; i++)
                {
                    tmpResult += result[i];
                }
                return tmpResult;
            }
            else
            {
                return result;
            }
        }

        private void divideBlocks(string message)
        {
            char[] tmpBlock = new char[8];
            byte[] block = new byte[64];
            int index = 0;
            for (int i = 0; i < (message.Length / 8) * 8; i++)
            {
                tmpBlock[index] = message.ToCharArray()[i];
                index++;
                if (index == 8)
                {
                    block = permutation.charToByteArray(tmpBlock, 64);
                    index = 0;
                    messageBlocks.Add(block);
                }
            }
        }
        private string addPadding(string message)
        {
            string tmpMessage = "";
            int trim = 8 - (message.Length % 8);
            if (trim == 8)
            {
                trim = 0;
            }
            for (int i = 0; i < message.Length + trim; i++)
            {
                if (i < message.Length)
                {
                    tmpMessage += message[i];
                }
                else
                {
                    tmpMessage += Convert.ToChar(trim);
                }
            }
            return tmpMessage;
        }
    }
}
