using Huffman;

Console.WriteLine("Nadajnik czy odbiornik?");
string choice = Console.ReadLine();
if (choice.Equals("O") || choice.Equals("o"))
{
    Receiver receiver = new Receiver();
    receiver.StartListening();
    //receiver.StopListening();
}
else if (choice.Equals("N") || choice.Equals("n"))
{
    Sender sender = new Sender();
    Console.WriteLine("Podaj adres ip odbiornika");
    string ip = Console.ReadLine();
    sender.StartConnection(ip);
    Console.WriteLine("Wprowadz tekst do przeslania");
    string mes = Console.ReadLine();
    
    string response = sender.Send(mes);
    Console.WriteLine(response);
    sender.StopConnection();
    
}
