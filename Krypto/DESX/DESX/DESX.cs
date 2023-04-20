using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace DESX
{
    internal class DESX
    {
        private Permutation permutation = new Permutation();
        private byte [] result;
        List<byte[]> messageBlocks = new List<byte[]>();
        List<byte[]> keys = new List<byte[]>();


        // Jezeli decrypt = true, odwracamy kolność użycia kluczy co pozwala na wykonanie całego proceszu szyfrowania tym samym kodem tylko od tyłu
        // Tutaj odwracamy klucze Internal i External wykorzystane kolejno przed i po zaszyfrowaniu wiadomosci DES'em, w DES'ie odwracamy wszystki 16 48-bitowych podkluczy 
        public byte[] encrypt(byte[] message, string keyInternal, string keyDes, string keyExternal, bool decrypt)
        {
            // Obliczenie długości wypełnienia do długości podzielnej przez 8 
            int paddedLength = ((message.Length + 7) / 8) * 8;
            int toFill = paddedLength - message.Length;
            byte[] paddedMessage = new byte[paddedLength];
            result = new byte[paddedLength];

            keys.Add(permutation.charToByteArray(keyInternal.ToCharArray(), 64));
            keys.Add(permutation.charToByteArray(keyDes.ToCharArray(), 64));
            keys.Add(permutation.charToByteArray(keyExternal.ToCharArray(), 64));

            Array.Copy(message, paddedMessage, message.Length);
            // Wypełnienie tablicy do długości podzielnej przez 8 liczbą która reprezentuje różnice między aktualną długością i najbliższą większą liczbą podzielną przez 8 
            // Dla przykładu
            // message.Length = 25
            // paddedMessage.Length = 32
            // toFill = 32 - 25 = 7
            // Indexy od 26 do 31 będą miał wartość 7 
            for (int i = message.Length; i < paddedMessage.Length; i++)
            {
                paddedMessage[i] = (byte)toFill;
            }       
            
            // Podzielenie całej wiadomości na 8 elementowe tablice
            splitToGroups(paddedMessage);
            
            // Odwrócenie całej operacji szyfrowania w przypadku deszyfrowania
            if (decrypt)
            {
                keys.Reverse();
            }

            for (int i = 0; i < messageBlocks.Count; i++)
            {
                DES des = new DES();
                // Zamiana 8 elementowej tablicy 8 bajtowych liczb na ich reprezentacje binarne
                byte[] block = _8ByteTabTo64BitsTab(messageBlocks.ElementAt(i));
                byte[] blockXOR1 = permutation.xor(block, keys.ElementAt(0));
                byte[] blockDES = des.enryptBlock(blockXOR1, keys.ElementAt(1), decrypt);
                byte[] blockXOR2 = permutation.xor(blockDES, keys.ElementAt(2));
                Array.Copy(_64BitTabTo8ByteTab(blockXOR2), 0, result, i * 8, 8);
            }

            // Obcięcie niepotrzebnego wypełnienia zastosowanego w szyfrowaniu
            if (decrypt)
            {
                int trim = (result[result.Length - 1]);
                return result.Take(result.Length - trim).ToArray();
            }

            return result;
        }

        private void splitToGroups(byte[] message)
        {
            for (int i = 0; i < message.Length; i += 8)
            {
                ulong block = 0;
                for (int j = 0; j < 8 && i + j < message.Length; j++)
                {
                    block |= (ulong)message[i + j] << (8 * j);
                }

                byte[] blockBytes = BitConverter.GetBytes(block);
                messageBlocks.Add(blockBytes);
            }
        }
        private byte[] _8ByteTabTo64BitsTab(byte[] tab)
        {
            byte[] result = new byte[64];

            for (int i = 0; i < tab.Length; i++)
            {
                string binary = Convert.ToString(tab[i], 2).PadLeft(8, '0');
                byte [] binaryTab = binary.Select(c => (byte)(c - '0')).ToArray();
                Array.Copy(binaryTab, 0, result, i*8, 8);
            }
            return result;
        }
        private byte[] _64BitTabTo8ByteTab(byte[] tab)
        { 
            byte[] result = new byte[8];

            for (int i = 0; i < 8; i++)
            {
                result[i] = tab.Skip(i * 8).Take(8).Aggregate((byte)0, (a, b) => (byte)((a << 1) + b));
            }
            return result;
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