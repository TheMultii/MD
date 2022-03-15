namespace MD_graf_gui {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        int GetRandomInt(int minimum, int maximum) {
            Random r = new();
            return r.Next(minimum, maximum);
        }

        private void drawFC(int kreski = 5) {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            Point pX = new(GetRandomInt(0, this.Width - 100), GetRandomInt(0, this.Height - 100)),
                pY = new(GetRandomInt(0, this.Width - 100), GetRandomInt(0, this.Height - 100));

            for (int i = 0; i < kreski; i++) {
                g.FillEllipse(new SolidBrush(Color.Black), pX.X - 5, pX.Y - 5, 10, 10);
                g.DrawLine(new(Color.FromArgb(GetRandomInt(0, 200), GetRandomInt(0, 200), GetRandomInt(0, 200)), 4), pX, pY);
                if (i + 1 == kreski) {
                    g.FillEllipse(new SolidBrush(Color.Black), pY.X - 5, pY.Y - 5, 10, 10);
                } else {
                    pX = pY;
                    pY = new(GetRandomInt(0, this.Width - 100), GetRandomInt(0, this.Height - 100));
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e) {
            drawFC(5);
        }

        private void button1_Click(object sender, EventArgs e) {
            drawFC(GetRandomInt(5,10));
        }
    }
}