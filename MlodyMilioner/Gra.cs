using System.Windows.Forms;

namespace MlodyMilioner
{
    /// <summary>
    /// Ob³uga logiki WindowsForm, dla okna g³ównej rozgrywki.
    /// </summary>
    public partial class Gra : Form
    {
        private GameState _gameState;
        private decimal tempPoints;
        private decimal tempCorrection;

        ToolTip toolTip = new ToolTip();

        /// <summary>
        /// Konstruktor klasy okna z g³ówn¹ rozgrywk¹. Pobiera element typu <see cref="GameState"/>, który przechowuje stan rozgrywki, w celu zachowania spójnoœci miêdzy okienkami programu.
        /// </summary>
        /// <param name="gameState"></param>
        public Gra(GameState gameState)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "M³ody Milioner";
            _gameState = gameState;

            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 50;
            toolTip.AutoPopDelay = 6500;
            toolTip.ShowAlways = true;

            // Przypisanie tekstów ToolTip do przycisków  wygenerowane w chatGPT
            toolTip.SetToolTip(Porzyczka, "Kliknij, aby wzi¹æ po¿yczkê w wysokoœci 1000\n" +
                                          "(oprocentowanie równe 5% za ka¿d¹ turê).");
            toolTip.SetToolTip(Obligacje, "Kup obligacje za 1000(oprocentowanie równe\n" +
                                          "5% w skali tury).");
            toolTip.SetToolTip(Akcje, "Kup akcje za 2000.");

            _gameState.Started = true;


            //przypisanie startowych wartoœci elementom graficznym okienka///////
            Dalej.Enabled = false;
            Historia.Enabled = false;

            Splac.Visible = false;
            Splata.Visible = false;

            Obligacje.Enabled = false;
            SprzedajObligacje.Visible = false;
            WartObligacji.Visible = false;

            Akcje.Enabled = false;
            SprzedajAkcje.Visible = false;
            WartAkcji.Visible = false;

            AkcjaA.Text = _gameState.History.ListOfEvents[_gameState.EventId].AnsA;
            AkcjaB.Text = _gameState.History.ListOfEvents[_gameState.EventId].AnsB;
            textBox1.Text = _gameState.History.ListOfEvents[_gameState.EventId].Description;

            Punkty.Text = "Punkty:";
            label1.Text = null;
            label2.Text = null;

            Tura.Text = (_gameState.Turn + 1).ToString();
            Imie.Text = _gameState.P1.Name;
            PoziomTrudnosci.Text = _gameState.Economy.DiffName;
            Etap.Text = _gameState.StageOfGame.Name;
            StanKonta.Text = _gameState.P1.Balance.ToString();

            if (_gameState.Economy.DiffName == "£atwy")
            {
                PoziomTrudnosciP.SizeMode = PictureBoxSizeMode.Zoom;
                PoziomTrudnosciP.Image = Image.FromFile("Zasoby/Latwy.png");
            }
            else if (_gameState.Economy.DiffName == "Normalny")
            {
                PoziomTrudnosciP.SizeMode = PictureBoxSizeMode.Zoom;
                PoziomTrudnosciP.Image = Image.FromFile("Zasoby/Normalny.png");
            }
            else
            {
                PoziomTrudnosciP.SizeMode = PictureBoxSizeMode.Zoom;
                PoziomTrudnosciP.Image = Image.FromFile("Zasoby/Ciezki.png");
            }

            StanKontaP.SizeMode = PictureBoxSizeMode.Zoom;
            StanKontaP.Image = Image.FromFile("Zasoby/StanKonta.png");

            //wywo³anie metod odpowiedzialnych za przypisanie obrazów elementów graficznych
            obrazyEtap();
            buttonImage("Zasoby/Historia.png", Historia);
            buttonImage("Zasoby/Porzyczka.png", Porzyczka);
            buttonImage("Zasoby/Brak.png", Obligacje);
            buttonImage("Zasoby/Brak.png", Akcje);
            buttonImage("Zasoby/Dalej.png", Dalej);

