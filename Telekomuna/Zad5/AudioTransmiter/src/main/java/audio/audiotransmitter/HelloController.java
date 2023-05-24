package audio.audiotransmitter;

import javafx.fxml.FXML;
import javafx.scene.control.TextField;

import java.io.File;
import java.io.IOException;

public class HelloController {
    AudioConverter audioConverter = new AudioConverter();
    private int _sampleRate;
    private int _bitsRate;
    private int _channels;

    @FXML
    private TextField sampleRate;
    @FXML
    private TextField bitsRate;
    @FXML
    private TextField channels;
    @FXML
    private TextField SNR;
    @FXML
    private TextField receiverIP;
    @FXML
    private TextField fileStatus;

    public void initialize(){
        sampleRate.setPromptText("Sample Rate");
        bitsRate.setPromptText("Bits Rate");
        channels.setPromptText("Channels");
        SNR.setPromptText("SNR Value");
        receiverIP.setPromptText("Receiver IP");
        fileStatus.setPromptText("File status...");
    }

    @FXML
    protected void onRecordAudioClick() {
        _sampleRate = Integer.parseInt(sampleRate.getText());
        _bitsRate = Integer.parseInt(bitsRate.getText());
        _channels = Integer.parseInt(channels.getText());

        audioConverter.setCHANNELS(_channels);
        audioConverter.setBITS_PER_SAMPLE(_bitsRate);
        audioConverter.setSAMPLE_RATE(_sampleRate);

        audioConverter.startRecording();
    }
    @FXML
    public void onStopRecordClick() {
        audioConverter.stopRecording();
    }

    @FXML
    public void onSendAudioClick() throws IOException {
        String _receiverIP = receiverIP.getText();
        audioConverter.sendFileOverTcp(_receiverIP);
        fileStatus.setText("File send");
    }

    @FXML
    public void onReceiveAudioClick() throws IOException {
        audioConverter.listenForFileOverTcp();
        fileStatus.setText("File received");
    }

    @FXML
    public void onCalculateSNRClick(){
        double snr = 20 * Math.log10( Math.pow(2, _bitsRate));
        SNR.setText(String.valueOf(snr));
    }



}