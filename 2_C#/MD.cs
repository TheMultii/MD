double GetRandomDouble(double minimum, double maximum) {
    Random r = new();
    return r.NextDouble() * (maximum - minimum) + minimum;
}

int GetRandomInt(int minimum, int maximum) {
    Random r = new();
    return r.Next(minimum, maximum);
}

int maxPolaczen(int liczbaWierzcholkow) => (liczbaWierzcholkow * (liczbaWierzcholkow - 1)) / 2; //wzór na ilość krawędzi grafu pełnego

void wypelnij(int[,] p, int n) {
    int odrzucone_globalnie = 0,
        odrzucone_w_iteracji,
        aktualna_iteracja = 0;
    for (int i = 1; i < n; i++) {
        odrzucone_w_iteracji = odrzucone_globalnie; //program odrzuca możliwość wystąpienia 1-4 i 4-1
        for (int j = 1; j <= n; j++) {
            if (i != j) { //program odrzuca możliwość wystąpienia 3-3
                if (odrzucone_w_iteracji != 0) {
                    odrzucone_w_iteracji--;
                } else {
                    p[aktualna_iteracja, 0] = i;
                    p[aktualna_iteracja, 1] = j;
                    aktualna_iteracja++;
                }
            }
        }
        odrzucone_globalnie++;
    }
}

void stworz(int[,] p, int n, double szansa, int waga_min, int waga_max) {
    for (int i = 0; i < n; i++) {
        p[i, 2] = szansa > GetRandomDouble(0.0, 1.0) ? 1 : -1; // 1 - połączenie, -1 - brak
        p[i, 3] = GetRandomInt(waga_min, waga_max);
    }
}

int zliczanieTrojkatow(int[,] istnieniePolaczen, int iloscWierzcholkow) {
    int iloscTrojkatow = 0;
    for (int i = 0; i < iloscWierzcholkow; i++) { //przeszukiwanie tablicy, aż znajdziemy 1
        for (int j = 0; j < iloscWierzcholkow; j++) {
            if (istnieniePolaczen[i, j] == 1) { //trafiamy na jakąś
                for (int k = 0; k < iloscWierzcholkow; k++) {
                    if (istnieniePolaczen[k, i] == 1 && istnieniePolaczen[k, j] == 1) { //sprawdzamy czy w jednym wierszu dla obu kolumn są jedynki
                        iloscTrojkatow++;
                    }
                }
            }
        }
    }
    return iloscTrojkatow / 6; //zliczy każdy trójkąt 3! razy
}

void uzupelnianieIstniejacychPolaczen(int iloscWierzcholkow, int[,] istnieniePolaczen, int[,] polaczenia) {
    for (int i = 0; i < iloscWierzcholkow; i++) {
        for (int j = 0; j < iloscWierzcholkow; j++) {
            istnieniePolaczen[i, j] = 0;
        }
    }
    for (int i = 0; i < maxPolaczen(iloscWierzcholkow); i++) { //uzupełnianie jej
        if (polaczenia[i, 2] == 1) {
            istnieniePolaczen[polaczenia[i, 0] - 1, polaczenia[i, 1] - 1] = 1;
            istnieniePolaczen[polaczenia[i, 1] - 1, polaczenia[i, 0] - 1] = 1;
        }
    }
}

int iloscWierzcholkow = 5,
    waga_min = 1,
    waga_max = 10;
double szansa = 0.5;

int[,] polaczenia = new int[maxPolaczen(iloscWierzcholkow), 4];

wypelnij(polaczenia, iloscWierzcholkow);
stworz(polaczenia, maxPolaczen(iloscWierzcholkow), szansa, waga_min, waga_max);

// x, y, czyJestPołączenie (1/-1), waga
for (int i = 0; i < maxPolaczen(iloscWierzcholkow); i++) {
    if (polaczenia[i, 2] == 1) {
        for (int j = 0; j < 4; j++) {
            Console.Write(polaczenia[i, j] + " ");
        }
        Console.WriteLine();
    }
}

