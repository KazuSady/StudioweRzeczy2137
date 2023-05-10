package rsasignature;

import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import javax.swing.*;
import java.io.*;
import java.math.BigInteger;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.List;

public class AppController {
    int biteSize = 512;
    private RSA rsa = new RSA(biteSize);
    File file = null;
    @FXML
    private TextField _nPrivate;
    @FXML
    private TextField _nPublic;
    @FXML
    private TextField _ePrivate;
    @FXML
    private TextField _dPublic;
    @FXML
    private TextField signature;
    @FXML
    private Label isSignCorrect;
    @FXML
    private Label isFileLoaded;
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
        byte[] fileBytes = Files.readAllBytes(file.toPath());
        byte[] hash = md.digest(fileBytes);
        BigInteger fileBigInteger = new BigInteger(1, hash);
        BigInteger e = new BigInteger(_ePrivate.getText());
        BigInteger n = new BigInteger(_nPrivate.getText());
        BigInteger cypher = rsa.CreateCipher(fileBigInteger,e,n);
        signature.setText(cypher.toString());

        //OR
//        BigInteger t = rsa.CreateT(fileBigInteger, e, n);
//        BigInteger d = new BigInteger(_dPublic.getText());
//        BigInteger sign = rsa.CreateCipher(t,d,n);
//        signature.setText(sign.toString());
    }
    @FXML
    public void loadFile(){
        FileChooser fileChooser = new FileChooser();
        file = fileChooser.showOpenDialog(new Stage());
        if (file != null){
            isFileLoaded.setText(file.getName());
        }
    }

    @FXML
    public void verifySignature() throws Exception {

        MessageDigest md = MessageDigest.getInstance("SHA-256");
        byte[] fileBytes = Files.readAllBytes(file.toPath());
        byte[] hash = md.digest(fileBytes);
        BigInteger fileBigInteger = new BigInteger(1, hash);
        BigInteger d = new BigInteger(_dPublic.getText());
        BigInteger n = new BigInteger(_nPublic.getText());
        BigInteger cypher = new BigInteger(signature.getText());
        BigInteger decrypted = rsa.Decrypt(cypher,d,n);
        if (fileBigInteger.equals(decrypted)){
            isSignCorrect.setText("Podpis poprawny");
        }
        else {
            isSignCorrect.setText("Podpis niepoprawny");
        }

        //OR
//        BigInteger k = rsa.get_k();
//        isSignCorrect.setText((rsa.CheckSignature(fileBigInteger, cypher, k, n)));

    }

    @FXML
    public void generateKeys() {
        rsa.generateKeys();
        _nPrivate.setText(rsa.get_n().toString());
        _ePrivate.setText(rsa.get_e().toString());

        _nPublic.setText(rsa.get_n().toString());
        _dPublic.setText(rsa.get_d().toString());
    }
    @FXML
    public void saveSignature() {
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
    public void loadSignature() throws IOException {
        FileChooser fileChooser = new FileChooser();
        fileChooser.getExtensionFilters().addAll(new FileChooser.ExtensionFilter("txt (*.txt)", "*.txt"));
        File sign = fileChooser.showSaveDialog(new Stage());
        String strSign = Files.readString(sign.toPath());
        signature.setText(strSign);
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
                bufferedWriter.write(_ePrivate.getText());


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
                bufferedWriter.write(_dPublic.getText());


                bufferedWriter.close();
                fileWriter.close();
            } catch (IOException e) {
                e.printStackTrace();
            }

        }
    }
    @FXML
    public void loadPublicKey() throws IOException {
        FileChooser fileChooser = new FileChooser();
        fileChooser.getExtensionFilters().addAll(new FileChooser.ExtensionFilter("txt (*.txt)", "*.txt"));
        File keys = fileChooser.showSaveDialog(new Stage());
        List<String> tmpKeys = Files.readAllLines(keys.toPath());
        _nPublic.setText(tmpKeys.get(0));
        _dPublic.setText(tmpKeys.get(1));
    }
    @FXML
    public void loadPrivateKey() throws IOException {
        FileChooser fileChooser = new FileChooser();
        fileChooser.getExtensionFilters().addAll(new FileChooser.ExtensionFilter("txt (*.txt)", "*.txt"));
        File keys = fileChooser.showSaveDialog(new Stage());
        List<String> tmpKeys = Files.readAllLines(keys.toPath());
        _nPrivate.setText(tmpKeys.get(0));
        _ePrivate.setText(tmpKeys.get(1));
    }
}