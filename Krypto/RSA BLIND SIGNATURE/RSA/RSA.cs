using System;
using System.Numerics;
using System.Security.Cryptography;
using System.IO;
using System.Collections.Generic;

namespace BlindSignature_RSA
{
    internal class RSA
    {
        Random _random = new Random();
        SHA256 sha256Hash = SHA256.Create();

        /*
        public List<BigInteger[]> GenerateKeys()
        {
            List<BigInteger[]> dupa = new List<BigInteger[]>();
            BigInteger n, Euler, e, d;

            BigInteger p = GeneratePrimeNumber();
            BigInteger q = GeneratePrimeNumber();

            n = q * p;
            Euler = (p - 1) * (q - 1);
            e = GenerateRandomNumber(Euler);
            d = ModInverse(e, Euler);

            BigInteger[] privateKey = new BigInteger[2];
            BigInteger[] publicKey = new BigInteger[2];

            privateKey[0] = n;
            privateKey[1] = d;

            publicKey[0] = n;
            publicKey[1] = e;

            dupa.Add(privateKey);
            dupa.Add(publicKey);

            return dupa;
        }
        */

        public List<BigInteger[]> GenerateKeys(int bitLength)
        {
            List < BigInteger[]> keys = new List <BigInteger[]>();
            BigInteger[] privateKey = new BigInteger[2];
            BigInteger[] publicKey = new BigInteger[2];

            BigInteger p = GenerateLargePrime(bitLength);
            BigInteger q = GenerateLargePrime(bitLength);

            BigInteger n = p * q;

            BigInteger phi = (p - 1) * (q - 1);

            BigInteger e;
            do
            {
                e = GenerateRandomBigInteger(phi);
            } while (BigInteger.GreatestCommonDivisor(e, phi) != 1);

            BigInteger d = ModInverse(e, phi);

            privateKey[0] = n;
            privateKey[1] = d;

            publicKey[0] = n;
            publicKey[1] = e;

            keys.Add(privateKey);
            keys.Add(publicKey);

            return keys;
        }

        private BigInteger GenerateLargePrime(int bitLength)
        {
            BigInteger prime;
            do
            {
                prime = GenerateRandomBigInteger(BigInteger.Pow(2, bitLength));
            } while (!IsPrime(prime));

            return prime;
        }
        private  BigInteger GenerateRandomBigInteger(BigInteger max)
        {
            byte[] bytes = max.ToByteArray();
            _random.NextBytes(bytes);
            bytes[bytes.Length - 1] &= 0x7F;    
            // Clears the last bit to ensure that the number is greater than 0
            return new BigInteger(bytes);
        }




        public byte[] BlindSignFile(string filePath, BigInteger[] privateKey)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            byte[] hashedFile = sha256Hash.ComputeHash(fileBytes);

            BigInteger hashedBigInt = new BigInteger(hashedFile);
            BigInteger blindedHashedBigInt = BlindMessage(hashedBigInt, privateKey[0]);

            BigInteger signedBlindedHashedBigInt = ModPow(blindedHashedBigInt, privateKey[1], privateKey[0]);
            byte[] signedBlindedHashedFileBytes = signedBlindedHashedBigInt.ToByteArray();

            return signedBlindedHashedFileBytes;
        }
        public bool VerifyBlindSignature(string filePath, byte[] signature, BigInteger[] publicKey)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            byte[] hashedFile = sha256Hash.ComputeHash(fileBytes);

            BigInteger signatureBigInt = new BigInteger(signature);
            BigInteger signedBlindedHashedBigInt = ModPow(signatureBigInt, publicKey[1], publicKey[0]);
            BigInteger hashedBigInt = new BigInteger(hashedFile);
            BigInteger blindedHashedBigInt = BlindMessage(hashedBigInt, publicKey[0]);

            return blindedHashedBigInt == signedBlindedHashedBigInt;
        }
        private BigInteger BlindMessage(BigInteger message, BigInteger n)
        {
            BigInteger r = GenerateRandomNumber(n);
            BigInteger blindedMessage = (message * ModPow(r, n - 2, n)) % n;
            return blindedMessage;
        }




        private bool IsPrime(BigInteger n)
        {
            if (n == 2 || n == 3)
            {
                return true;
            }

            if (n < 2 || n % 2 == 0)
            {
                return false;
            }

            BigInteger d = n - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }

            for (int i = 0; i < 10; i++)
            {
                BigInteger a = GenerateRandomBigInteger(n - 4) + 2;
                BigInteger x = BigInteger.ModPow(a, d, n);

                if (x == 1 || x == n - 1)
                {
                    continue;
                }

                for (int j = 0; j < s - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, n);

                    if (x == 1)
                    {
                        return false;
                    }

                    if (x == n - 1)
                    {
                        break;
                    }
                }

                if (x != n - 1)
                {
                    return false;
                }
            }

            return true;
        }
        private BigInteger ModInverse(BigInteger a, BigInteger n)
        {
            BigInteger t = 0, newT = 1, r = n, newR = a;

            while (newR != 0)
            {
                BigInteger quotient = r / newR;

                BigInteger tempT = t;
                t = newT;
                newT = tempT - quotient * newT;

                BigInteger tempR = r;
                r = newR;
                newR = tempR - quotient * newR;
            }

            if (r > 1)
            {
                throw new InvalidOperationException("a is not invertible modulo n");
            }
            if (t < 0)
            {
                t += n;
            }

            return t;
        }



        private BigInteger GenerateRandomNumber(BigInteger n)
        {
            Random random = new Random();
            BigInteger r;
            do
            {
                byte[] bytes = new byte[n.ToByteArray().Length];
                random.NextBytes(bytes);
                r = BigInteger.Abs(new BigInteger(bytes));
            } while (BigInteger.GreatestCommonDivisor(r, n) != 1);
            return r;
        }
        private BigInteger ModPow(BigInteger a, BigInteger b, BigInteger n)
        {
            BigInteger result = 1;
            while (b > 0)
            {
                if (b % 2 == 1)
                    result = (result * a) % n;
                a = (a * a) % n;
                b /= 2;
            }
            return result;
        }

    }
}