int [,] istnieniePolaczen = new int[iloscWierzcholkow, iloscWierzcholkow]; 
//-------------------------------------------------------------------------------------------START
uzupelnianieIstniejacychPolaczen(iloscWierzcholkow, istnieniePolaczen, polaczenia);
bool[] sprawdzoneWierzcholki = new bool[iloscWierzcholkow];
for(int i = 0; i < sprawdzoneWierzcholki.Length; i++) {
    sprawdzoneWierzcholki[i] = false;
}
int[,] wierzcholkiDoSprawdzenia = new int[2, iloscWierzcholkow*iloscWierzcholkow];
for( int i = 0;i < 2;i++) {
    for (int j = 0; j < iloscWierzcholkow*iloscWierzcholkow; j++) {
        wierzcholkiDoSprawdzenia[i,j] = -1;
    }
}
bool warunekZakonczenia = true;
int ileWierzcholkowWystapilo = 0;
int gdzieWpisacNowe = 0; 
int ktoraSprawdzamy = 0;
int kolumnaCzyWiersz = 0; //0 - kolumna, 1 - wiersz
for(int i = 0; i < iloscWierzcholkow; i++) {
    if(istnieniePolaczen[0,i] == 1) {
        wierzcholkiDoSprawdzenia[0, gdzieWpisacNowe] = 0;
        wierzcholkiDoSprawdzenia[1, gdzieWpisacNowe] = i;
        gdzieWpisacNowe++;
    }
}
for(int i = 0; i < 2; i++) {
    for (int j = 0; j < iloscWierzcholkow * iloscWierzcholkow; j++) {
        if (wierzcholkiDoSprawdzenia[i, j] != -1) {
            sprawdzoneWierzcholki[wierzcholkiDoSprawdzenia[i, j]] = true;
        }
    }
}

do {
    if (kolumnaCzyWiersz == 0) {
        for (int i = 0; i < iloscWierzcholkow; i++) { 
            if(istnieniePolaczen[i, ktoraSprawdzamy] == 1) { 
                wierzcholkiDoSprawdzenia[0, gdzieWpisacNowe] = 0;
                wierzcholkiDoSprawdzenia[1, gdzieWpisacNowe] = i;
                gdzieWpisacNowe++;
            }
        }
        kolumnaCzyWiersz = 1; 
    }
    else {
        for (int i = 0; i < iloscWierzcholkow; i++) {
            if (istnieniePolaczen[ktoraSprawdzamy, i] == 1) { //przy nieprawidlowym twierdzi, że wychodze poza zakres
                wierzcholkiDoSprawdzenia[0, gdzieWpisacNowe] = 0;
                wierzcholkiDoSprawdzenia[1, gdzieWpisacNowe] = i;
                gdzieWpisacNowe++;
            }
        }
        kolumnaCzyWiersz = 0;
    }
    for (int i = 0; i < 2; i++) {
        for (int j = 0; j < iloscWierzcholkow * iloscWierzcholkow; j++) {
            if (wierzcholkiDoSprawdzenia[i, j] != -1) {
                sprawdzoneWierzcholki[wierzcholkiDoSprawdzenia[i, j]] = true;
            }
        }
    }
    ktoraSprawdzamy++;
    for (int i = 0; i < iloscWierzcholkow; i++) {
        if (sprawdzoneWierzcholki[i] == true) {
            ileWierzcholkowWystapilo++;
        }
    }
    if (ileWierzcholkowWystapilo == iloscWierzcholkow) {
        warunekZakonczenia = false;
    }
    else {
        ileWierzcholkowWystapilo = 0;
    }
    if(wierzcholkiDoSprawdzenia[0,ktoraSprawdzamy] == -1) {
        warunekZakonczenia = false;
    }
} while(warunekZakonczenia==true);
if(ileWierzcholkowWystapilo==iloscWierzcholkow) {
    Console.WriteLine("jest git");
}
else {
    Console.WriteLine("graf is zepsuted");
}
//--------------------------------------------------------------------------------------KONIEC
uzupelnianieIstniejacychPolaczen(iloscWierzcholkow, istnieniePolaczen, polaczenia);
Console.WriteLine($"ilość trójkątów = {zliczanieTrojkatow(istnieniePolaczen, iloscWierzcholkow)}");
