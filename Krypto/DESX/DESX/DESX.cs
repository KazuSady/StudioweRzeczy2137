using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

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
        public string encrypt(char[] message, string keyDes, string keyInternal, string keyExternal, bool decrypt)
        {
            keys.Add(permutation.charToByteArray(keyInternal.ToCharArray(), 64));
            keys.Add(permutation.charToByteArray(keyDes.ToCharArray(), 64));
            keys.Add(permutation.charToByteArray(keyExternal.ToCharArray(), 64));

            if (decrypt)
            {
                keys.Reverse();
            }

            string tmpResult = "";
            string messagePadding = addPadding(message);

            divideBlocks(messagePadding);

            for (int i = 0; i < messageBlocks.Count; i++)
            {
                DES des = new DES();
                byte[] blockXOR1 = permutation.xor(messageBlocks.ElementAt(i), keys.ElementAt(0));
                byte[] blockDES = des.enryptBlock(blockXOR1, keys.ElementAt(1), decrypt);
                byte[] blockXOR2 = permutation.xor(blockDES, keys.ElementAt(2));
                result += permutation.showASCII(blockXOR2);
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
        private string addPadding(char[] message)
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