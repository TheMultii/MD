namespace MD_graf_gui {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        int GetRandomInt(int minimum, int maximum) {
            Random r = new();
            return r.Next(minimum, maximum);
        }

        private Point[] distinctPoints;
        private Color[] colors;
        private int[,] polaczenia;
        private int wierzcholki;
        private int[,]? trojkatyPolaczenia;
        private List<List<int>>? kwadratyPolaczenia;

        private void drawPoints(int iloscWierzcholkow = 5, int waga_min = 1, int waga_max = 10, double szansa = 0.5) {
            GraphGenerator graphGenerator = new();
            polaczenia = graphGenerator.stworzGraf(iloscWierzcholkow, waga_min, waga_max, szansa);
            distinctPoints = new Point[iloscWierzcholkow];
            for (int i = 0; i < iloscWierzcholkow; i++) {
                distinctPoints[i] = new Point(GetRandomInt(40, this.Width - 40), GetRandomInt(50, this.Height - 50)); //pozycje punktów
            }

            colors = new Color[polaczenia.Length];
            for (int i = 0; i < polaczenia.Length; i++) {
                colors[i] = Color.FromArgb(GetRandomInt(0, 200), GetRandomInt(0, 200), GetRandomInt(0, 200));
            }

            trianglesCountTextBox.Text = graphGenerator.liczbaTrojkatow().ToString();
            wierzcholki = iloscWierzcholkow;
            gestoscTextBox.Text = graphGenerator.gestosc().ToString("0.###");
            trojkatyPolaczenia = graphGenerator.trojkatyPolaczenia();
            kwadratyPolaczenia = graphGenerator.kwadratyPolaczenia();
            squaresCountTextBox.Text = graphGenerator.liczbaKwadratow().ToString();
        }

        private string getExcelColumnName(int columnNumber) {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0) {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private void Literowanie(Graphics g) {
            for (int i = 0; i < wierzcholki; i++) {
                string text = getExcelColumnName(i + 1);
                Point punkt = distinctPoints[i];
                g.DrawString(text, new Font("Arial", 16, isBold ? FontStyle.Bold : FontStyle.Regular), new SolidBrush(letterColor), new Point(punkt.X - 10 - (text.Length == 1 ? 0 : (text.Length - 1) * 8), punkt.Y - 30));
            }
        }


        private void drawGraph() {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < polaczenia.GetLength(0); i++) {
                if (polaczenia[i, 2] != -1) {
                    Point start = distinctPoints[polaczenia[i, 0] - 1];
                    Point end = distinctPoints[polaczenia[i, 1] - 1];
                    g.DrawLine(new(colors[i], 4), start, end);

                    //wagi
                    if (drawWeight) {
                        g.DrawString(polaczenia[i, 3].ToString(), new Font("Arial", 16, isBold ? FontStyle.Bold : FontStyle.Regular), new SolidBrush(Color.Black), new Point(((start.X + end.X) / 2), ((start.Y + end.Y) / 2)));
                    }
                }
            }


            if (drawLiterki) {
                Literowanie(g);
            }

            for (int i = 0; i < distinctPoints.Length; i++) {
                g.FillEllipse(new SolidBrush(Color.Black), distinctPoints[i].X - 5, distinctPoints[i].Y - 5, 10, 10);
            }
        }

        private void Form1_Shown(object sender, EventArgs e) {
            drawPoints();
            drawGraph();
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                int wierzcholki = int.Parse(wierzcholkiInput.Text),
                waga_min = int.Parse(wagaMINInput.Text),
                waga_max = int.Parse(wagaMAXInput.Text);
                double szansa = double.Parse(szansaInput.Text);

                if (waga_min > waga_max || wierzcholki <= 0 || szansa <= 0 || szansa > 1 || waga_min <= 0) {
                    throw new Exception();
                }

                if (wierzcholki > 300 && !wasWarningAccepted) {
                    var result = MessageBox.Show($"Próbujesz wygenerować graf zawierający dużą liczbę ({wierzcholki}) wierzchołków.\nGenerowanie takiego grafu może być zasobożerne, co za tym idzie może trwać dość długo. Czy na pewno chcesz kontynuować?", "Potrzebne potwierdzenie", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        wasWarningAccepted = true;
                    } else {
                        return;
                    }
                }

                if (szansa <= 0.009 && !wasWarningAccepted) {
                    var result = MessageBox.Show($"Wprowadzona wartość szansy może sprawić, że komputer utworzy związki zawodowe i odmówi współpracy. Czy na pewno chcesz kontynuować?", "Potrzebne potwierdzenie", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        wasWarningAccepted = true;
                    } else {
                        return;
                    }
                }

                drawPoints(wierzcholki, waga_min, waga_max, szansa);
                drawGraph();
            } catch (Exception) {
                wierzcholkiInput.Text = "5";
                wagaMINInput.Text = "1";
                wagaMAXInput.Text = "10";
                szansaInput.Text = "0,5";
                MessageBox.Show("Podane wartości są błędne", "Jak zawsze coś poszło nie tak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isMouseDown = false,
                     isBold = false,
                     drawWeight = true,
                     drawLiterki = true,
                     wasWarningAccepted = false;
        private int pointIndexBeingMoved = -1;
        private string preString = "";
        private Color letterColor = Color.FromArgb(128, 0, 255);

        private void mMove(object sender, MouseEventArgs e) {
            if (isMouseDown) {
                button2.Text = $"{preString}{e.X}, {e.Y}";
            } else {
                button2.Text = $"{preString}-, -";
            }
        }

        private void mUp(object sender, MouseEventArgs e) {
            if (isMouseDown && pointIndexBeingMoved != -1) {
                distinctPoints[pointIndexBeingMoved] = new(e.X, e.Y);
                pointIndexBeingMoved = -1;
                drawGraph();
            }
            isMouseDown = false;
        }

        private void colorButton_Click(object sender, EventArgs e) {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                letterColor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                drawGraph();
            }
        }

        public void printRaport(int[] dist, int n, int src, int[,] graph) {
            DateTime thisDay = DateTime.Now;
            string dataString = $"{thisDay.ToString("d")}_{thisDay.ToString("HH")}_{thisDay.ToString("mm")}_{thisDay.ToString("ss")}";
            using StreamWriter file = new($"Raport_graf_{wierzcholki}_wierzcholkow_data_{dataString}.txt");
            file.WriteLineAsync("Raport wyrysowanego grafu");
            file.WriteLineAsync($"Ilość wierzchołków: {wierzcholki}");
            file.WriteLineAsync($"Szansa na wygenerowanie krawędzi: {szansaInput.Text}");
            file.WriteLineAsync($"Zakres wag: {wagaMINInput.Text}-{wagaMAXInput.Text}");
            file.WriteLineAsync($"Liczba trójkątów: {trianglesCountTextBox.Text}");
            file.WriteLineAsync($"Liczba kwadratów: {squaresCountTextBox.Text}");



            file.WriteLineAsync("Wierzchołek     Dystans z wierzchołka - " + getExcelColumnName(src + 1) + ":\n");

            for (int i = 0; i < wierzcholki; i++)
                if (i != src)
                    file.WriteLineAsync(getExcelColumnName(i + 1) + " \t\t " + dist[i] + "\n");
            file.WriteLineAsync();



            file.WriteLineAsync("Połączenie wierzchołków   Waga \n");
            string textWagi = "";
            for (int i = 0; i < polaczenia.GetLength(0); i++) {

                textWagi += getExcelColumnName(polaczenia[i, 0]) + " z " + getExcelColumnName(polaczenia[i, 1]) + " \t\t\t ";
                if (polaczenia[i, 2] == 1) {
                    textWagi += polaczenia[i, 3] + "\n\n";
                } else {

                    textWagi += "brak połączenia\n\n";

                }
            }
            file.WriteLineAsync(textWagi);

            file.WriteLineAsync();

            int trojkatyPolaczeniaDlugosc = trojkatyPolaczenia.GetLength(0);
            if (trojkatyPolaczeniaDlugosc > 0) {
                file.WriteLineAsync("Trójkąty \tWaga \n");
                string textTrojkaty = "";
                int test = trojkatyPolaczenia.GetLength(0);
                for (int i = 0; i < trojkatyPolaczenia.GetLength(0); i++) {

                    textTrojkaty += "(" + getExcelColumnName(trojkatyPolaczenia[i, 0] + 1) + ", " + getExcelColumnName(trojkatyPolaczenia[i, 1] + 1) + ", " + getExcelColumnName(trojkatyPolaczenia[i, 2] + 1) + ") \t" + trojkatyPolaczenia[i, 3] + "\n\n";
                }
                file.WriteLineAsync(textTrojkaty);
            }

            file.WriteLineAsync();
            if (Convert.ToInt32(squaresCountTextBox.Text) >= 1 && kwadratyPolaczenia != null) {
                file.WriteLineAsync("Kwadraty \n");
                string textKwadraty = "";
                for (int i = 0; i < kwadratyPolaczenia.Count; i++) {
                    textKwadraty += $"({getExcelColumnName(kwadratyPolaczenia[i][0] + 1)}, {getExcelColumnName(kwadratyPolaczenia[i][1] + 1)}, {getExcelColumnName(kwadratyPolaczenia[i][2] + 1)}, {getExcelColumnName(kwadratyPolaczenia[i][3] + 1)})\n\n";
                }
                file.WriteLineAsync(textKwadraty);
            }

            MessageBox.Show("Wygenerowano raport, w folderze aplikacji", "Raport info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public int minDistance(int[] dist, bool[] sptSet) {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < wierzcholki; v++)
                if (sptSet[v] == false && dist[v] <= min) {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }
        public void dijkstra(int[,] graph, int src) {
            int[] dist = new int[wierzcholki];
            bool[] sptSet = new bool[wierzcholki];

            for (int i = 0; i < wierzcholki; i++) {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < wierzcholki - 1; count++) {
                int u = minDistance(dist, sptSet);

                sptSet[u] = true;

                for (int v = 0; v < wierzcholki; v++)
                    if (!sptSet[v] && graph[u, v] != 0 &&
                        dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            printRaport(dist, wierzcholki, src, graph);
        }
        public int charValue(char x) {
            int xToNumber = (int)x;
            if (xToNumber >= 97 && xToNumber <= 122) {
                xToNumber -= 97;
            } else if (xToNumber >= 65 && x <= 90) {
                xToNumber -= 65;
            }

            return xToNumber;
        }
        private int stringToInt(string getName) {
            string vertixName = getName;
            int vertixNameLength = vertixName.Length;
            int[] vertixNameTabInt = new int[vertixName.Length];
            for (int i = 0; i < vertixNameLength; i++) {
                vertixNameTabInt[i] = charValue(vertixName[i]);

            }
            int vertixNumber = 0;
            for (int i = 0; i < vertixNameLength; i++) {
                vertixNumber += vertixNameTabInt[i];
                vertixNumber += 1;
                if (i != vertixNameLength - 1) vertixNumber *= 26;
            }

            return vertixNumber - 1;
        }
        private void najkrotszaDrogaButton_Click(object sender, EventArgs e) {

            try {
                if (najkrotszaDrogaInput.Text != "") {
                    int wierzcholekInt = stringToInt(najkrotszaDrogaInput.Text);

                    if (wierzcholekInt >= 0 && wierzcholekInt <= wierzcholki) {
                        int[,] graph = new int[wierzcholki, wierzcholki];


                        for (int i = 0; i < wierzcholki; i++) {
                            for (int j = 0; j < wierzcholki; j++) {
                                graph[i, j] = 0;
                            }
                        }
                        for (int r = 0; r < polaczenia.GetLength(0); r++) {
                            if (polaczenia[r, 2] == 1) {

                                graph[polaczenia[r, 0] - 1, polaczenia[r, 1] - 1] = polaczenia[r, 3];
                                graph[polaczenia[r, 1] - 1, polaczenia[r, 0] - 1] = polaczenia[r, 3];
                            };
                        }

                        dijkstra(graph, wierzcholekInt);

                    } else {
                        throw new Exception();
                    }
                } else {
                    throw new Exception();
                }
            } catch (Exception) {
                MessageBox.Show("Podaj wierzchołek (string/char)", "Jak zawsze coś poszło nie tak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void mDown(object sender, MouseEventArgs e) {
            bool isFound = false;
            for (int i = 0; i < distinctPoints.Length; i++) {
                Point pt = distinctPoints[i];
                if (e.X - 10 <= pt.X && pt.X <= e.X + 10 && e.Y - 10 <= pt.Y && pt.Y <= e.Y + 10) {
                    pointIndexBeingMoved = i;
                    preString = $"({pt.X}, {pt.Y}) ";
                    isFound = true;
                    break;
                }
            }

            //debug
            if (!isFound) {
                preString = "";
            }
            //debug

            isMouseDown = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            isBold = boldCheckBox.Checked;
            drawGraph();
        }

        private void weightCheckBox_CheckedChanged(object sender, EventArgs e) {
            drawWeight = weightCheckBox.Checked;
            drawGraph();
        }

        private void letterCheckBox_CheckedChanged(object sender, EventArgs e) {
            drawLiterki = lettersCheckBox.Checked;
            drawGraph();
        }
    }
}
