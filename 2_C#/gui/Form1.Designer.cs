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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.boldCheckBox = new System.Windows.Forms.CheckBox();
            this.weightCheckBox = new System.Windows.Forms.CheckBox();
            this.trianglesCountButton = new System.Windows.Forms.Button();
            this.trianglesCountTextBox = new System.Windows.Forms.TextBox();
            this.squaresCountButton = new System.Windows.Forms.Button();
            this.squaresCountTextBox = new System.Windows.Forms.TextBox();
            this.lettersCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mDown);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mMove);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mUp);
            // 
            // wierzcholkiInput
            // 
            resources.ApplyResources(this.wierzcholkiInput, "wierzcholkiInput");
            this.wierzcholkiInput.Name = "wierzcholkiInput";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // szansaInput
            // 
            resources.ApplyResources(this.szansaInput, "szansaInput");
            this.szansaInput.Name = "szansaInput";
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // wagaMINInput
            // 
            resources.ApplyResources(this.wagaMINInput, "wagaMINInput");
            this.wagaMINInput.Name = "wagaMINInput";
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // wagaMAXInput
            // 
            resources.ApplyResources(this.wagaMAXInput, "wagaMAXInput");
            this.wagaMAXInput.Name = "wagaMAXInput";
            // 
            // boldCheckBox
            // 
            resources.ApplyResources(this.boldCheckBox, "boldCheckBox");
            this.boldCheckBox.Name = "boldCheckBox";
            this.boldCheckBox.UseVisualStyleBackColor = true;
            this.boldCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // weightCheckBox
            // 
            resources.ApplyResources(this.weightCheckBox, "weightCheckBox");
            this.weightCheckBox.Checked = true;
            this.weightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.weightCheckBox.Name = "weightCheckBox";
            this.weightCheckBox.UseVisualStyleBackColor = true;
            this.weightCheckBox.CheckedChanged += new System.EventHandler(this.weightCheckBox_CheckedChanged);
            // 
            // trianglesCountButton
            // 
            resources.ApplyResources(this.trianglesCountButton, "trianglesCountButton");
            this.trianglesCountButton.Name = "trianglesCountButton";
            this.trianglesCountButton.UseVisualStyleBackColor = true;
            // 
            // trianglesCountTextBox
            // 
            resources.ApplyResources(this.trianglesCountTextBox, "trianglesCountTextBox");
            this.trianglesCountTextBox.Name = "trianglesCountTextBox";
            // 
            // squaresCountButton
            // 
            resources.ApplyResources(this.squaresCountButton, "squaresCountButton");
            this.squaresCountButton.Name = "squaresCountButton";
            this.squaresCountButton.UseVisualStyleBackColor = true;
            // 
            // squaresCountTextBox
            // 
            resources.ApplyResources(this.squaresCountTextBox, "squaresCountTextBox");
            this.squaresCountTextBox.Name = "squaresCountTextBox";
            // 
            // lettersCheckBox
            // 
            resources.ApplyResources(this.lettersCheckBox, "lettersCheckBox");
            this.lettersCheckBox.Checked = true;
            this.lettersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lettersCheckBox.Name = "lettersCheckBox";
            this.lettersCheckBox.UseVisualStyleBackColor = true;
            this.lettersCheckBox.CheckedChanged += new System.EventHandler(this.letterCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lettersCheckBox);
            this.Controls.Add(this.squaresCountButton);
            this.Controls.Add(this.squaresCountTextBox);
            this.Controls.Add(this.trianglesCountButton);
            this.Controls.Add(this.trianglesCountTextBox);
            this.Controls.Add(this.weightCheckBox);
            this.Controls.Add(this.boldCheckBox);
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
        private CheckBox boldCheckBox;
        private CheckBox weightCheckBox;
        private Button trianglesCountButton;
        private TextBox trianglesCountTextBox;
        private Button squaresCountButton;
        private TextBox squaresCountTextBox;
        private CheckBox lettersCheckBox;
    }
}