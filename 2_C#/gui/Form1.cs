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
                    if(drawWeight) {
                        g.DrawString(polaczenia[i, 3].ToString(), new Font("Arial", 16, isBold ? FontStyle.Bold : FontStyle.Regular), new SolidBrush(Color.Black), new Point(((start.X + end.X) / 2), ((start.Y + end.Y) / 2)));
                    }
                }
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

                if(wierzcholki > 300 && !wasWarningAccepted) {
                    var result = MessageBox.Show($"Próbujesz wygenerowaæ graf zawieraj¹cy du¿¹ liczbê ({wierzcholki}) wierzcho³ków.\nGenerowanie takiego grafu mo¿e byæ zasobo¿erne, co za tym idzie mo¿e trwaæ doœæ d³ugo. Czy na pewno chcesz kontynuowaæ?", "Potrzebne potwierdzenie", MessageBoxButtons.YesNo);
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
                MessageBox.Show("Podane wartoœci s¹ b³êdne", "Jak zawsze coœ posz³o nie tak", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isMouseDown = false,
                     isBold = false,
                     drawWeight = true,
                     wasWarningAccepted = false;
        private int pointIndexBeingMoved = -1;
        private string preString = "";

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
    }
}