            this.BackgroundImage = Image.FromFile($"Zasoby/Tapeta1.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void AkcjaA_Click(object sender, EventArgs e)
        {
            akcjaLogika("Pliki/historia.txt", 'A');
        }

        private void AkcjaB_Click(object sender, EventArgs e)
        {
            akcjaLogika("Pliki/historia.txt", 'B');
        }

        /// <summary>
        /// Przycisk koñcz¹cy turê.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dalej_Click(object sender, EventArgs e)
        {
            _gameState.P1.calcBalance();
            _gameState.StageOfGame.newStage(_gameState.P1.Balance);

            Etap.Text = _gameState.StageOfGame.Name;
            StanKonta.Text = _gameState.P1.Balance.ToString();

            setAdditions(Etap.Text);

            if (_gameState.endOfGame())
            {
                var startForm = new Koniec(_gameState);
                startForm.Show();
                this.Hide();
            }
            else
            {
                Tura.Text = (_gameState.Turn + 1).ToString();
                AkcjaA.Text = _gameState.History.ListOfEvents[_gameState.EventId].AnsA;
                AkcjaB.Text = _gameState.History.ListOfEvents[_gameState.EventId].AnsB;

                textBox1.Text = _gameState.History.ListOfEvents[_gameState.EventId].Description;

                label1.Text = null;
                label2.Text = null;

                AkcjaA.Enabled = true;
                AkcjaB.Enabled = true;
            }
            Splata.Text = _gameState.Porzyczka.ToString();
            WartObligacji.Text = Math.Round(_gameState.Obligacje, 2).ToString();
            WartAkcji.Text = Math.Round(_gameState.Akcje, 2).ToString();

            obrazyEtap();
            Historia.Enabled = true;
            Dalej.Enabled = false;
        }

        /// <summary>
        /// Przycisk odpowiedzialny za wyœwietlanie okienka z histori¹ rozgrywki. (logika z chatGPT po drobnych zmianach)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Historia_Click(object sender, EventArgs e)     //Logika metody wygenerowana za pomoc¹ ChatGPT, z drobmyni poprawkami
        {
            try
            {
                string filePath = "Pliki/historia.txt";
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"Brak {filePath}");
                    return;
                }

                string historyContent = File.ReadAllText(filePath);

                // Wyœwietl historiê w nowym oknie
                // Utwórz nowe okno
                var historyForm = new Form
                {
                    Text = "Historia gry",
                    Size = new System.Drawing.Size(400, 300),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedSingle
                };

                // Dodaj pole tekstowe do wyœwietlenia historii
                var textBox = new RichTextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    Text = historyContent,
                };

                historyForm.Controls.Add(textBox);

                // Obs³uga klikniêcia poza okno (zamkniêcie)
                historyForm.Deactivate += (s, e) => historyForm.Close();

