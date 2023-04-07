using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DESX
{
    internal class MessageBlock
    {
        private Permutation permutation = new Permutation();
        private byte[] initPerm = {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17,  9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        };

        private byte[] block;
        private byte[] initPermBlock =  new byte[64];
        private byte[] leftBlock = new byte[32];
        private byte[] rightBlock = new byte[32];

        public MessageBlock(char[] _8ByteMessage)
        {
            int[] intRepresentationKey = new int[8];
            for (int i = 0; i < 8; i++)
            {
                intRepresentationKey[i] = _8ByteMessage[i];
            }

            byte[] tmpBlock = new byte[64];
            int nextRow = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 7 + nextRow; j >= nextRow; j--)
                {
                    tmpBlock[j] = (byte)(intRepresentationKey[i] % 2);
                    intRepresentationKey[i] = intRepresentationKey[i] / 2;
                }
                nextRow += 8;
            }
            this.block = tmpBlock;
            this.initPermBlock = permutation.permutation(initPerm, initPermBlock, 64);
            splitBlock();
        }
        public MessageBlock(byte[] messageBlock)
        {
            this.block = messageBlock;
            this.initPermBlock = permutation.permutation(initPerm, initPermBlock, 64);
            splitBlock();
        }

        public byte[] getLeftBlock()
        {
            return this.leftBlock;
        }
        public byte[] getRightBlock()
        {
            return this.rightBlock;
        }
        public byte[] getBlock()
        {
            return block;
        }


        private void splitBlock()
        {
            for (int i = 0; i < 32 ; i++)
            {
                this.leftBlock[i] = block[i];
                this.rightBlock[i] = block[i + 32];
            }
        }
        
    }
}
