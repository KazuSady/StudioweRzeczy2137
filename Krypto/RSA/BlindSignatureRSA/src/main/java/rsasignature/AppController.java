package rsasignature;

import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.FileChooser;
import javafx.stage.Stage;


import java.io.*;
import java.lang.reflect.Constructor;
import java.math.BigInteger;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.MessageDigest;

public class AppController {
    int biteSize = 512;
    private RSA rsa;

    @FXML
    private TextField _nPrivate;
    @FXML
    private TextField _nPublic;
    @FXML
    private TextField _dPrivate;
    @FXML
    private TextField _ePublic;
    @FXML
    private TextField signature;
    @FXML
    private TextField isSignCorrect;
    @FXML
    public void setBiteSize128(){
        biteSize = 128;
    }
    @FXML
    public void setBiteSize256(){
        biteSize = 256;
    }
    @FXML
    public void setBiteSize512(){
        biteSize = 512;
    }


    @FXML
    public void generateSignature() throws Exception {

        MessageDigest md = MessageDigest.getInstance("SHA-256");
        byte[] fileBytes = Files.readAllBytes(Paths.get("C:\\Users\\Husaiin\\Downloads\\WspolbiezneMax_.pdf"));
        byte[] hash = md.digest(fileBytes);
        BigInteger fileBigInteger = new BigInteger(1, hash);

        BigInteger n = new BigInteger(_nPrivate.getText());
        BigInteger d = new BigInteger(_dPrivate.getText());
        signature.setText(rsa.generateBlindSignature(fileBigInteger, d, n).toString());
    }

    @FXML
    public void verifySignature() throws Exception {

        MessageDigest md = MessageDigest.getInstance("SHA-256");
        byte[] fileBytes = Files.readAllBytes(Paths.get("C:\\Users\\Husaiin\\Downloads\\WspolbiezneMax_.pdf"));
        byte[] hash = md.digest(fileBytes);
        BigInteger fileBigInteger = new BigInteger(1, hash);


        BigInteger sign = new BigInteger(signature.getText());
        BigInteger n = new BigInteger(_nPublic.getText());
        BigInteger e = new BigInteger(_ePublic.getText());
        isSignCorrect.setText("verified sign " + rsa.verifyBlindSignature(fileBigInteger,sign,e,n).toString());
    }

    @FXML
    public void generateKeys() {
        rsa = new RSA(biteSize);

        rsa.generateKeys();
        _nPrivate.setText(rsa.get_n().toString());
        _dPrivate.setText(rsa.get_d().toString());

        _nPublic.setText(rsa.get_n().toString());
        _ePublic.setText(rsa.get_e().toString());
    }
    @FXML void saveSignature() {
        FileChooser fileChooser = new FileChooser();
        FileChooser.ExtensionFilter extensionFilter = new FileChooser.ExtensionFilter("txt files (*.txt)", "*.txt");
        fileChooser.getExtensionFilters().add(extensionFilter);

        fileChooser.setTitle("Zapisz podpisz");
        File sign = fileChooser.showSaveDialog(new Stage());

        if (sign != null) {
            try {

                FileWriter fileWriter = new FileWriter(sign);
                BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);

                bufferedWriter.write(signature.getText());

                bufferedWriter.close();
                fileWriter.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
    @FXML
    public void saveKeys() {
        FileChooser fileChooser = new FileChooser();
        FileChooser.ExtensionFilter extensionFilter = new FileChooser.ExtensionFilter("txt files (*.txt)", "*.txt");
        fileChooser.getExtensionFilters().add(extensionFilter);

        fileChooser.setTitle("Zapisz klucz prywatny");
        File privateKey = fileChooser.showSaveDialog(new Stage());
        fileChooser.setTitle("Zapisz klucz publiczny");
        File publicKey = fileChooser.showSaveDialog(new Stage());

        if (privateKey != null) {
            try {

                FileWriter fileWriter = new FileWriter(privateKey);
                BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);

                bufferedWriter.write(_nPrivate.getText());
                bufferedWriter.write("\n");
                bufferedWriter.write(_dPrivate.getText());


                bufferedWriter.close();
                fileWriter.close();
            } catch (IOException e) {
                e.printStackTrace();
            }

        }
        if (publicKey != null) {
            try {

                FileWriter fileWriter = new FileWriter(publicKey);
                BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);

                bufferedWriter.write(_nPublic.getText());
                bufferedWriter.write("\n");
                bufferedWriter.write(_ePublic.getText());


                bufferedWriter.close();
                fileWriter.close();
            } catch (IOException e) {
                e.printStackTrace();
            }

        }
    }

}