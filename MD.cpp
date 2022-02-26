#include <iostream>
#include <cstdlib>
#include <vector>
using namespace std;
int main()
{
    int i, j, indeks1, indeks2;
    vector<int>tab1;
    vector<int>tab2;
    int wagigrafu[10][10];
    srand(time(NULL));
    cout << endl;
    for (i = 0; i < 10; i++)
    {
        tab1.push_back(i+1);
    }

    indeks1 = (rand() % 10) + 1; //losowanie pierwszej wartosci do tab2
    tab2.push_back(indeks1);
    tab1.erase(tab1.begin() + indeks1 - 1);

    for (i = 0; i < 9; i++)  //tworzenie grafu
    {
        cout << "polaczenie nr." << i + 1 << endl;
        indeks1 = (rand() % tab1.size());
        indeks2 = (rand() % tab2.size());
        cout << tab1[indeks1] << " --- " << tab2[indeks2] << endl;
        tab2.push_back(tab1[indeks1]);
        tab1.erase(tab1.begin() + indeks1);
        cout << endl << endl;
    }   
    cout << "  1 2 3 4 5 6 7 8 9 10" << endl;  //macierz wag grafu
    for (i = 0; i < 10; i++)
    {
        cout << i + 1 << " ";
        for (j = 0; j < 10; j++)
        {
            if (i == j)
                wagigrafu[i][j] = 0;
            else
                wagigrafu[i][j] = (rand() % 111) + 10;
            cout << wagigrafu[i][j] << " ";
        }
        cout << endl;
    }
return 0;
}