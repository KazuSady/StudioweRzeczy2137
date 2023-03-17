using Zadanie1;

Kod kod = new Kod();

String filePath = "C:\\Users\\Husaiin\\Desktop\\Studia\\SEM 4\\StudioweRzeczy2137\\Telekomuna\\Zad1\\Zadanie1\\kekw.txt";

FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

Console.WriteLine(kod.kodowanie(fs));

