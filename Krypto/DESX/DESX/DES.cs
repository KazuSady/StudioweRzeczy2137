﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace DESX
{
    internal class DES
    {
        private Permutation permutation = new Permutation();

        private byte[] permutationE = {
            32,  1,  2,  3,  4,  5,
            4,  5,  6,  7,  8,  9,
            8,  9, 10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32,  1
        };
        private byte[][] SBox = {
            new byte[]{
                    14,  4, 13,  1,  2, 15, 11,  8,  3, 10,  6, 12,  5,  9,  0,  7,
                     0, 15,  7,  4, 14,  2, 13,  1, 10,  6, 12, 11,  9,  5,  3,  8,
                     4,  1, 14,  8, 13,  6,  2, 11, 15, 12,  9,  7,  3, 10,  5,  0,
                    15, 12,  8,  2,  4,  9,  1,  7,  5, 11,  3, 14, 10,  0,  6, 13},
            new byte[]{
                    15,  1,  8, 14,  6, 11,  3,  4,  9,  7,  2, 13, 12,  0,  5, 10,
                     3, 13,  4,  7, 15,  2,  8, 14, 12,  0,  1, 10,  6,  9, 11,  5,
                     0, 14,  7, 11, 10,  4, 13,  1,  5,  8, 12,  6,  9,  3,  2, 15,
                    13,  8, 10,  1,  3, 15,  4,  2, 11,  6,  7, 12,  0,  5, 14,  9},
            new byte[]{
                    10,  0,  9, 14,  6,  3, 15,  5,  1, 13, 12,  7, 11,  4,  2,  8,
                    13,  7,  0,  9,  3,  4,  6, 10,  2,  8,  5, 14, 12, 11, 15,  1,
                    13,  6,  4,  9,  8, 15,  3,  0, 11,  1,  2, 12,  5, 10, 14,  7,
                     1, 10, 13,  0,  6,  9,  8,  7,  4, 15, 14,  3, 11,  5,  2, 12},
            new byte[]{
                     7, 13, 14,  3,  0,  6,  9, 10,  1,  2,  8,  5, 11, 12,  4, 15,
                    13,  8, 11,  5,  6, 15,  0,  3,  4,  7,  2, 12,  1, 10, 14,  9,
                    10,  6,  9,  0, 12, 11,  7, 13, 15,  1,  3, 14,  5,  2,  8,  4,
                     3, 15,  0,  6, 10,  1, 13,  8,  9,  4,  5, 11, 12,  7,  2, 14},
            new byte[]{
                     2, 12,  4,  1,  7, 10, 11,  6,  8,  5,  3, 15, 13,  0, 14,  9,
                    14, 11,  2, 12,  4,  7, 13,  1,  5,  0, 15, 10,  3,  9,  8,  6,
                     4,  2,  1, 11, 10, 13,  7,  8, 15,  9, 12,  5,  6,  3,  0, 14,
                    11,  8, 12,  7,  1, 14,  2, 13,  6, 15,  0,  9, 10,  4,  5,  3},
            new byte[]{
                    12,  1, 10, 15,  9,  2,  6,  8,  0, 13,  3,  4, 14,  7,  5, 11,
                    10, 15,  4,  2,  7, 12,  9,  5,  6,  1, 13, 14,  0, 11,  3,  8,
                     9, 14, 15,  5,  2,  8, 12,  3,  7,  0,  4, 10,  1, 13, 11,  6,
                     4,  3,  2, 12,  9,  5, 15, 10, 11, 14,  1,  7,  6,  0,  8, 13},
            new byte[]{
                     4, 11,  2, 14, 15,  0,  8, 13,  3, 12,  9,  7,  5, 10,  6,  1,
                    13,  0, 11,  7,  4,  9,  1, 10, 14,  3,  5, 12,  2, 15,  8,  6,
                     1,  4, 11, 13, 12,  3,  7, 14, 10, 15,  6,  8,  0,  5,  9,  2,
                     6, 11, 13,  8,  1,  4, 10,  7,  9,  5,  0, 15, 14,  2,  3, 12},
            new byte[]{
                    13,  2,  8,  4,  6, 15, 11,  1, 10,  9,  3, 14,  5,  0, 12,  7,
                     1, 15, 13,  8, 10,  3,  7,  4, 12,  5,  6, 11,  0, 14,  9,  2,
                     7, 11,  4,  1,  9, 12, 14,  2,  0,  6, 10, 13, 15,  3,  5,  8,
                     2,  1, 14,  7,  4, 10,  8, 13, 15, 12,  9,  0,  3,  5,  6, 11}
    };
        private byte[] permutationP = {
            16,  7, 20, 21, 29, 12, 28, 17,
             1, 15, 23, 26,  5, 18, 31, 10,
             2,  8, 24, 14, 32, 27,  3,  9,
            19, 13, 30,  6, 22, 11,  4, 25
        };
        private byte[] finalPerm = {
            40,  8, 48, 16, 56, 24, 64, 32,
            39,  7, 47, 15, 55, 23, 63, 31,
            38,  6, 46, 14, 54, 22, 62, 30,
            37,  5, 45, 13, 53, 21, 61, 29,
            36,  4, 44, 12, 52, 20, 60, 28,
            35,  3, 43, 11, 51, 19, 59, 27,
            34,  2, 42, 10, 50, 18, 58, 26,
            33,  1, 41,  9, 49, 17, 57, 25
        };
        List<byte[]> subKeys = new List<byte[]>();

        private byte[] expantionPermutationBlock = new byte[48];
        private byte[] substitutionPermutationBlock = new byte[32];
        private byte[] permutationBlock = new byte[32];
        private byte[] connectedBlock = new byte[64];
        private byte[] finalBlock = new byte[64];

        private byte[] prevRight = new byte[32];
        private byte[] leftBlock = new byte[32];
        private byte[] rightBlock = new byte[32];

        private byte[] _XOR1 = new byte[48];
        private byte[] _XOR2 = new byte[48];

        private KeyBlock keyBlock;
        private MessageBlock messageBlock;

        public byte[] enryptBlock(byte[] message, byte[] key, bool decrypt)
        {
            Array.Clear(finalBlock, 0, 64);
            keyBlock = new KeyBlock(key);
            messageBlock = new MessageBlock(message);

            rightBlock = messageBlock.getRightBlock();
            leftBlock = messageBlock.getLeftBlock();
            for (int i = 0; i < 16; i++)
            {
                keyBlock.generateSubKey(i);
                subKeys.Insert(i, keyBlock.getSubKey());    // generujemy 16 pod-kluczy z otrzymanego klucza pierwotnego
            }

            if (decrypt)
            {
                subKeys.Reverse();
            }

            for (int i = 0; i < 16; i++)
            {
                prevRight = rightBlock;
                expansionPermutation();     // poszerzamy prawy blok wiadomości z 32 bitów do 48 bitów poprzez permutacje

                _XOR1 = permutation.xor(expantionPermutationBlock, subKeys.ElementAt(i));
                // wykonujemy operacje xor na poszerzonym prawym bloku oraz pod-kluczu dla aktualnej rundy: wynik 48 bitowy
                applySubsitutionBoxes(_XOR1);
                // wykorzystanie Substitution Boxow, 32 bitowy wynik zapisany w polu substitutionPermutationBlock
                permutationPermutation();
                // permutacja niezmieniajaca rozmiau bloku, 32 bitowy wynik zapisany w polu permutationBlock 
                _XOR2 = permutation.xor(leftBlock, permutationBlock);
                // wykonujemy operacje xor na pierwotnym lewym bloku oraz permutowanym prawym, wynik 32 bitowy i blok w prawy w następnej rundzie  
                rightBlock = _XOR2;
                leftBlock = prevRight;
            }
            Array.Copy(rightBlock, 0, connectedBlock, 0, 32);
            Array.Copy(leftBlock, 0, connectedBlock, 32, 32);
            finalPermutation();
            Array.Clear(expantionPermutationBlock, 0, 48);
            Array.Clear(substitutionPermutationBlock, 0, 32);
            Array.Clear(permutationBlock, 0, 32);
            Array.Clear(connectedBlock, 0, 64);
            Array.Clear(leftBlock, 0, 32);
            Array.Clear(rightBlock, 0, 32);
            Array.Clear(prevRight, 0, 32);
            Array.Clear(_XOR1, 0, 48);
            Array.Clear(_XOR2, 0, 32);
            return finalBlock;
        }


        private void expansionPermutation()
        {
            expantionPermutationBlock = permutation.permutation(permutationE, rightBlock, 48);
        }
        private void permutationPermutation()
        {
            permutationBlock = permutation.permutation(permutationP, substitutionPermutationBlock, 32);
        }
        private void finalPermutation()
        {
            finalBlock = permutation.permutation(finalPerm, connectedBlock, 64);
        }

        private void applySubsitutionBoxes(byte[] afterXorBlock)
        {
            byte[] result = new byte[32];
            byte[] tmp = new byte[6];
            byte[] numberInBytes = new byte[4];
            int index = 0;
            int count = 0;
            int SBoxIndex = 0;

            for(int i = 0; i < afterXorBlock.Length; i++)
            {
                tmp[count] = afterXorBlock[i];
                count++;
                if (count == 6)
                {
                    int number = SBox[SBoxIndex][getValueIndexInSBox(tmp)];
                    SBoxIndex++;
                    numberInBytes = intToByteArray(number);
                    Array.Copy(numberInBytes, 0, result, index, 4);
                    index += 4;
                    count = 0;
                }
            }

            substitutionPermutationBlock = result;
        }
        private int getValueIndexInSBox(byte[] _6BitsTab)
        {
            byte[] row = { _6BitsTab[0], _6BitsTab[5] };
            byte[] column = { _6BitsTab[1], _6BitsTab[2], _6BitsTab[3], _6BitsTab[4] };

            int rowID = 0;
            int columnID = 0;
            int resultId;
            int tmp = 1;

            for (int i = row.Length - 1; i >= 0; i--)
            {
                rowID += row[i] * tmp;
                tmp = tmp * 2;
            }
            tmp = 1;
            for (int i = column.Length - 1; i >= 0; i--)
            {
                columnID += column[i] * tmp;
                tmp = tmp * 2;
            }
            resultId = rowID * 16 + columnID;

            return resultId;
        } 
        private byte[] intToByteArray(int number)
        {
            byte[] block = new byte[4];
            byte tmp;
            for (int i = 0; i < 4; i++)
            {
                block[i] = (byte)(number % 2);
                number = (byte)(number / 2);
            }

            for (int i = 0; i < 2; i++)
            {
                tmp = block[i];
                block[i] = block[3 - i];
                block[3 - i] = tmp;
            }
            return block;
        }
        
    }

}