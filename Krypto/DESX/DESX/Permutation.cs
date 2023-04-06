namespace DESX
{
    internal class Permutation
    {
        public byte[] permutation(byte[] pc, byte [] block ,int len)
        {
            byte[] result = new byte[len];

            for (int i=0; i < len; i++)
            {
                result[i] = block[pc[i] - 1];
            }

            return result;
        }

    }
}
