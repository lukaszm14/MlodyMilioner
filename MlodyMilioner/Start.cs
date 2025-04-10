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
    /// Klasa obsługująca Windows Forms dla ekranu początkowego uruchamianego programu.
    /// </summary>
    public partial class Start : Form
    {
        private GameState _gameState;
        public Start(GameState gameState)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Młody Milioner";

            _gameState = gameState;

            NowaGra.Enabled = false;

            if (_gameState.Started)
            {
                Graj.Text = "Wznów";
                NowaGra.Enabled = true;
            }

            this.BackgroundImage = Image.FromFile($"Zasoby/Tapeta1.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// Przycisk rozpoczynający rozgrywkę.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Graj_Click(object sender, EventArgs e)
        {
            if (!_gameState.Started)
            {
                var gameForm = new InicjalizacjaGry(_gameState);
                gameForm.Show();
            }
            else
            {
                var gameForm = new Gra(_gameState);
                gameForm.Show();
            }
            this.Hide();
        }

        /// <summary>
        /// Przycisk rozpoczynający nową rozgrywkę (aktywny gdy gracz cofnie się z poziomu innej trwającej rozgrywki).
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

        /// <summary>
        /// Wyłączenie programu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wyjscie_Click(object sender, EventArgs e)
        {
            _gameState.clearPast("Pliki/historia.txt");
            Application.Exit();
        }

    }
}
