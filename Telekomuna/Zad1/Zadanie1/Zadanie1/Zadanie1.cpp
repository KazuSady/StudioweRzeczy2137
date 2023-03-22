#include <iostream>
#include <string>
#include <fstream>

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


string MacierzWektorMnozenie(int macierz[8][16], string wektor) {
	string wynik = "";
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
		if (suma) wynik += "1";
		else wynik += "0";
	}

	return wynik;
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

void Kodowanie(string wiadomosc, ofstream& zakodowany) {

	for (int i = 0; i < wiadomosc.length(); i++) {
		zakodowany << ReprezentacjaBitowa(wiadomosc[i]);
	}
}

int main()
{
	ofstream zakodowany;
	zakodowany.open("Zakodowana.txt");

	Kodowanie("a", zakodowany);
	zakodowany.close();
	return 0;
}

