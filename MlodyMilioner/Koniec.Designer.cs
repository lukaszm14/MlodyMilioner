namespace MlodyMilioner
{
    partial class Koniec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            KoniecTextBox = new TextBox();
            NowaGra = new Button();
            Zakoncz = new Button();
            Tury = new Label();
            Poziom = new Label();
            LiczbaTur = new Label();
            NazwaPoziomu = new Label();
            Historia = new Button();
            SuspendLayout();
            // 
            // KoniecTextBox
            // 
            KoniecTextBox.BorderStyle = BorderStyle.None;
            KoniecTextBox.Cursor = Cursors.No;
            KoniecTextBox.Enabled = false;
            KoniecTextBox.Font = new Font("Segoe UI", 26F);
            KoniecTextBox.Location = new Point(408, 128);
            KoniecTextBox.Name = "KoniecTextBox";
            KoniecTextBox.ReadOnly = true;
            KoniecTextBox.Size = new Size(456, 58);
            KoniecTextBox.TabIndex = 0;
            KoniecTextBox.Text = "Koniec";
            KoniecTextBox.TextAlign = HorizontalAlignment.Center;
            KoniecTextBox.TextChanged += KoniecTextBox_TextChanged;
            // 
            // NowaGra
            // 
            NowaGra.Font = new Font("Segoe UI", 12F);
            NowaGra.Location = new Point(528, 506);
            NowaGra.Name = "NowaGra";
            NowaGra.Size = new Size(250, 70);
            NowaGra.TabIndex = 1;
            NowaGra.Text = "NowaGra";
            NowaGra.UseVisualStyleBackColor = true;
            NowaGra.Click += NowaGra_Click;
            // 
            // Zakoncz
            // 
            Zakoncz.Font = new Font("Segoe UI", 12F);
            Zakoncz.Location = new Point(528, 596);
            Zakoncz.Name = "Zakoncz";
            Zakoncz.Size = new Size(250, 70);
            Zakoncz.TabIndex = 2;
            Zakoncz.Text = "Zakończ";
            Zakoncz.UseVisualStyleBackColor = true;
            Zakoncz.Click += Zakoncz_Click;
            // 
            // Tury
            // 
            Tury.BorderStyle = BorderStyle.Fixed3D;
            Tury.Font = new Font("Segoe UI", 12F);
            Tury.Location = new Point(552, 261);
            Tury.Name = "Tury";
            Tury.Size = new Size(80, 40);
            Tury.TabIndex = 3;
            Tury.Text = "Tury";
            Tury.Click += label1_Click;
            // 
            // Poziom
            // 
            Poziom.BorderStyle = BorderStyle.Fixed3D;
            Poziom.Font = new Font("Segoe UI", 12F);
            Poziom.Location = new Point(552, 314);
            Poziom.Name = "Poziom";
            Poziom.Size = new Size(80, 40);
            Poziom.TabIndex = 4;
            Poziom.Text = "Poziom";
            // 
            // LiczbaTur
            // 
            LiczbaTur.AutoSize = true;
            LiczbaTur.Font = new Font("Segoe UI", 12F);
            LiczbaTur.Location = new Point(638, 262);
            LiczbaTur.Name = "LiczbaTur";
            LiczbaTur.Size = new Size(94, 28);
            LiczbaTur.TabIndex = 5;
            LiczbaTur.Text = "LiczbaTur";
            // 
            // NazwaPoziomu
            // 
            NazwaPoziomu.AutoSize = true;
            NazwaPoziomu.Font = new Font("Segoe UI", 12F);
            NazwaPoziomu.Location = new Point(638, 315);
            NazwaPoziomu.Name = "NazwaPoziomu";
            NazwaPoziomu.Size = new Size(146, 28);
            NazwaPoziomu.TabIndex = 6;
            NazwaPoziomu.Text = "NazwaPoziomu";
            // 
            // Historia
            // 
            Historia.Font = new Font("Segoe UI", 12F);
            Historia.Location = new Point(528, 416);
            Historia.Name = "Historia";
            Historia.Size = new Size(250, 70);
            Historia.TabIndex = 7;
            Historia.Text = "Historia Gry";
            Historia.UseVisualStyleBackColor = true;
            Historia.Click += Historia_Click;
            // 
            // Koniec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 913);
            Controls.Add(Historia);
            Controls.Add(NazwaPoziomu);
            Controls.Add(LiczbaTur);
            Controls.Add(Poziom);
            Controls.Add(Tury);
            Controls.Add(Zakoncz);
            Controls.Add(NowaGra);
            Controls.Add(KoniecTextBox);
            Name = "Koniec";
            Text = "Koniec";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox KoniecTextBox;
        private Button NowaGra;
        private Button Zakoncz;
        private Label Tury;
        private Label Poziom;
        private Label LiczbaTur;
        private Label NazwaPoziomu;
        private Button Historia;
    }
}