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

            //DESX desx = new DESX();
           // DESX desx2 = new DESX();

            //string message = "dupa1234dupa1";
            //string key = "12345678";
            //string keyInternal = "87654321";
            //string keyExternal = "43218765";

            //string messageEncrypted = desx.encrypt(message, key, keyInternal, keyExternal, false);
            //string messageDecrypted = desx2.encrypt(messageEncrypted, key, keyInternal, keyExternal, true);


            //Console.WriteLine(messageEncrypted);
            //Console.WriteLine(messageDecrypted);

        }
    }

}
