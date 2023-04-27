package rsasignature;

import java.io.FileInputStream;
import java.math.BigInteger;
import java.security.MessageDigest;
import java.util.Random;

public class RSA {
    private BigInteger _p;
    private BigInteger _q;
    private BigInteger _n;
    private BigInteger _Euler;
    private BigInteger _e;
    private BigInteger _d;
    private int bitLength;

    public BigInteger get_n() {
        return _n;
    }
    public BigInteger get_e() {
        return _e;
    }
    public BigInteger get_d() {
        return _d;
    }
    public BigInteger get_Euler() {
        return _Euler;
    }

    public RSA (int bitLength){
        this.bitLength = bitLength;
    }

    public void generateKeys(){
        Random random = new Random();
        _q = BigInteger.probablePrime(bitLength, random);
        _p = BigInteger.probablePrime(bitLength, random);
        _n = _p.multiply(_q);
        _Euler = (_p.subtract(BigInteger.ONE)).multiply(_q.subtract(BigInteger.ONE));
        _e = generateCoprimeNumber(_Euler);
        _d = Euklides.EuclideanAlgorithmExtended(_e, _Euler);
    }

    public BigInteger generateBlindSignature(BigInteger message, BigInteger d, BigInteger n) throws Exception {
        //MessageDigest md = MessageDigest.getInstance("SHA-256");
        //byte[] messageBytes = message.toByteArray();
       //byte[] hash = md.digest(messageBytes);

       // BigInteger hashedMessage = new BigInteger(1, hash);
        BigInteger r = generateCoprimeNumber(n);
        BigInteger blindMessage = r.modPow(d, n).multiply(message).mod(n);
        BigInteger blindSignature = blindMessage.modPow(d, n);
        BigInteger invertedR = r.modInverse(n);
        BigInteger signature = blindSignature.multiply(invertedR).mod(n);
        return signature;
    }

    public BigInteger verifyBlindSignature(BigInteger message, BigInteger signature, BigInteger e, BigInteger n) throws Exception {
        //MessageDigest md = MessageDigest.getInstance("SHA-256");
        //byte[] messageBytes = message.toByteArray();
        //byte[] hash = md.digest(messageBytes);

        //BigInteger hashedMessage = new BigInteger(1, hash);
        BigInteger blindSignature = signature.modPow(e, n);
        BigInteger blindMessage = blindSignature.multiply(message.modInverse(n)).mod(n);
        BigInteger decryptedSignature = blindMessage.modPow(e, n);
        return decryptedSignature;
    }

    public BigInteger generateCoprimeNumber(BigInteger max){
        BigInteger tmp = max.divide(BigInteger.valueOf(3));
        while(!Euklides.isPrime(max,tmp)){
            tmp = tmp.add(BigInteger.ONE);
        }
        return tmp;
    }
}
