package audio.audiotransmitter;

import javax.sound.sampled.*;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

public class AudioConverter {
    private int SAMPLE_RATE = 44100;
    private int BITS_PER_SAMPLE = 16;
    private int CHANNELS = 1;
    private volatile boolean isRecording = false;
    private File file;


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
            AudioFormat audioFormat = new AudioFormat(SAMPLE_RATE, BITS_PER_SAMPLE, CHANNELS, true, false);
            DataLine.Info dataLineInfo = new DataLine.Info(TargetDataLine.class, audioFormat);
            TargetDataLine targetDataLine = (TargetDataLine) AudioSystem.getLine(dataLineInfo);
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
        file = new File("recorded.wav");
        AudioFormat audioFormat = new AudioFormat(SAMPLE_RATE, BITS_PER_SAMPLE, CHANNELS, true, false);
        AudioInputStream audioInputStream = new AudioInputStream(new ByteArrayInputStream(audioData), audioFormat, audioData.length / audioFormat.getFrameSize());
        AudioSystem.write(audioInputStream, AudioFileFormat.Type.WAVE, file);
        audioInputStream.close();
    }

    public void sendFileOverTcp(String destinationIp) throws IOException {
        file = new File("recorded.wav");
        byte[] fileData = new byte[(int) file.length()];
        FileInputStream fileInputStream = new FileInputStream(file);
        BufferedInputStream bufferedInputStream = new BufferedInputStream(fileInputStream);

        bufferedInputStream.read(fileData, 0, fileData.length);

        Socket socket = new Socket(destinationIp, 8080);
        OutputStream outputStream = socket.getOutputStream();

        outputStream.write(fileData, 0, fileData.length);
        outputStream.flush();

        bufferedInputStream.close();
        outputStream.close();
        socket.close();

        System.out.println("Plik wysłany do: " + destinationIp);

    }

    public void listenForFileOverTcp() throws IOException {
        ServerSocket serverSocket = new ServerSocket(8080);

        System.out.println("Oczekiwanie na połączenie...");

        Socket clientSocket = serverSocket.accept();

        System.out.println("Połączono z klientem: " + clientSocket.getInetAddress().getHostAddress());

        byte[] buffer = new byte[4096];
        InputStream inputStream = clientSocket.getInputStream();
        FileOutputStream fileOutputStream = new FileOutputStream("received.wav");
        BufferedOutputStream bufferedOutputStream = new BufferedOutputStream(fileOutputStream);

        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) {
            bufferedOutputStream.write(buffer, 0, bytesRead);
        }

        bufferedOutputStream.flush();

        System.out.println("Plik odebrany i zapisany jako received.wav");
        bufferedOutputStream.close();
        inputStream.close();
        clientSocket.close();
        serverSocket.close();
    }

    public void loadFile(File file) {
        this.file = file;

    }

    public synchronized void play() {
        new Thread(() -> {
            try {
                Clip clip = AudioSystem.getClip();
                AudioInputStream inputStream = AudioSystem.getAudioInputStream(AudioConverter.class.getResourceAsStream(file.getAbsolutePath()));
                clip.open(inputStream);
                clip.start();
            } catch (LineUnavailableException | UnsupportedAudioFileException | IOException e) {
                throw new RuntimeException(e);
            }
        }).start();
    }

}