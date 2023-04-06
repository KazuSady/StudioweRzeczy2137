//Autorzy:
//        Laura Nowogórska 242479
//        Szymon Wydmuch   242568 
using System;
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

            Encoding encoding = Encoding.ASCII;
            DES dES = new DES();

            byte[] messageEncrypted = dES.enrypt(message, key);
            byte[] messageOriginal = dES.getMessageBlock().getBlock();
            byte[] messageDecrypted = dES.decrypt(messageEncrypted, key);

            Console.WriteLine(encoding.GetString(messageOriginal));
        }
    }
}
