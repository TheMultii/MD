namespace MD_graf_gui_2 {
    public class GraphGenerator {
        public int getRandomInt(int minimum, int maximum) => new Random().Next(minimum, maximum);

        private int maxPolaczen(int liczbaWierzcholkow) => (liczbaWierzcholkow * (liczbaWierzcholkow - 1)) / 2; //wzór na ilość krawędzi grafu pełnego

        private void wypelnij(int[,] p, int n) {
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

        private void stworz(int[,] p, int n, double szansa, int waga_min, int waga_max) {
            for (int i = 0; i < n; i++) {
                double random = getRandomInt(0, 100) / 100.0;
                p[i, 2] = szansa >= random ? 1 : -1; // 1 - połączenie, -1 - brak
                p[i, 3] = getRandomInt(waga_min, waga_max);
            }
        }

        private int[,]? zliczanieTrojkatow(int[,]? istnieniePolaczen, int iloscWierzcholkow, int[,]? polaczenia) {
            if (istnieniePolaczen == null || polaczenia == null) {
                return null;
            }
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
            iloscTrojkatow = iloscTrojkatow / 6;
            int[,] trojkaty = new int[iloscTrojkatow, 4];
            int[] znalezionyTrojkat = new int[3];
            int aktualnyWiersz = 0;
            for (int i = 0; i < iloscWierzcholkow; i++) { //przeszukiwanie tablicy, aż znajdziemy 1
                for (int j = 0; j < iloscWierzcholkow; j++) {
                    if (istnieniePolaczen[i, j] == 1) { //trafiamy na jakąś
                        for (int k = 0; k < iloscWierzcholkow; k++) {
                            if (istnieniePolaczen[k, i] == 1 && istnieniePolaczen[k, j] == 1) { //sprawdzamy czy w jednym wierszu dla obu kolumn są jedynki
                                znalezionyTrojkat[0] = i; //zapisujemy wierzcholki znalezionego trojkata
                                znalezionyTrojkat[1] = j;
                                znalezionyTrojkat[2] = k;
                                int n = 3;
                                do { //sortujemy wierzcholki
                                    for (int l = 0; l < n - 1; l++) {
                                        if (znalezionyTrojkat[l] > znalezionyTrojkat[l + 1]) {
                                            int tmp = znalezionyTrojkat[l];
                                            znalezionyTrojkat[l] = znalezionyTrojkat[l + 1];
                                            znalezionyTrojkat[l + 1] = tmp;
                                        }
                                    }
                                    n--;
                                }
                                while (n > 1);
                                int licznikPowtorzen = 0;
                                for (int l = 0; l < iloscTrojkatow; l++) { //sprawdzamy, czy nie mamy już takiego trojkata zapisanego
                                    if (trojkaty[l, 0] == znalezionyTrojkat[0] && trojkaty[l, 1] == znalezionyTrojkat[1] && trojkaty[l, 2] == znalezionyTrojkat[2]) {
                                        licznikPowtorzen++;
                                    }
                                }
                                if (licznikPowtorzen == 0) {
                                    trojkaty[aktualnyWiersz, 0] = znalezionyTrojkat[0];
                                    trojkaty[aktualnyWiersz, 1] = znalezionyTrojkat[1];
                                    trojkaty[aktualnyWiersz, 2] = znalezionyTrojkat[2];
                                    int waga = 0;
                                    for (int l = 0; l < maxPolaczen(iloscWierzcholkow); l++) {
                                        if (polaczenia[l, 0] - 1 == trojkaty[aktualnyWiersz, 0] && polaczenia[l, 1] - 1 == trojkaty[aktualnyWiersz, 1]) {
                                            waga = waga + polaczenia[l, 3];
                                        }
                                        if (polaczenia[l, 0] - 1 == trojkaty[aktualnyWiersz, 0] && polaczenia[l, 1] - 1 == trojkaty[aktualnyWiersz, 2]) {
                                            waga = waga + polaczenia[l, 3];
                                        }
                                        if (polaczenia[l, 0] - 1 == trojkaty[aktualnyWiersz, 1] && polaczenia[l, 1] - 1 == trojkaty[aktualnyWiersz, 2]) {
                                            waga = waga + polaczenia[l, 3];
                                        }
                                    }
                                    trojkaty[aktualnyWiersz, 3] = waga;
                                    aktualnyWiersz++;
                                }
                            }
                        }
                    }
                }
            }
            return trojkaty;
        }

        private List<List<int>> zliczanieKwadratow(int[,]? graph) {
            List<List<int>> cykle = new();
            List<string> sorted_non_duplicates = new();
            if (graph != null) {
                for (int i = 0; i < iloscWierzcholkow; i++) {
                    for (int j = 0; j < iloscWierzcholkow; j++) {
                        if (i != j && graph[i, j] == 1) {
                            for (int k = 0; k < iloscWierzcholkow; k++) {
                                if (i != k && j != k && graph[j, k] == 1) {
                                    for (int l = 0; l < iloscWierzcholkow; l++) {
                                        if (i != l && j != l && k != l && graph[k, l] == 1 && graph[l, i] == 1) {
                                            List<int> cykl = new(),
                                                      sort_temp;
                                            cykl.Add(i);
                                            cykl.Add(j);
                                            cykl.Add(k);
                                            cykl.Add(l);
                                            sort_temp = new(cykl);
                                            cykl.Add(appendSquareWage(polaczenia,i, j, k, l));
                                            sort_temp.Sort();

                                            System.Text.StringBuilder temp = new();
                                            foreach (var item in sort_temp) {
                                                temp.Append($"{item},");
                                            }
                                            if (!sorted_non_duplicates.Contains(temp.ToString())) {
                                                sorted_non_duplicates.Add(temp.ToString());
                                                cykle.Add(cykl);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return cykle;
        }

        private int appendSquareWage(int[,]? polaczenia, int i, int j, int k, int l) {
            int wage = 0;
            if (polaczenia != null) {
                for (int a = 0; a < polaczenia.GetLength(0); a++) {
                    if ((polaczenia[a, 0] == i + 1 && polaczenia[a, 1] == j + 1) || (polaczenia[a, 0] == j + 1 && polaczenia[a, 1] == i + 1)) {
                        wage += polaczenia[a, 3];
                    }
                    if ((polaczenia[a, 0] == j + 1 && polaczenia[a, 1] == k + 1) || (polaczenia[a, 0] == k + 1 && polaczenia[a, 1] == j + 1)) {
                        wage += polaczenia[a, 3];
                    }
                    if ((polaczenia[a, 0] == k + 1 && polaczenia[a, 1] == l + 1) || (polaczenia[a, 0] == l + 1 && polaczenia[a, 1] == k + 1)) {
                        wage += polaczenia[a, 3];
                    }
                    if ((polaczenia[a, 0] == l + 1 && polaczenia[a, 1] == i + 1) || (polaczenia[a, 0] == i + 1 && polaczenia[a, 1] == l + 1)) {
                        wage += polaczenia[a, 3];
                    }
                }
            }
            return wage;
        }

        private void uzupelnianieIstniejacychPolaczen(int iloscWierzcholkow, int[,] istnieniePolaczen, int[,] polaczenia) {
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

        private bool sprawdzPoprawnoscGrafu(int iloscWierzcholkow, int[,] istnieniePolaczen, int[,] polaczenia) {
            int ileWierzcholkowWystapilo = 0;
            try {
                uzupelnianieIstniejacychPolaczen(iloscWierzcholkow, istnieniePolaczen, polaczenia);
                int[,] wierzcholkiDoSprawdzenia = new int[2, iloscWierzcholkow * iloscWierzcholkow];
                for (int i = 0; i < 2; i++) {
                    for (int j = 0; j < iloscWierzcholkow * iloscWierzcholkow; j++) {
                        wierzcholkiDoSprawdzenia[i, j] = -1;
                    }
                }
                bool warunekZakonczenia = true;
                int gdzieWpisacKolejnyWierzcholek = 0;
                int obecnieSprawdzanyWierzcholek = 0;
                bool[] sprawdzoneWierzcholki = new bool[iloscWierzcholkow];
                for (int i = 0; i < iloscWierzcholkow; i++) {
                    sprawdzoneWierzcholki[i] = false;
                }
                for (int i = 0; i < iloscWierzcholkow; i++) {
                    if (istnieniePolaczen[0, i] == 1) {
                        wierzcholkiDoSprawdzenia[0, gdzieWpisacKolejnyWierzcholek] = i;
                        wierzcholkiDoSprawdzenia[1, gdzieWpisacKolejnyWierzcholek] = 0;
                        gdzieWpisacKolejnyWierzcholek++;
                    }
                }
                if (wierzcholkiDoSprawdzenia[0, obecnieSprawdzanyWierzcholek] != -1) {
                    for (int i = obecnieSprawdzanyWierzcholek; i < iloscWierzcholkow * iloscWierzcholkow; i++) {
                        if (wierzcholkiDoSprawdzenia[0, i] != -1) {
                            sprawdzoneWierzcholki[wierzcholkiDoSprawdzenia[0, i]] = true;
                            sprawdzoneWierzcholki[wierzcholkiDoSprawdzenia[1, i]] = true;
                        }
                    }
                    for (int i = 0; i < iloscWierzcholkow; i++) {
                        if (sprawdzoneWierzcholki[i] == true) {
                            ileWierzcholkowWystapilo++;
                        }
                    }
                    if (ileWierzcholkowWystapilo == iloscWierzcholkow) {
                        warunekZakonczenia = false;
                    } else {
                        ileWierzcholkowWystapilo = 0;
                    }
                } else {
                    warunekZakonczenia = false;
                }
                int kolumnaCzyWiersz = 0;
                while (warunekZakonczenia == true) {
                    istnieniePolaczen[wierzcholkiDoSprawdzenia[1, obecnieSprawdzanyWierzcholek], wierzcholkiDoSprawdzenia[0, obecnieSprawdzanyWierzcholek]] = 0;
                    if (kolumnaCzyWiersz == 0) {
                        for (int i = 0; i < iloscWierzcholkow; i++) {
                            if (istnieniePolaczen[i, wierzcholkiDoSprawdzenia[0, obecnieSprawdzanyWierzcholek]] == 1) {
                                wierzcholkiDoSprawdzenia[0, gdzieWpisacKolejnyWierzcholek] = wierzcholkiDoSprawdzenia[0, obecnieSprawdzanyWierzcholek];
                                wierzcholkiDoSprawdzenia[1, gdzieWpisacKolejnyWierzcholek] = i;
                                gdzieWpisacKolejnyWierzcholek++;
                            }
                        }
                        kolumnaCzyWiersz = 1;
                    } else {
                        for (int i = 0; i < iloscWierzcholkow; i++) {
                            if (istnieniePolaczen[wierzcholkiDoSprawdzenia[0, obecnieSprawdzanyWierzcholek], i] == 1) {
                                wierzcholkiDoSprawdzenia[0, gdzieWpisacKolejnyWierzcholek] = i;
                                wierzcholkiDoSprawdzenia[1, gdzieWpisacKolejnyWierzcholek] = wierzcholkiDoSprawdzenia[0, obecnieSprawdzanyWierzcholek];
                                gdzieWpisacKolejnyWierzcholek++;
                            }
                        }
                        kolumnaCzyWiersz = 0;
                    }
                    obecnieSprawdzanyWierzcholek++;
                    if (wierzcholkiDoSprawdzenia[0, obecnieSprawdzanyWierzcholek] != -1) {
                        for (int i = 0; i < iloscWierzcholkow * iloscWierzcholkow; i++) {
                            if (wierzcholkiDoSprawdzenia[0, i] != -1) {
                                sprawdzoneWierzcholki[wierzcholkiDoSprawdzenia[0, i]] = true;
                                sprawdzoneWierzcholki[wierzcholkiDoSprawdzenia[1, i]] = true;
                            }
                        }
                        for (int i = 0; i < iloscWierzcholkow; i++) {
                            if (sprawdzoneWierzcholki[i] == true) {
                                ileWierzcholkowWystapilo++;
                            }
                        }
                        if (ileWierzcholkowWystapilo == iloscWierzcholkow) {
                            warunekZakonczenia = false;
                        } else {
                            ileWierzcholkowWystapilo = 0;
                        }
                    } else {
                        warunekZakonczenia = false;
                    }
                }
            } catch (Exception) {
                return false;
            }

            return ileWierzcholkowWystapilo == iloscWierzcholkow;
        }

        //=================//

        internal int[,]? istnieniePolaczen,
                        polaczenia;
        private int iloscWierzcholkow;
        public int[,] stworzGraf(int iloscWierzcholkow = 5, int waga_min = 1, int waga_max = 10, double szansa = 0.5) {

            this.iloscWierzcholkow = iloscWierzcholkow;

            do {
                polaczenia = new int[maxPolaczen(iloscWierzcholkow), 4];

                wypelnij(polaczenia, iloscWierzcholkow);
                stworz(polaczenia, maxPolaczen(iloscWierzcholkow), szansa, waga_min, waga_max);

                istnieniePolaczen = new int[iloscWierzcholkow, iloscWierzcholkow];
            } while (!sprawdzPoprawnoscGrafu(iloscWierzcholkow, istnieniePolaczen, polaczenia));

            uzupelnianieIstniejacychPolaczen(iloscWierzcholkow, istnieniePolaczen, polaczenia);

            return polaczenia;
        }
        public int liczbaTrojkatow() {
            int[,]? temp = zliczanieTrojkatow(istnieniePolaczen, iloscWierzcholkow, polaczenia);
            return temp == null ? 0 : temp.GetLength(0);
        }
        public int[,]? trojkatyPolaczenia() {
            int[,]? temp = zliczanieTrojkatow(istnieniePolaczen, iloscWierzcholkow, polaczenia);
            return temp;
        }

        public int liczbaKwadratow() {
            List<List<int>>? temp = zliczanieKwadratow(istnieniePolaczen);
            return temp == null ? 0 : temp.Count();
        }


        public List<List<int>>? kwadratyPolaczenia() => zliczanieKwadratow(istnieniePolaczen);

        public double gestosc() {
            int iloscKrawedzi = 0;
            if (polaczenia != null) {
                for (int i = 0; i < polaczenia.GetLength(0); i++) {
                    if (polaczenia[i, 2] != -1) {
                        iloscKrawedzi++;
                    }
                }
            }
            return iloscWierzcholkow / (iloscKrawedzi * (iloscKrawedzi - 1) / 2.0);
        }
    }
}
