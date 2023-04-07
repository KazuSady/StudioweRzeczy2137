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
            char[] key = { '8', '6', '3', 'e', '8', '1', 'e', '9' };
            char[] message = { 'd', 'u', 'p', 'a', 'c', 'h', 'u', 'j'};
            // key = 863e81e9
            // message = dupachuj
            Permutation permutation = new Permutation();
            DES des = new DES();
            DES des2 = new DES();
            byte[] messageByte = permutation.charToByteArray(message, 64);
            byte[] messageEncrypted = des.enryptBlock(messageByte, key, false);
            byte[] messageDecrypted = des2.enryptBlock(messageEncrypted, key, true);

            Console.WriteLine(permutation.showByte(messageByte));
            Console.WriteLine(permutation.showByte(messageEncrypted));
            Console.WriteLine(permutation.showByte(messageDecrypted));

            Console.WriteLine(permutation.showASCII(messageByte));
            Console.WriteLine(permutation.showASCII(messageEncrypted));
            Console.WriteLine(permutation.showASCII(messageDecrypted));
        }
    }

}