                // Poka¿ okno historii jako modalne
                historyForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d podczas wczytywania historii: {ex.Message}");
            }
        }

        /// <summary>
        /// Przycisk odpowiedzialny za akcjê dodatkow¹. Wywo³uje metody z <see cref="GameState"/>, przypisuje odpowiednie w³aœciwoœci zwi¹zanym z nimi elementom graficznym.
        /// Wywo³uje MesegeBoxa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Porzyczka_Click(object sender, EventArgs e)
        {
            Splac.Visible = true;
            Splata.Visible = true;
            _gameState.porzyczka();
            _gameState.P1.calcBalance();
            StanKonta.Text = _gameState.P1.Balance.ToString();
            Splata.Text = _gameState.Porzyczka.ToString();
            _gameState.saveAdditionToPast("Pliki/historia.txt", _gameState.Turn, _gameState.AddComment);
            MessageBox.Show(_gameState.AddComment);
        }

        /// <summary>
        /// Sp³aca po¿yczkê.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Splac_Click(object sender, EventArgs e)
        {
            _gameState.splacPorzyczke();
            _gameState.P1.calcBalance();
            StanKonta.Text = _gameState.P1.Balance.ToString();
            Splata.Text = _gameState.AddComment;
            _gameState.saveAdditionToPast("Pliki/historia.txt", _gameState.Turn, _gameState.AddComment);
        }

        /// <summary>
        /// Obs³uguje metody zwi¹zane z zakupem obligacji z klasy <see cref="GameState"/> oraz jej sk³adowych, przypisuje odpowiednie w³aœciwoœci zwi¹zanym z nimi elementom graficznym.
        /// Wywo³uje MesegeBoxa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Obligacje_Click(object sender, EventArgs e)
        {
            SprzedajObligacje.Visible = true;
            WartObligacji.Visible = true;

            _gameState.kupObligacje(1000);
            _gameState.P1.calcBalance();
            StanKonta.Text = _gameState.P1.Balance.ToString();
            WartObligacji.Text = Math.Round(_gameState.Obligacje, 2).ToString();
            _gameState.saveAdditionToPast("Pliki/historia.txt", _gameState.Turn, _gameState.AddComment);
            MessageBox.Show(_gameState.AddComment);
        }

        /// <summary>
        /// Sprzedaje obligacje.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SprzedajObligacje_Click(object sender, EventArgs e)
        {
            _gameState.sprzedajObligacje();
            _gameState.P1.calcBalance();
            StanKonta.Text = _gameState.P1.Balance.ToString();
            WartObligacji.Text = _gameState.AddComment;
            _gameState.saveAdditionToPast("Pliki/historia.txt", _gameState.Turn, _gameState.AddComment);
        }

        /// <summary>
        /// Obs³uguje metody zwi¹zane z zakupem akcji z klasy <see cref="GameState"/> oraz jej sk³adowych, przypisuje odpowiednie w³aœciwoœci zwi¹zanym z nimi elementom graficznym.
        /// Wywo³uje MesegeBoxa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Akcje_Click(object sender, EventArgs e)
        {
            SprzedajAkcje.Visible = true;
            WartAkcji.Visible = true;

            _gameState.kupAkcje(2000);
            _gameState.P1.calcBalance();
            StanKonta.Text = _gameState.P1.Balance.ToString();
            WartAkcji.Text = Math.Round(_gameState.Akcje, 2).ToString();
            _gameState.saveAdditionToPast("Pliki/historia.txt", _gameState.Turn, _gameState.AddComment);
            MessageBox.Show(_gameState.AddComment);
        }

        /// <summary>
        /// Sprzedaje akcje.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SprzedajAkcje_Click(object sender, EventArgs e)
        {
            _gameState.sprzedajAkcje();
            _gameState.P1.calcBalance();
            StanKonta.Text = _gameState.P1.Balance.ToString();
            WartAkcji.Text = _gameState.AddComment;
            _gameState.saveAdditionToPast("Pliki/historia.txt", _gameState.Turn, _gameState.AddComment);
        }

        /// <summary>
        /// Czêœæ paska Menu z góry ekranu, wywo³uje ekran z menu g³ównym (<see cref="Start"/>)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuGlowne_Click(object sender, EventArgs e)
        {
            var startForm = new Start(_gameState);
            startForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Wywo³uje okienko z mo¿liwoœæi¹ zakoñczenia lub kontynuowania rozgrywki. (<see cref="Wyjscie"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zakoncz_Click(object sender, EventArgs e)
        {
            var gameForm = new Wyjscie();
            gameForm.Show();
        }

        private void PoziomTrudnosci_Click(object sender, EventArgs e)
        {

        }

        private void Etap_Click(object sender, EventArgs e)
        {

        }

        private void StanKonta_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Imie_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tura_Click(object sender, EventArgs e)
        {

        }

        private void Gra_Load(object sender, EventArgs e)
        {

        }
    }
}
