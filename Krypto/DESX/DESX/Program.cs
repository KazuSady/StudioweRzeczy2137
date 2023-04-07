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
            char[] message = { 'd', 'u', 'p', 'a', 'c', 'h', 'u','j' };
            // key = 863e81e9
            // message = dupachuj

            DES dES = new DES();

            byte[] messageEncrypted = dES.enrypt(message, key);
            byte[] messageOriginal = dES.getMessageBlock().getBlock();

            Console.WriteLine(dES.showASCII(messageOriginal));

            Console.WriteLine(dES.showASCII(messageEncrypted));

            byte[] messageDecrypted = dES.decrypt(messageEncrypted, key);
            Console.WriteLine(dES.showASCII(messageDecrypted));


        }
    }

}
