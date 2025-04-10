using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MlodyMilioner
{
    /// <summary>
    /// Klasa obsługująca Windows Form dla okienka ekranu końcowego.
    /// </summary>
    public partial class Koniec : Form
    {
        private GameState _gameState;

        /// <summary>
        /// Konstruktor klasy, pobiera obiekt typu <see cref="GameState"/>, w celu utrymania ciągłaości rozgrywki.
        /// </summary>
        /// <param name="gameState">Obiekt <see cref="GameState"/></param>
        public Koniec(GameState gameState)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Młody Milioner";

            _gameState = gameState;

            LiczbaTur.Text = _gameState.Turn.ToString();
            NazwaPoziomu.Text = _gameState.Economy.DiffName;

            if (_gameState.StageOfGame.Wealth >= 1000000)
            {
                KoniecTextBox.Text = "Wygrana";
            }
            else
            {
                KoniecTextBox.Text = "Przegrana";
            }


            this.BackgroundImage = Image.FromFile($"Zasoby/Tapeta1.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void KoniecTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Przycisk obsługujący zakończenie rozgrywki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zakoncz_Click(object sender, EventArgs e)
        {
            _gameState.clearPast("Pliki/historia.txt");
            Application.Exit();
        }

        /// <summary>
        /// Przycisk do rozpoczęcia nowej gry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NowaGra_Click(object sender, EventArgs e)
        {
            _gameState.clearPast("Pliki/historia.txt");

            var newGameState = new GameState();

            var newGameForm = new InicjalizacjaGry(newGameState);
            newGameForm.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Przycisk do wyświetlania okienka z historią rozgrywki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Historia_Click(object sender, EventArgs e)     //Logika metody wygenerowana za pomocą ChatGPT, z drobmyni poprawkami
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

                // Wyświetl historię w nowym oknie
                // Utwórz nowe okno
                var historyForm = new Form
                {
                    Text = "Historia gry",
                    Size = new System.Drawing.Size(400, 300),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedSingle
                };

                // Dodaj pole tekstowe do wyświetlenia historii
                var textBox = new RichTextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    Text = historyContent,
                };

                historyForm.Controls.Add(textBox);

                // Obsługa kliknięcia poza okno (zamknięcie)
                historyForm.Deactivate += (s, e) => historyForm.Close();

                // Pokaż okno historii jako modalne
                historyForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wczytywania historii: {ex.Message}");
            }
        }
    }
}
