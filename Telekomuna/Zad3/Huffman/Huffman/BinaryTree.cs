using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    internal class BinaryTree
    {
        private char _character;
        public BinaryTree leftLeaf = null;
        public BinaryTree rightLeaf = null;
        private int _value;
        public bool isSum = false;

        public BinaryTree(char character, int value)
        {
            _character = character;
            this._value = value;
        }

        public BinaryTree(int value)    // Konstruktor tworzący liść - sumę dzieci
        {
            _value = value;
            isSum = true;
        }

        public char GetCharacter() { return _character; }

        public int GetValue() { return _value; }
    }
}
