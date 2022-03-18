namespace MD_graf_gui {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.wierzcholkiInput = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.szansaInput = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.wagaMINInput = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.wagaMAXInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dawaj nowe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(1121, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mDown);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mMove);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mUp);
            // 
            // wierzcholkiInput
            // 
            this.wierzcholkiInput.Location = new System.Drawing.Point(108, 42);
            this.wierzcholkiInput.Name = "wierzcholkiInput";
            this.wierzcholkiInput.Size = new System.Drawing.Size(41, 23);
            this.wierzcholkiInput.TabIndex = 2;
            this.wierzcholkiInput.Text = "5";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(12, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Wierzchołki";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(12, 70);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Szansa";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // szansaInput
            // 
            this.szansaInput.Location = new System.Drawing.Point(108, 71);
            this.szansaInput.Name = "szansaInput";
            this.szansaInput.Size = new System.Drawing.Size(41, 23);
            this.szansaInput.TabIndex = 4;
            this.szansaInput.Text = "0,5";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(12, 99);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Waga MIN";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // wagaMINInput
            // 
            this.wagaMINInput.Location = new System.Drawing.Point(108, 100);
            this.wagaMINInput.Name = "wagaMINInput";
            this.wagaMINInput.Size = new System.Drawing.Size(41, 23);
            this.wagaMINInput.TabIndex = 6;
            this.wagaMINInput.Text = "1";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(12, 128);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Waga MAX";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // wagaMAXInput
            // 
            this.wagaMAXInput.Location = new System.Drawing.Point(108, 129);
            this.wagaMAXInput.Name = "wagaMAXInput";
            this.wagaMAXInput.Size = new System.Drawing.Size(41, 23);
            this.wagaMAXInput.TabIndex = 8;
            this.wagaMAXInput.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.wagaMAXInput);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.wagaMINInput);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.szansaInput);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.wierzcholkiInput);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Matematyka Dyskrenta | Rysowanie Grafów";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox wierzcholkiInput;
        private Button button3;
        private Button button4;
        private TextBox szansaInput;
        private Button button5;
        private TextBox wagaMINInput;
        private Button button6;
        private TextBox wagaMAXInput;
    }
}