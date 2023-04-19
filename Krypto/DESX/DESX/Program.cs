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
            /*
            DESX desx = new DESX();
            DESX desx2 = new DESX();

            byte[] message = Encoding.GetEncoding("ISO-8859-2").GetBytes("The key size is thereby increased to 56 + (2 × 64) = 184 bits.");
            string keyInternal = "87654321";
            string key = "12345678";
            string keyExternal = "43218765";

            string messageEncrypted = desx.encrypt(message, keyInternal, key, keyExternal, false);
            Console.WriteLine(messageEncrypted.Length);
            byte[] messageEncryptedByte = Encoding.GetEncoding("ISO-8859-2").GetBytes(messageEncrypted);

            string messageDecrypted = desx2.encrypt(messageEncryptedByte, keyInternal, key, keyExternal, true);

            Console.WriteLine(messageEncrypted);
            Console.WriteLine(messageDecrypted);
            */
        }
    }

}
