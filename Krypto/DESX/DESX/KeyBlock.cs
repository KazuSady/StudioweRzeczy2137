using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DESX
{
    internal class KeyBlock
    {
        private Permutation permutation = new Permutation();
        private byte[] left = {
            57, 49, 41, 33, 25, 17,  9,
             1, 58, 50, 42, 34, 26, 18,
            10,  2, 59, 51, 43, 35, 27,
            19, 11,  3, 60, 52, 44, 36
        };
        private byte[] right = {
            63, 55, 47, 39, 31, 23, 15,
             7, 62, 54, 46, 38, 30, 22,
            14,  6, 61, 53, 45, 37, 29,
            21, 13,  5, 28, 20, 12,  4
        };
        private byte[] pc2 = {
            14, 17, 11, 24,  1,  5,  3,
            28, 15,  6, 21, 10, 23, 19,
            12,  4, 26,  8, 16,  7, 27,
            20, 13,  2, 41, 52, 31, 37,
            47, 55, 30, 40, 51, 45, 33,
            48, 44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32
        };
        private byte[] circularShift = {
            1, 1, 2, 2, 2, 2, 2, 2,
            1, 2, 2, 2, 2, 2, 2, 1, 0
        };

        private byte[] block;
        private byte[] leftBlock = new byte[28];
        private byte[] rightBlock = new byte[28];
        private byte[] subKey = new byte[48];
        private byte[] connectedBlock = new byte[56];


        public KeyBlock(byte[] _8ByteKey)
        {
            this.block = _8ByteKey;

            this.leftBlock = permutation.permutation(left, block, 28);
            this.rightBlock = permutation.permutation(right, block, 28);
        }

        public void generateSubKey(int round)
        { 
            shiftLeft(circularShift[round]);
            connect();
            permutationTwo();
        }
        public byte[] getSubKey()
        {
            return subKey;
        }

        private void shiftLeft(byte repeat)
        {
            for (int i = 0; i < repeat; i++)
            {
                byte tmpLeft = leftBlock[0];
                byte tmpRight = rightBlock[0];
                for (int j = 0; j < 27; j++)
                {
                    leftBlock[j] = leftBlock[j + 1];
                    rightBlock[j] = rightBlock[j + 1];
                }
                leftBlock[27] = tmpLeft;
                rightBlock[27] = tmpRight;
            }
        }

        private void connect()
        {
            for (int i = 0; i < 28; i++)
            {
                this.connectedBlock[i] = leftBlock[i];
                this.connectedBlock[28 + i] = rightBlock[i];
            }

        }
        private void permutationTwo()
        {
            this.subKey = permutation.permutation(pc2, connectedBlock, 48);

        }

    }
}
