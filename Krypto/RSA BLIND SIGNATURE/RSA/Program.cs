//Autorzy:
//        Laura Nowogórska 242479
//        Szymon Wydmuch   242568 

using System;
using System.Numerics;
using System.Collections.Generic;

namespace BlindSignature_RSA
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string filePath = "C:\\Users\\Husaiin\\Desktop\\Studia\\CoSieDzieje3.txt";
            
            RSA rsa = new RSA();

            List<BigInteger[]> keys = new List<BigInteger[]>();

            keys = rsa.GenerateKeys(128);

            byte[] signature = rsa.BlindSignFile(filePath, keys[0]);

            if (rsa.VerifyBlindSignature(filePath, signature, keys[1]))
            {
                Console.WriteLine("Poprawny podpis");
            } else 
            {
                Console.WriteLine("Niepoprawny podpis");
            }

        }
    }
}

