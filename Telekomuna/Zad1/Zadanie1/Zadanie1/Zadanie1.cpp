#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <bitset>

using namespace std;

int H[8][16] =
{
	{0, 1, 1, 1, 1, 1, 1, 1,	1, 0, 0, 0, 0, 0, 0, 0},   
	{1, 0, 1, 1, 1, 1, 1, 1,	0, 1, 0, 0, 0, 0, 0, 0},   
	{1, 1, 0, 1, 1, 1, 1, 1,	0, 0, 1, 0, 0, 0, 0, 0},   
	{1, 1, 1, 0, 1, 1, 1, 1,	0, 0, 0, 1, 0, 0, 0, 0},   
	{1, 1, 1, 1, 0, 1, 1, 1,	0, 0, 0, 0, 1, 0, 0, 0},   
	{1, 1, 1, 1, 1, 0, 1, 1,	0, 0, 0, 0, 0, 1, 0, 0},   
	{1, 1, 1, 1, 1, 1, 0, 1,	0, 0, 0, 0, 0, 0, 1, 0},   
	{1, 1, 1, 1, 1, 1, 1, 0,	0, 0, 0, 0, 0, 0, 0, 1},   
};

// sample a = {0110 0001, 1001 1110} 
// sample b = {0110 0010, 1001 1101} 

vector<int> SprawdzGdzieBlad(vector<int> wektor) {
	bool znaleziona = false;
	vector <int> bledy;
	int suma = 0;
	for (int i = 0; i < 8; i++) {
		suma = 0;
		for (int j = 0; j < 8; j++) {
			if (wektor.at(j) == H[j][i]) suma++;
		}
		if (suma == 8) bledy.push_back(i);
	}
	
	if (bledy.size() == 0) {
		for (int i = 0; i < 8; i++) {
			suma = 0;
			vector <int> pomnozoneKolumny;
			for (int j = 0; j < 8; j++) {
				if (i == j) continue;
				suma = 0;
				for (int z = 0; z < 8; z++) {
					if ((H[i][z] + H[j][z]) % 2 == 0) pomnozoneKolumny.push_back(0);
					else pomnozoneKolumny.push_back(1);
				}

				for (int y = 0; y < 8; y++) {
					if (wektor.at(y) == pomnozoneKolumny.at(y)) suma++;
				}
				if (suma == 8) {
					bledy.push_back(i);
					bledy.push_back(j);
					return bledy;
				}
				pomnozoneKolumny.clear();
			}

		}
	}

	return bledy;
}

vector<int> MacierzWektorMnozenie(string wektor) {
	vector<int> wynik;
	int suma = 0;
	bool confMacierz;
	bool confWektor;

	for (int i = 0; i < 8; i++) {
		suma = 0;
		int wiersz[16];
		for (int j = 0; j < 16; j++) {
			wiersz[j] = H[i][j];
		}

		for (int j = 0; j < 16; j++) {
			if (wiersz[j] == 1) confMacierz = true;
			else confMacierz = false;
			if (wektor[j] == '1') confWektor = true;
			else confWektor = false;
			suma ^= confMacierz & confWektor;
		}
		if (suma) wynik.push_back(1);
		else wynik.push_back(0);
	}

	return wynik;
}

void naprawBlad(string& wynik) {

	vector<int> bledy = SprawdzGdzieBlad(MacierzWektorMnozenie(wynik));
	for (int i = 0; i < bledy.size(); i++) {
		int kolumna = bledy.at(i);
		if (wynik[kolumna] == '1') wynik[kolumna] = '0';
		else wynik[kolumna] = '1';
	}

}

string ReprezentacjaBitowa(char a) {
    string wynik;
	string parzystosci;
	int suma = 0;

    for (int i = 7; i >= 0; i--) {
        wynik += to_string((a >> i) & 1);
    }

	for (int i = 0; i < 8; i++) {
		int suma = 0;
		for (int j = 0; j < 8; j++) {
			if (H[i][j] == 0) continue;
			if (wynik[j] == '1') suma ++;
		}
		if (suma % 2 == 0) wynik += "0";
		else wynik += "1";
	}
    return wynik;
}




void Kodowanie(string wiadomosc, string fileName) {
	ofstream zakodowany;

	string symbolBits;
	string symbolParity;
	char symbol;
	char symbol2;

	zakodowany.open(fileName);

	for (int i = 0; i < wiadomosc.length(); i++) {
		symbolBits = ReprezentacjaBitowa(wiadomosc[i]).substr(0, 8);
		symbolParity = ReprezentacjaBitowa(wiadomosc[i]).substr(8, 16);

		symbol = static_cast<char>(stoi(symbolBits, nullptr, 2));
		symbol2 = static_cast<char>(stoi(symbolParity, nullptr, 2));
		zakodowany << symbol << symbol2;
	}
	zakodowany.close();

}


void Dekodowanie(string inFileName, string outfileName) {
	ifstream infile(inFileName);
	ofstream outFile(outfileName);

	string binary_string;
	char buffer[2];
	char symbol;
	string symbolBits;

	while (infile.read(buffer, 2)) {

		std::bitset<8> bits(buffer[0]);
		std::bitset<8> bits2(buffer[1]);
		binary_string = bits.to_string() + bits2.to_string();
		naprawBlad(binary_string);
		symbolBits = binary_string.substr(0, 8);
		symbol = static_cast<char>(stoi(symbolBits, nullptr, 2));
		outFile << symbol;
	}
}

string wczytajWiadomosc(string inFileName) {
	ifstream infile(inFileName);
	string wiadomosc;
	infile >> wiadomosc;
	return wiadomosc;
}

int main()
{
	string zakodowanaFileName = "Zakodowana.txt";
	string odkodowanaFileName = "Odkodowana.txt";
	string wiadomoscFileName = "Wiadomosc.txt";
	int wybor;
	cout << "Jaka operacje chcesz wykonac?" << "\n";
	cout << "1. Kodowanie wiadomosci w pliku wiadomosc.txt" << "\n";
	cout << "2. Dekodowanie wiadomosci z poprawionymi bledami do pliku odkodowana.txt" << "\n";
	cout << "Wybor: ";
	cin >> wybor;
	switch (wybor) {
	case 1:
		Kodowanie(wczytajWiadomosc(wiadomoscFileName), zakodowanaFileName);
		break;
	case 2:
		Dekodowanie(zakodowanaFileName, odkodowanaFileName);
		break;
	}

	return 0;
}

