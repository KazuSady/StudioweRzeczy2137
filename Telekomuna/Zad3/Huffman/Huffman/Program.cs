using Huffman;
Console.WriteLine("Autorzy: Laura Nowogórska i Szymon Wydmuch");
Console.WriteLine("Nadajnik czy odbiornik?");
string choice = Console.ReadLine();
if (choice.Equals("O") || choice.Equals("o"))
{
    Console.WriteLine("Podaj swoj adres ip");
    string ip = Console.ReadLine();
    Receiver receiver = new Receiver();
    receiver.StartListeningDir(ip);
    receiver.StopListening();
    receiver.StartListeningEncode(ip);
    receiver.StopListening();
}
else if (choice.Equals("N") || choice.Equals("n"))
{
    Sender sender = new Sender();
    Console.WriteLine("Podaj adres ip odbiornika");
    string ip = Console.ReadLine();
    sender.StartConnection(ip);
    Console.WriteLine("Wprowadz tekst do przeslania");
    string mes = Console.ReadLine();
    
    sender.SendDic(mes);
    sender.StopConnection();

    sender.StartConnection(ip);
    sender.SendEnc(mes);
    sender.StopConnection();

}
