namespace MlodyMilioner
{
    partial class InicjalizacjaGry
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
            Wstecz = new Button();
            Rozpocznij = new Button();
            Trudnosc = new ComboBox();
            Imie = new TextBox();
            PoziomTrudnosci = new Label();
            NazwaGracza = new Label();
            SuspendLayout();
            // 
            // Wstecz
            // 
            Wstecz.Font = new Font("Segoe UI", 11F);
            Wstecz.Location = new Point(154, 739);
            Wstecz.Name = "Wstecz";
            Wstecz.Size = new Size(250, 70);
            Wstecz.TabIndex = 0;
            Wstecz.Text = "Wstecz";
            Wstecz.UseVisualStyleBackColor = true;
            Wstecz.Click += Wstecz_Click;
            // 
            // Rozpocznij
            // 
            Rozpocznij.Font = new Font("Segoe UI", 11F);
            Rozpocznij.Location = new Point(834, 739);
            Rozpocznij.Name = "Rozpocznij";
            Rozpocznij.Size = new Size(250, 70);
            Rozpocznij.TabIndex = 1;
            Rozpocznij.Text = "Rozpocznij";
            Rozpocznij.UseVisualStyleBackColor = true;
            Rozpocznij.Click += Rozpocznij_Click;
            // 
            // Trudnosc
            // 
            Trudnosc.Font = new Font("Segoe UI", 11F);
            Trudnosc.FormattingEnabled = true;
            Trudnosc.Location = new Point(499, 383);
            Trudnosc.Name = "Trudnosc";
            Trudnosc.Size = new Size(220, 33);
            Trudnosc.TabIndex = 2;
            Trudnosc.SelectedIndexChanged += Trudnosc_SelectedIndexChanged;
            // 
            // Imie
            // 
            Imie.Font = new Font("Segoe UI", 11F);
            Imie.Location = new Point(499, 267);
            Imie.MinimumSize = new Size(1, 1);
            Imie.Name = "Imie";
            Imie.Size = new Size(220, 32);
            Imie.TabIndex = 3;
            Imie.TextChanged += Imie_TextChanged;
            // 
            // PoziomTrudnosci
            // 
            PoziomTrudnosci.AutoSize = true;
            PoziomTrudnosci.Font = new Font("Segoe UI", 12F);
            PoziomTrudnosci.Location = new Point(499, 342);
            PoziomTrudnosci.Name = "PoziomTrudnosci";
            PoziomTrudnosci.Size = new Size(164, 28);
            PoziomTrudnosci.TabIndex = 4;
            PoziomTrudnosci.Text = "Poziom trudności";
            // 
            // NazwaGracza
            // 
            NazwaGracza.AutoSize = true;
            NazwaGracza.Font = new Font("Segoe UI", 12F);
            NazwaGracza.Location = new Point(499, 227);
            NazwaGracza.Name = "NazwaGracza";
            NazwaGracza.Size = new Size(134, 28);
            NazwaGracza.TabIndex = 5;
            NazwaGracza.Text = "Nazwa Gracza";
            // 
            // InicjalizacjaGry
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 913);
            Controls.Add(NazwaGracza);
            Controls.Add(PoziomTrudnosci);
            Controls.Add(Imie);
            Controls.Add(Trudnosc);
            Controls.Add(Rozpocznij);
            Controls.Add(Wstecz);
            Name = "InicjalizacjaGry";
            Text = "InicjalizacjaGry";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Wstecz;
        private Button Rozpocznij;
        private ComboBox Trudnosc;
        private TextBox Imie;
        private Label PoziomTrudnosci;
        private Label NazwaGracza;
    }
}