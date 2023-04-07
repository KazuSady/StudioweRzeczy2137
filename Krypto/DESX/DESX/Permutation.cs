using System;
using System.CodeDom.Compiler;
using System.Data.SqlTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DESX
{
    internal class Permutation
    {
        public byte[] permutation(byte[] pc, byte [] block ,int len)
        {
            byte[] result = new byte[len];
            int index;
            for (int i = 0; i < len; i++)
            {
                index = pc[i] - 1;
                result[i] = block[index];
            }

            return result;
        }
        public byte[] charToByteArray(char[] message, int len)
        {
            int [] charRepresentationInInteger = new int[8];
            byte[] tmpArray = new byte[len];

            for (int i = 0; i <8; i++)
            {
                charRepresentationInInteger[i] = message[i];
            }
            int nextRow = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 7 + nextRow; j >= nextRow; j--)
                {
                    tmpArray[j] = (byte)(charRepresentationInInteger[i] % 2);
                    charRepresentationInInteger[i] = charRepresentationInInteger[i] / 2;
                }
                nextRow += 8;
            }
            return tmpArray;
        }

        public byte[] xor(byte[] arrayOne, byte[] arrayTwo)
        {
            byte[] result = new byte[arrayOne.Length];
            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = 1;
                }
            }
            return result;
        }

        public string showASCII(byte[] tab)
        {
            string result = "";
            string temp = "";
            int count = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                temp += tab[i].ToString();
                count++;
                if (count == 8)
                {
                    byte binary = Convert.ToByte(temp,2);
                    char character = Convert.ToChar(binary);
                    result += character;
                    temp = "";
                    count = 0;
                }
            }
            return result;
        }

        public string showByte(byte[] tab)
        {
            string temp = "";
            for (int i = 0; i < tab.Length; i++)
            {
                temp += tab[i].ToString();
            }
            return temp;
        }

    }
}
