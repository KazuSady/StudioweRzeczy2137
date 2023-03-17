using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Zadanie1
{
    internal class Kod
    {
        public String kodowanie(FileStream input)
        {

            BinaryReader br = new BinaryReader(input);
            byte[] bytes = br.ReadBytes((int)input.Length);
            string text = System.Text.Encoding.UTF8.GetString(bytes);
            
            return text;
        }

        public void sprawdzanie(int[,] macierz)
        {

        }


    }
}
