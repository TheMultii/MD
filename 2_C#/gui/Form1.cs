namespace MD_graf_gui {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        int GetRandomInt(int minimum, int maximum) {
            Random r = new();
            return r.Next(minimum, maximum);
        }

        private Point[] points;
        private Color[] colors;

        private void drawPoints(int lines = 5) {
            points = new Point[lines];
            colors = new Color[lines];
            for (int i = 0; i < lines; i++) {
                points[i] = new(GetRandomInt(100, this.Width - 100), GetRandomInt(100, this.Height - 100));
                colors[i] = Color.FromArgb(GetRandomInt(0, 200), GetRandomInt(0, 200), GetRandomInt(0, 200));
            }
        }

        private void drawGraph() {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            for (int i = 0; i < points.Length; i++) {
                var pt = points[i];
                
                g.FillEllipse(new SolidBrush(Color.Black), pt.X - 5, pt.Y - 5, 10, 10);
                if(i+1!=points.Length) {
                    g.DrawLine(new(colors[i], 4), pt, points[i+1]);
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e) {
            drawPoints(5);
            drawGraph();
        }

        private void button1_Click(object sender, EventArgs e) {
            drawPoints(GetRandomInt(5,10));
            drawGraph();
        }

        private bool isMouseDown = false;
        private int pointIndexBeingMoved = -1;
        private string preString = "";

        private void mMove(object sender, MouseEventArgs e) {
            if(isMouseDown) {
                button2.Text = $"{preString}{e.X}, {e.Y}";
            } else {
                button2.Text = $"{preString}-, -";
            }
        }

        private void mUp(object sender, MouseEventArgs e) {
            if(isMouseDown && pointIndexBeingMoved != -1) {
                points[pointIndexBeingMoved] = new(e.X, e.Y);
                pointIndexBeingMoved = -1;
                drawGraph();
            }
            isMouseDown = false;
        }

        void mDown(object sender, MouseEventArgs e) {
            bool isFound = false;
            for (int i = 0; i < points.Length; i++) {
                Point pt = points[i];
                if (e.X - 10 <= pt.X && pt.X <= e.X + 10 && e.Y - 10 <= pt.Y && pt.Y <= e.Y + 10) {
                    pointIndexBeingMoved = i;
                    preString = $"({pt.X}, {pt.Y}) ";
                    isFound = true;
                    break;
                }
            }

            //debug
            if(!isFound) {
                preString = "";
            }
            //debug

            isMouseDown = true;
        }
    }
}