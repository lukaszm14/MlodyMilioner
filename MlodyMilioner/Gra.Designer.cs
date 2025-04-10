namespace MlodyMilioner
{
    partial class Gra
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        /// <summary>
        /// Metoda przypisująca odpowiednie pliki graficzne do picturebox'ów obok kontrolek wyświetlających etap rozgrywki.
        /// </summary>
        protected void obrazyEtap()
        {
            if (_gameState.StageOfGame.Name == "Klasa niższa" || _gameState.StageOfGame.Name == "Bankrut")
            {
                EtapP.SizeMode = PictureBoxSizeMode.Zoom;
                EtapP.Image = Image.FromFile("Zasoby/Nizsza.png");
            }
            else if (_gameState.StageOfGame.Name == "Klasa średnia")
            {
                EtapP.SizeMode = PictureBoxSizeMode.Zoom;
                EtapP.Image = Image.FromFile("Zasoby/Srednia.png");
            }
            else
            {
                EtapP.SizeMode = PictureBoxSizeMode.Zoom;
                EtapP.Image = Image.FromFile("Zasoby/Wyzsza.png");
            }
        }

        /// <summary>
        /// Metoda przypisująca obrazy elementom typu button.
        /// Parametr text opcjonalny.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="button"></param>
        /// <param name="text"></param>
        protected void buttonImage(string filePath, Button button)
        {
            Image originalImage = Image.FromFile(filePath);
            Image resizedImage = new Bitmap(originalImage, Historia.Width - 20, Historia.Height - 10);
            button.Image = resizedImage;
            button.ImageAlign = ContentAlignment.MiddleCenter;
            button.Text = null;
        }

        /// <summary>
        /// Metoda zmieniająca właściwości graficzne przycisków odpowiedzialnych za dodatki z danego etapu (np. S.Visible = false ...) oraz aktualizację wartości odpowiednich okienek.
        /// </summary>
        protected void additionsUse()
        {
            if (_gameState.Porzyczka == 0)
            {
                Splac.Visible = false;
                Splata.Visible = false;
            }
            else
            {
                _gameState.procentPorzyczki(1000, 5);
            }

            if (_gameState.Obligacje == 0)
            {
                SprzedajObligacje.Visible = false;
                WartObligacji.Visible = false;
            }
            else
            {
                _gameState.cenaObligacji(5);
            }

            if (_gameState.Akcje == 0)
            {
                SprzedajAkcje.Visible = false;
                WartAkcji.Visible = false;
            }
            else
            {
                _gameState.cenaAkcji();
            }
        }

        /// <summary>
        /// Metoda obsługująca logikę przycisków Akcji (<see cref="AkcjaA"/>, <see cref="AkcjaB"/>
        /// </summary>
        /// <param name="historyFile"></param>
        /// <param name="corrAns"></param>
        protected void akcjaLogika(string historyFile, char corrAns)
        {
            tempPoints = _gameState.checkQuestion(_gameState.History.ListOfEvents.ElementAt(_gameState.EventId), corrAns);
            tempCorrection = _gameState.setMarketCorection();

            //metoda nadpisująca plik z historią rozgrywki
            _gameState.History.ListOfEvents.ElementAt(_gameState.EventId).saveToPast(historyFile, _gameState.Turn, _gameState.History.ListOfEvents.ElementAt(_gameState.EventId).AnsA, tempPoints + tempCorrection, _gameState.P1.Balance + tempPoints + tempCorrection);

            label1.Text = "Zdobyto:  " + tempPoints.ToString();
            label2.Text = "Inflacja i podatki:  " + tempCorrection.ToString();

            AkcjaA.Enabled = false;
            AkcjaB.Enabled = false;

            additionsUse();
            Dalej.Enabled = true;
        }

        /// <summary>
        /// Metoda przypisująca odpowiednie właściwości elementom graficznym na podstawie aktualnego stanu rozgrywki (parametr wywoływany w kodzie to <see cref="Stage.Name"/>)
        /// </summary>
        /// <param name="nameOfStage"></param>
        protected void setAdditions(string nameOfStage)
        {
            switch (nameOfStage)
            {
                case "Klasa średnia":
                    Obligacje.Enabled = true;
                    buttonImage("Zasoby/Obligacje.png", Obligacje);
                    _gameState.StageOfGame.Additions.ElementAt(1).activation();
                    break;
                case "Klasa wyższa":
                    Obligacje.Enabled = true;
                    buttonImage("Zasoby/Obligacje.png", Obligacje);
                    _gameState.StageOfGame.Additions.ElementAt(1).activation();
                    Akcje.Enabled = true;
                    buttonImage("Zasoby/Akcje.png", Akcje);
                    _gameState.StageOfGame.Additions.ElementAt(2).activation();
                    break;
                case "Milioner":
                    Obligacje.Enabled = true;
                    buttonImage("Zasoby/Obligacje.png", Obligacje);
                    _gameState.StageOfGame.Additions.ElementAt(1).activation();
                    Akcje.Enabled = true;
                    buttonImage("Zasoby/Akcje.png", Akcje);
                    _gameState.StageOfGame.Additions.ElementAt(2).activation();
                    break;
            }
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AkcjaA = new Button();
            AkcjaB = new Button();
            Dalej = new Button();
            PoziomTrudnosci = new Label();
            Etap = new Label();
            StanKonta = new Label();
            Punkty = new Label();
            label2 = new Label();
            Imie = new Label();
            label1 = new Label();
            Historia = new Button();
            Tura = new Label();
            Porzyczka = new Button();
            Obligacje = new Button();
            Akcje = new Button();
            TuraT = new Label();
            ImieT = new Label();
            PoziomTrudnosciT = new Label();
            EtapT = new Label();
            label7 = new Label();
            Splac = new Button();
            SprzedajObligacje = new Button();
            SprzedajAkcje = new Button();
            Splata = new Label();
            WartObligacji = new Label();
            WartAkcji = new Label();
            menuStrip1 = new MenuStrip();
            MenuGlowne = new ToolStripMenuItem();
            Zakoncz = new ToolStripMenuItem();
            PoziomTrudnosciP = new PictureBox();
            EtapP = new PictureBox();
            StanKontaP = new PictureBox();
            textBox1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PoziomTrudnosciP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EtapP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StanKontaP).BeginInit();
            SuspendLayout();
            // 
            // AkcjaA
            // 
            AkcjaA.Font = new Font("Segoe UI", 10F);
            AkcjaA.Location = new Point(187, 661);
            AkcjaA.Name = "AkcjaA";
            AkcjaA.Size = new Size(230, 100);
            AkcjaA.TabIndex = 0;
            AkcjaA.Text = "AkcjaA";
            AkcjaA.UseVisualStyleBackColor = true;
            AkcjaA.Click += AkcjaA_Click;
            // 
            // AkcjaB
            // 
            AkcjaB.Font = new Font("Segoe UI", 10F);
            AkcjaB.Location = new Point(787, 661);
            AkcjaB.Name = "AkcjaB";
            AkcjaB.Size = new Size(230, 100);
            AkcjaB.TabIndex = 1;
            AkcjaB.Text = "AkcjaB";
            AkcjaB.UseVisualStyleBackColor = true;
            AkcjaB.Click += AkcjaB_Click;
            // 
            // Dalej
            // 
            Dalej.Font = new Font("Segoe UI", 10F);
            Dalej.Location = new Point(913, 479);
            Dalej.Name = "Dalej";
            Dalej.Size = new Size(80, 80);
            Dalej.TabIndex = 4;
            Dalej.Text = "Dalej";
            Dalej.UseVisualStyleBackColor = true;
            Dalej.Click += Dalej_Click;
            // 
            // PoziomTrudnosci
            // 
            PoziomTrudnosci.BorderStyle = BorderStyle.Fixed3D;
            PoziomTrudnosci.Font = new Font("Segoe UI", 12F);
            PoziomTrudnosci.Location = new Point(999, 143);
            PoziomTrudnosci.Name = "PoziomTrudnosci";
            PoziomTrudnosci.Size = new Size(160, 35);
            PoziomTrudnosci.TabIndex = 5;
            PoziomTrudnosci.Text = "PoziomTrudnosci";
            PoziomTrudnosci.TextAlign = ContentAlignment.MiddleLeft;
            PoziomTrudnosci.Click += PoziomTrudnosci_Click;
            // 
            // Etap
            // 
            Etap.BorderStyle = BorderStyle.Fixed3D;
            Etap.Font = new Font("Segoe UI", 12F);
            Etap.Location = new Point(999, 187);
            Etap.Name = "Etap";
            Etap.Size = new Size(160, 35);
            Etap.TabIndex = 6;
            Etap.Text = "Etap";
            Etap.TextAlign = ContentAlignment.MiddleLeft;
            Etap.Click += Etap_Click;
            // 
            // StanKonta
            // 
            StanKonta.BorderStyle = BorderStyle.Fixed3D;
            StanKonta.Font = new Font("Segoe UI", 12F);
            StanKonta.Location = new Point(999, 229);
            StanKonta.Name = "StanKonta";
            StanKonta.Size = new Size(160, 35);
            StanKonta.TabIndex = 7;
            StanKonta.Text = "StanKonta";
            StanKonta.TextAlign = ContentAlignment.MiddleLeft;
            StanKonta.Click += StanKonta_Click;
            // 
            // Punkty
            // 
            Punkty.AutoSize = true;
            Punkty.BorderStyle = BorderStyle.Fixed3D;
            Punkty.Font = new Font("Segoe UI", 11F);
            Punkty.Location = new Point(566, 661);
            Punkty.Name = "Punkty";
            Punkty.Size = new Size(75, 27);
            Punkty.TabIndex = 8;
            Punkty.Text = "Punkty:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(494, 754);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 9;
            label2.Text = "korekcja";
            label2.Click += label2_Click;
            // 
            // Imie
            // 
            Imie.BorderStyle = BorderStyle.Fixed3D;
            Imie.Font = new Font("Segoe UI", 12F);
            Imie.Location = new Point(999, 53);
            Imie.Name = "Imie";
            Imie.Size = new Size(160, 35);
            Imie.TabIndex = 10;
            Imie.Text = "Imie";
            Imie.TextAlign = ContentAlignment.MiddleLeft;
            Imie.Click += Imie_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(494, 709);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 12;
            label1.Text = "punkty";
            // 
            // Historia
            // 
            Historia.Font = new Font("Segoe UI", 10F);
            Historia.Location = new Point(1061, 479);
            Historia.Name = "Historia";
            Historia.Size = new Size(80, 80);
            Historia.TabIndex = 14;
            Historia.Text = "Historia";
            Historia.UseVisualStyleBackColor = true;
            Historia.Click += Historia_Click;
            // 
            // Tura
            // 
            Tura.BorderStyle = BorderStyle.Fixed3D;
            Tura.Font = new Font("Segoe UI", 12F);
            Tura.Location = new Point(999, 97);
            Tura.Name = "Tura";
            Tura.Size = new Size(160, 35);
            Tura.TabIndex = 15;
            Tura.Text = "Tura";
            Tura.TextAlign = ContentAlignment.MiddleLeft;
            Tura.Click += Tura_Click;
            // 
            // Porzyczka
            // 
            Porzyczka.Font = new Font("Segoe UI", 10F);
            Porzyczka.Location = new Point(64, 143);
            Porzyczka.Name = "Porzyczka";
            Porzyczka.Size = new Size(90, 120);
            Porzyczka.TabIndex = 16;
            Porzyczka.Text = "Porzyczka (1000)";
            Porzyczka.UseVisualStyleBackColor = true;
            Porzyczka.Click += Porzyczka_Click;
            // 
            // Obligacje
            // 
            Obligacje.Font = new Font("Segoe UI", 10F);
            Obligacje.Location = new Point(197, 143);
            Obligacje.Name = "Obligacje";
            Obligacje.Size = new Size(90, 120);
            Obligacje.TabIndex = 17;
            Obligacje.Text = "Obligacje (1000 na 5%)";
            Obligacje.UseVisualStyleBackColor = true;
            Obligacje.Click += Obligacje_Click;
            // 
            // Akcje
            // 
            Akcje.Font = new Font("Segoe UI", 10F);
            Akcje.Location = new Point(335, 143);
            Akcje.Name = "Akcje";
            Akcje.Size = new Size(90, 120);
            Akcje.TabIndex = 18;
            Akcje.Text = "Akcje (2000 zmienna wartość)";
            Akcje.UseVisualStyleBackColor = true;
            Akcje.Click += Akcje_Click;
            // 
            // TuraT
            // 
            TuraT.BorderStyle = BorderStyle.Fixed3D;
            TuraT.Font = new Font("Segoe UI", 12F);
            TuraT.Location = new Point(823, 97);
            TuraT.Name = "TuraT";
            TuraT.Size = new Size(170, 35);
            TuraT.TabIndex = 19;
            TuraT.Text = "Tura";
            TuraT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImieT
            // 
            ImieT.BorderStyle = BorderStyle.Fixed3D;
            ImieT.Font = new Font("Segoe UI", 12F);
            ImieT.Location = new Point(823, 53);
            ImieT.Name = "ImieT";
            ImieT.Size = new Size(170, 35);
            ImieT.TabIndex = 20;
            ImieT.Text = "Nazwa gracza";
            ImieT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PoziomTrudnosciT
            // 
            PoziomTrudnosciT.BorderStyle = BorderStyle.Fixed3D;
            PoziomTrudnosciT.Font = new Font("Segoe UI", 12F);
            PoziomTrudnosciT.Location = new Point(823, 143);
            PoziomTrudnosciT.Name = "PoziomTrudnosciT";
            PoziomTrudnosciT.Size = new Size(170, 35);
            PoziomTrudnosciT.TabIndex = 21;
            PoziomTrudnosciT.Text = "Poziom trudności";
            PoziomTrudnosciT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EtapT
            // 
            EtapT.BorderStyle = BorderStyle.Fixed3D;
            EtapT.Font = new Font("Segoe UI", 12F);
            EtapT.Location = new Point(823, 187);
            EtapT.Name = "EtapT";
            EtapT.Size = new Size(170, 35);
            EtapT.TabIndex = 22;
            EtapT.Text = "Etap rozgrywki";
            EtapT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(823, 229);
            label7.Name = "label7";
            label7.Size = new Size(170, 35);
            label7.TabIndex = 23;
            label7.Text = "Stan konta";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Splac
            // 
            Splac.Font = new Font("Segoe UI", 10F);
            Splac.Location = new Point(64, 291);
            Splac.Name = "Splac";
            Splac.Size = new Size(90, 50);
            Splac.TabIndex = 24;
            Splac.Text = "Spłać";
            Splac.UseVisualStyleBackColor = true;
            Splac.Click += Splac_Click;
            // 
            // SprzedajObligacje
            // 
            SprzedajObligacje.Font = new Font("Segoe UI", 10F);
            SprzedajObligacje.Location = new Point(197, 291);
            SprzedajObligacje.Name = "SprzedajObligacje";
            SprzedajObligacje.Size = new Size(90, 50);
            SprzedajObligacje.TabIndex = 25;
            SprzedajObligacje.Text = "Wykup";
            SprzedajObligacje.UseVisualStyleBackColor = true;
            SprzedajObligacje.Click += SprzedajObligacje_Click;
            // 
            // SprzedajAkcje
            // 
            SprzedajAkcje.Font = new Font("Segoe UI", 10F);
            SprzedajAkcje.Location = new Point(335, 291);
            SprzedajAkcje.Name = "SprzedajAkcje";
            SprzedajAkcje.Size = new Size(90, 50);
            SprzedajAkcje.TabIndex = 26;
            SprzedajAkcje.Text = "Sprzedaj";
            SprzedajAkcje.UseVisualStyleBackColor = true;
            SprzedajAkcje.Click += SprzedajAkcje_Click;
            // 
            // Splata
            // 
            Splata.AutoSize = true;
            Splata.BorderStyle = BorderStyle.Fixed3D;
            Splata.Font = new Font("Segoe UI", 10F);
            Splata.Location = new Point(64, 357);
            Splata.MaximumSize = new Size(60, 0);
            Splata.MinimumSize = new Size(90, 60);
            Splata.Name = "Splata";
            Splata.Size = new Size(90, 60);
            Splata.TabIndex = 27;
            Splata.Text = "Kwota";
            Splata.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WartObligacji
            // 
            WartObligacji.AutoSize = true;
            WartObligacji.BorderStyle = BorderStyle.Fixed3D;
            WartObligacji.Font = new Font("Segoe UI", 10F);
            WartObligacji.Location = new Point(197, 357);
            WartObligacji.MaximumSize = new Size(60, 0);
            WartObligacji.MinimumSize = new Size(90, 60);
            WartObligacji.Name = "WartObligacji";
            WartObligacji.Size = new Size(90, 60);
            WartObligacji.TabIndex = 28;
            WartObligacji.Text = "Wartość";
            WartObligacji.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WartAkcji
            // 
            WartAkcji.AutoSize = true;
            WartAkcji.BorderStyle = BorderStyle.Fixed3D;
            WartAkcji.Font = new Font("Segoe UI", 10F);
            WartAkcji.Location = new Point(335, 357);
            WartAkcji.MaximumSize = new Size(60, 0);
            WartAkcji.MinimumSize = new Size(90, 60);
            WartAkcji.Name = "WartAkcji";
            WartAkcji.Size = new Size(90, 60);
            WartAkcji.TabIndex = 29;
            WartAkcji.Text = "Wartość";
            WartAkcji.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuGlowne, Zakoncz });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1262, 28);
            menuStrip1.TabIndex = 30;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuGlowne
            // 
            MenuGlowne.Name = "MenuGlowne";
            MenuGlowne.Size = new Size(114, 24);
            MenuGlowne.Text = "Menu Główne";
            MenuGlowne.Click += MenuGlowne_Click;
            // 
            // Zakoncz
            // 
            Zakoncz.Name = "Zakoncz";
            Zakoncz.Size = new Size(78, 24);
            Zakoncz.Text = "Zakończ";
            Zakoncz.Click += Zakoncz_Click;
            // 
            // PoziomTrudnosciP
            // 
            PoziomTrudnosciP.BorderStyle = BorderStyle.Fixed3D;
            PoziomTrudnosciP.Location = new Point(1165, 143);
            PoziomTrudnosciP.Name = "PoziomTrudnosciP";
            PoziomTrudnosciP.Size = new Size(35, 35);
            PoziomTrudnosciP.TabIndex = 31;
            PoziomTrudnosciP.TabStop = false;
            // 
            // EtapP
            // 
            EtapP.BorderStyle = BorderStyle.Fixed3D;
            EtapP.Location = new Point(1165, 187);
            EtapP.Name = "EtapP";
            EtapP.Size = new Size(35, 35);
            EtapP.TabIndex = 32;
            EtapP.TabStop = false;
            // 
            // StanKontaP
            // 
            StanKontaP.BorderStyle = BorderStyle.Fixed3D;
            StanKontaP.Location = new Point(1165, 229);
            StanKontaP.Name = "StanKontaP";
            StanKontaP.Size = new Size(35, 35);
            StanKontaP.TabIndex = 33;
            StanKontaP.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(392, 522);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(420, 120);
            textBox1.TabIndex = 34;
            textBox1.Text = "Wydarzenie";
            textBox1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(64, 101);
            label4.MinimumSize = new Size(90, 30);
            label4.Name = "label4";
            label4.Size = new Size(90, 30);
            label4.TabIndex = 35;
            label4.Text = "Porzyczka";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(197, 101);
            label5.MinimumSize = new Size(90, 30);
            label5.Name = "label5";
            label5.Size = new Size(90, 30);
            label5.TabIndex = 36;
            label5.Text = "Obligacje";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(335, 101);
            label6.MinimumSize = new Size(90, 30);
            label6.Name = "label6";
            label6.Size = new Size(90, 30);
            label6.TabIndex = 37;
            label6.Text = "Akcje";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Gra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 913);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(StanKontaP);
            Controls.Add(EtapP);
            Controls.Add(PoziomTrudnosciP);
            Controls.Add(WartAkcji);
            Controls.Add(WartObligacji);
            Controls.Add(Splata);
            Controls.Add(SprzedajAkcje);
            Controls.Add(SprzedajObligacje);
            Controls.Add(Splac);
            Controls.Add(label7);
            Controls.Add(EtapT);
            Controls.Add(PoziomTrudnosciT);
            Controls.Add(ImieT);
            Controls.Add(TuraT);
            Controls.Add(Akcje);
            Controls.Add(Obligacje);
            Controls.Add(Porzyczka);
            Controls.Add(Tura);
            Controls.Add(Historia);
            Controls.Add(label1);
            Controls.Add(Imie);
            Controls.Add(label2);
            Controls.Add(Punkty);
            Controls.Add(StanKonta);
            Controls.Add(Etap);
            Controls.Add(PoziomTrudnosci);
            Controls.Add(Dalej);
            Controls.Add(AkcjaB);
            Controls.Add(AkcjaA);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Gra";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PoziomTrudnosciP).EndInit();
            ((System.ComponentModel.ISupportInitialize)EtapP).EndInit();
            ((System.ComponentModel.ISupportInitialize)StanKontaP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AkcjaA;
        private Button AkcjaB;
        private Button Dalej;
        private Label PoziomTrudnosci;
        private Label Etap;
        private Label StanKonta;
        private Label Punkty;
        private Label label2;
        private Label Imie;
        private Label label1;
        private Button Historia;
        private Label Tura;
        private Button Porzyczka;
        private Button Obligacje;
        private Button Akcje;
        private Label TuraT;
        private Label ImieT;
        private Label PoziomTrudnosciT;
        private Label EtapT;
        private Label label7;
        private Button Splac;
        private Button SprzedajObligacje;
        private Button SprzedajAkcje;
        private Label Splata;
        private Label WartObligacji;
        private Label WartAkcji;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuGlowne;
        private ToolStripMenuItem Zakoncz;
        private PictureBox PoziomTrudnosciP;
        private PictureBox EtapP;
        private PictureBox StanKontaP;
        private Label textBox1;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
