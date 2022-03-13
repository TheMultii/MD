#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <vector>
#include <locale.h>
#include "Windows.h"

using namespace std;

int main() {
    int i, j, indeks1, indeks2, wagigrafu[10][10]{};
    vector<int> tab1, tab2;
    srand(time(NULL));
    setlocale(LC_CTYPE, "Polish");

    for (i = 0; i < 10; i++) {
        tab1.push_back(i + 1);
    }

    indeks1 = (rand() % 10) + 1; //losowanie pierwszej wartosci do tab2
    tab2.push_back(indeks1);
    tab1.erase(tab1.begin() + indeks1 - 1);

    for (i = 0; i < 9; i++) { //tworzenie grafu
        cout << "po³¹czenie nr " << i + 1 << "\n";
        indeks1 = (rand() % tab1.size());
        indeks2 = (rand() % tab2.size());
        cout << tab1[indeks1] << " --- " << tab2[indeks2] << "\n";
        tab2.push_back(tab1[indeks1]);
        tab1.erase(tab1.begin() + indeks1);
        cout << "\n\n";
    }

    HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

    for (i = 0; i < 10; i++) {
        if (i == 0) {
            cout << setw(3) << setfill(' ') << "";
            for (int j = 1; j <= 10; j++)
                cout << left << setw(4) << setfill(' ') << j;
            cout << "\n";
        }

        cout << left << setw(3) << setfill(' ') << i + 1;

        for (j = 0; j < 10; j++) {
            if (i == j) {
                SetConsoleTextAttribute(hConsole, 12);
                wagigrafu[i][j] = 0;
            }
            else {
                SetConsoleTextAttribute(hConsole, 11);
                wagigrafu[i][j] = (rand() % 111) + 10;
            }

            cout << left << setw(4) << setfill(' ') << wagigrafu[i][j];
            SetConsoleTextAttribute(hConsole, 7);
        }
        cout << "\n";
    }
    return 0;
}