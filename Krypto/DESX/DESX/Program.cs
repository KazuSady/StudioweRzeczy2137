//Autorzy:
//        Laura Nowogórska 242479
//        Szymon Wydmuch   242568 
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DESX
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UI());
            byte[] key = { 0, 0, 0, 1, 0, 0, 1, 1,
                0, 0, 1, 1, 0, 1, 0, 0, 
                0, 1, 0, 1, 0, 1, 1, 1, 
                0, 1, 1, 1, 1, 0, 0, 1,
                1, 0, 0, 1, 1, 0, 1, 1, 
                1, 0, 1, 1, 1, 1, 0, 0, 
                1, 1, 0, 1, 1, 1, 1, 1, 
                1, 1, 1, 1, 0, 0, 0, 1 };
            byte[] message = { 0, 0, 0, 0, 0, 0, 0, 1, 
                0, 0, 1, 0, 0, 0, 1, 1, 
                0, 1, 0, 0, 0, 1, 0, 1,
                0, 1, 1, 0, 0, 1, 1, 1, 
                1, 0, 0, 0, 1, 0, 0, 1, 
                1, 0, 1, 0, 1, 0, 1, 1, 
                1, 1, 0, 0, 1, 1, 0, 1, 
                1, 1, 1, 0, 1, 1, 1, 1 };

            // key = 64bitKey
            // message = dupachuj
            Permutation permutation = new Permutation();
            DES des = new DES();
            DES des2 = new DES();

            byte[] messageEncrypted = des.enryptBlock(message, key, false);
            byte[] messageDecrypted = des2.enryptBlock(messageEncrypted, key, true);

            Console.WriteLine(permutation.showByte(message));
            Console.WriteLine(permutation.showByte(messageEncrypted));
            Console.WriteLine(permutation.showByte(messageDecrypted));

            Console.WriteLine(permutation.showASCII(message));
            Console.WriteLine(permutation.showASCII(messageEncrypted));
            Console.WriteLine(permutation.showASCII(messageDecrypted));
        }
    }

}
