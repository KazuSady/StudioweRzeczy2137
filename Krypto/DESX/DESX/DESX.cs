using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace DESX
{
    internal class DESX
    {
        private Permutation permutation = new Permutation();
        private string result;
        List<byte[]> messageBlocks = new List<byte[]>();
        List<byte[]> keys = new List<byte[]>();


        // Jezeli decrypt = true, odwracamy kolność użycia kluczy co pozwala na wykonanie całego proceszu szyfrowania tym samym kodem tylko od tyłu
        // Tutaj odwracamy klucze Internal i External wykorzystane kolejno przed i po zaszyfrowaniu wiadomosci DES'em, w DES'ie odwracamy wszystki 16 48-bitowych podkluczy 
        public string encrypt(char[] message, string keyInternal, string keyDes, string keyExternal, bool decrypt)
        {
            keys.Add(permutation.charToByteArray(keyInternal.ToCharArray(), 64));
            keys.Add(permutation.charToByteArray(keyDes.ToCharArray(), 64));
            keys.Add(permutation.charToByteArray(keyExternal.ToCharArray(), 64));

            if (decrypt)
            {
                keys.Reverse();
            }

            string tmpResult = "";

            char[] messagePadding; 
            if (!decrypt)
            {
                messagePadding = addPadding(message);
            }
            else
            {
                messagePadding = message;
            }

            divideBlocks(messagePadding);

            for (int i = 0; i < messageBlocks.Count; i++)
            {
                DES des = new DES();
                byte[] blockXOR1 = permutation.xor(messageBlocks.ElementAt(i), keys.ElementAt(0));
                byte[] blockDES = des.enryptBlock(blockXOR1, keys.ElementAt(1), decrypt);
                byte[] blockXOR2 = permutation.xor(blockDES, keys.ElementAt(2));
                result += permutation.showASCII(blockXOR2);
                int kekw = result.Length;
            }

            if (decrypt)
            {
                int toTrim = (int)result[result.Length - 1];
                int trim = message.Length - toTrim;
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

        private void divideBlocks(char [] message)
        {
            char[] tmpBlock = new char[8];
            byte[] block = new byte[64];
            int index = 0;
            for (int i = 0; i < (message.Length); i++)
            {
                tmpBlock[index] = message[i];
                index++;
                if (index == 8)
                {
                    block = permutation.charToByteArray(tmpBlock, 64);
                    index = 0;
                    messageBlocks.Add(block);
                }
            }
        }
        private char [] addPadding(char[] message)
        {

            int trim = 8 - (message.Length % 8);
            char[] tmpMessage = new char[message.Length + trim];
            if (trim == 8)
            {
                trim = 0;
            }
            for (int i = 0; i < message.Length + trim; i++)
            {
                if (i < message.Length)
                {
                    tmpMessage[i] = message[i];
                }
                else
                {
                    tmpMessage[i] = Convert.ToChar(trim);
                }
            }
            return tmpMessage;
        }

        public List<String> generateKeys()
        {
            List<string> keysRandom = new List<string>();
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                StringBuilder keyBuilder = new StringBuilder();
                for (int j = 0; j < 8; j++)
                {  
                    int randomNumber = random.Next(0, 10);
                    keyBuilder.Append(randomNumber.ToString());
                }
                string key = keyBuilder.ToString();
                keysRandom.Add(key);
            }

            return keysRandom;
        }
    }
}