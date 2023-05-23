package audio.audiotransmitter;

import javax.sound.sampled.*;
import java.io.*;
import java.net.Socket;

public class AudioConverter {
    private int SAMPLE_RATE = 44100;
    private int BITS_PER_SAMPLE = 16;
    private int CHANNELS = 1;


    private volatile boolean isRecording = false;
    private String receiverIP = "192.168.1.63";


    public void setSAMPLE_RATE(int SAMPLE_RATE) {
        this.SAMPLE_RATE = SAMPLE_RATE;
    }
    public void setBITS_PER_SAMPLE(int BITS_PER_SAMPLE) {
        this.BITS_PER_SAMPLE = BITS_PER_SAMPLE;
    }
    public void setCHANNELS(int CHANNELS) {
        this.CHANNELS = CHANNELS;
    }


    public void startRecording() {
        try {
            final AudioFormat audioFormat = new AudioFormat(SAMPLE_RATE, BITS_PER_SAMPLE, CHANNELS, true, false);
            final DataLine.Info dataLineInfo = new DataLine.Info(TargetDataLine.class, audioFormat);
            final TargetDataLine targetDataLine = (TargetDataLine) AudioSystem.getLine(dataLineInfo);
            targetDataLine.open(audioFormat);
            targetDataLine.start();

            isRecording = true;

            // Tworzenie nowego wątku do nagrywania dźwięku
            Thread recordingThread = new Thread(() -> {
                try {
                    final byte[] buffer = new byte[4096];
                    final ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

                    System.out.println("Nagrywanie rozpoczęte...");

                    while (isRecording) {
                        int bytesRead = targetDataLine.read(buffer, 0, buffer.length);
                        byteArrayOutputStream.write(buffer, 0, bytesRead);
                    }

                    System.out.println("Nagrywanie zatrzymane.");

                    targetDataLine.stop();
                    targetDataLine.close();

                    // Zapis nagrania do pliku WAV
                    saveToWav(byteArrayOutputStream.toByteArray(), "recorded.wav");

                    // Wysyłanie pliku WAV przez TCP
                    //sendFileOverTcp("recorded.wav", receiverIP);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });

            recordingThread.start();
        } catch (LineUnavailableException e) {
            e.printStackTrace();
        }
    }

    public void stopRecording() {
        isRecording = false;
    }

    private void saveToWav(byte[] audioData, String fileName) throws IOException {
        final AudioFormat audioFormat = new AudioFormat(SAMPLE_RATE, BITS_PER_SAMPLE, CHANNELS, true, false);
        final AudioInputStream audioInputStream = new AudioInputStream(new ByteArrayInputStream(audioData), audioFormat, audioData.length / audioFormat.getFrameSize());
        AudioSystem.write(audioInputStream, AudioFileFormat.Type.WAVE, new File(fileName));
        audioInputStream.close();
    }

    public void sendFileOverTcp(String destinationIp) throws IOException {
        final File file = new File("recorded.wav");
        final byte[] fileData = new byte[(int) file.length()];
        final FileInputStream fileInputStream = new FileInputStream(file);
        final BufferedInputStream bufferedInputStream = new BufferedInputStream(fileInputStream);

        bufferedInputStream.read(fileData, 0, fileData.length);

        final Socket socket = new Socket(destinationIp, 8080);
        final OutputStream outputStream = socket.getOutputStream();

        outputStream.write(fileData, 0, fileData.length);
        outputStream.flush();

        bufferedInputStream.close();
        outputStream.close();
        socket.close();

        System.out.println("Plik wysłany do: " + destinationIp);
    }
}