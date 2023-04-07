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
        private byte[] initPermutationLeft = {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8 };

        private byte[] initPermutationRight = {
            57, 49, 41, 33, 25, 17,  9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        };

        private byte[] block;
        private byte[] leftBlock = new byte[32];
        private byte[] rightBlock = new byte[32];

        public MessageBlock(byte[] _8ByteMessage)
        {
            this.block = _8ByteMessage;
            this.leftBlock = permutation.permutation(initPermutationLeft, block, 32);
            this.rightBlock = permutation.permutation(initPermutationRight, block, 32);
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
        
    }
}
