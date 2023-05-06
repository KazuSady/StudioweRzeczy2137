using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    internal class BinaryTreeComparer : Comparer<BinaryTree>
    {
        public override int Compare(BinaryTree x, BinaryTree y)
        {
            if (x.GetValue() != y.GetValue()) { return x.GetValue() - y.GetValue(); } //Jeżeli wartość różna, wykonywane zwykłe porównanie
            if (!x.isSum && !y.isSum) { return x.GetCharacter() - y.GetCharacter(); } //Jeżeli oba nie są sumami, porównaj alfabetycznie
            if (!x.isSum && y.isSum) { return 1; } //Jeżeli są równe i pierwszy nie jest sumą, będzie większy
            if (x.isSum && !y.isSum) { return -1; } //Jeżeli są równe i drugi nie jest sumą, będzie mniejszy
            return -1;
        }
    }
}
