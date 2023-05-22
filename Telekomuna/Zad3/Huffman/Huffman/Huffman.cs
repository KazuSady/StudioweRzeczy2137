using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Huffman
{
    internal class Huffman
    {
        public string message;
        private Dictionary<char, string> _dictionary = new Dictionary<char, string>();
        private Dictionary<string, char> _decodeDictionary = new Dictionary<string, char>();

        public string GetCodeValue(char c)
        {
            return _dictionary[c];
        }

        public string GetEncode()
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in message.ToCharArray())
            {
                sb.Append(GetCodeValue(c));
            }
            return sb.ToString();
        }

        public string GetDictionaryString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(char c in _dictionary.Keys)
            {
                stringBuilder.Append(c)
                    .Append(" ")
                    .Append(_dictionary[c])
                    .Append("\n");
            }
            return stringBuilder.ToString();
        }

        public Huffman(string message)
        {
            this.message = message;
            Dictionary<char, int> frequency = new Dictionary<char, int>();
            foreach (char c in this.message.ToCharArray())
            {
                if (frequency.ContainsKey(c))
                {
                    frequency[c]++;
                }
                else
                {
                    frequency[c] = 1;
                }
            }
            if (frequency.Count() == 1)
            {
                KeyValuePair<char, int> kvp = frequency.First();
                BinaryTree root = new BinaryTree(kvp.Key, kvp.Value);
                Encode(root, "");
            }
            else
            {
                BinaryTreeComparer tmp = new BinaryTreeComparer();
                var trees = new List<BinaryTree>();
                foreach (KeyValuePair<char, int> kvp in frequency)
                {
                    BinaryTree n = new BinaryTree(kvp.Key, kvp.Value);
                    trees.Add(n);
                }
                trees.Sort(tmp);
                BinaryTree root = null;
                while (trees.Count > 1)
                {
                    BinaryTree child1 = trees.First();
                    trees.Remove(child1);
                    BinaryTree child2 = trees.First();
                    trees.Remove(child2);
                    BinaryTree parent = new BinaryTree(child1.GetValue() + child2.GetValue());
                    if (child1.GetValue() == child2.GetValue() && child1.isSum)
                    {
                        BinaryTree helper = child1;
                        child1 = child2;
                        child2 = helper;
                    }
                    root = parent;
                    parent.leftLeaf = child1;
                    parent.rightLeaf = child2;
                    trees.Add(root);
                    trees.Sort(tmp);
                }
                Encode(root, "");
            }  
        }

        public Huffman(string encoded, string path)
        {
            StreamReader sr = new StreamReader(path);
            string tmp;
            string tmpsub;
            StreamReader liner = new StreamReader(path);
            int lines = 0;
            while (liner.ReadLine() != null)
            {
                lines++;
            }
            liner.Close();
            for(int i = 0; i< lines-1; i++)
            {
                tmp = sr.ReadLine();
                tmpsub = tmp.Substring(2);
                _decodeDictionary.Add(tmpsub, tmp.ToCharArray()[0]);
            }
            tmp = "";
            StringBuilder sb = new StringBuilder();
            foreach(char c in encoded.ToCharArray())
            {
                tmp += c;
                if(_decodeDictionary.ContainsKey(tmp))
                {
                    sb.Append(_decodeDictionary[tmp]);
                    tmp = "";
                }
            }
            message = sb.ToString();
        }

        private void Encode(BinaryTree tree, string opt)
        {
            if (tree == null) return;
            if (!tree.GetCharacter().Equals('\0'))
            {
                _dictionary.Add(tree.GetCharacter(), opt);
            }
            Encode(tree.leftLeaf, opt + "0");
            Encode(tree.rightLeaf, opt + "1");
        }
    }
}
