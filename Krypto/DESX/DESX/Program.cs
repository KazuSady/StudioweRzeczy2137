//Autorzy:
//        Laura Nowogórska 242479
//        Szymon Wydmuch   242568 
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace DESX
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI());

            DESX desx = new DESX();
            DESX desx2 = new DESX();

            string message = "The key size is thereby increased to 56 + (2 × 64) = 184 bits.However, the effective key size (security) is only increased to 56+64−1−lb(M) = 119 − lb(M) = ~119 bits, where M is the number of chosen plaintext/ciphertext pairs the adversary can obtain, and lb denotes the binary logarithm. Moreover, key size drops to 88 bits given 232.5 known plaintext and using advanced slide attack.DES-X also increases the strength of DES against differential cryptanalysis and linear cryptanalysis, although the improvement is much smaller than in the case of brute force attacks. It is estimated that differential cryptanalysis would require 261 chosen plaintexts (vs. 247 for DES), while linear cryptanalysis would require 260 known plaintexts (vs. 243 for DES or 261 for DES with independent subkeys.[1]) Note that with 264 plaintexts (known or chosen being the same in this case), DES (or indeed any other block cipher with a 64 bit block size) is totally broken as the whole cipher's codebook becomes available.Although the differential and linear attacks, currently best attack on DES-X is a known-plaintext slide attack discovered by Biryukov-Wagner [2] which has complexity of 232.5 known plaintexts and 287.5 time of analysis. Moreover the attack is easily converted into a ciphertext-only attack with the same data complexity and 295 offline time complexity.";
            string keyInternal = "87654321";
            string key = "12345678";
            string keyExternal = "43218765";

            string messageEncrypted = desx.encrypt(message.ToCharArray(), keyInternal, key, keyExternal, false);
            string messageDecrypted = desx2.encrypt(messageEncrypted.ToCharArray(), keyInternal, key, keyExternal, true);

            Console.WriteLine(messageEncrypted);
            Console.WriteLine(messageDecrypted);

        }
    }

}
