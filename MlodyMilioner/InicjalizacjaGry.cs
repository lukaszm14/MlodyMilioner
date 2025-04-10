using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MlodyMilioner
{
    /// <summary>
    /// Klasa odpowiedzialna za okienko inicjalizacji parametrów gry.
    /// </summary>
    public partial class InicjalizacjaGry : Form
    {
        private GameState _gameState;

        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        /// <param name="gameState"></param>
        public InicjalizacjaGry(GameState gameState)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Młody Milioner";
            _gameState = gameState;


            //pętla wygenerowana w chatGPT
            foreach (var diff in Enum.GetValues(typeof(Difficulty)))
            {
                Trudnosc.Items.Add(diff);
            }
            Trudnosc.Text = Difficulty.Normalny.ToString();
            Imie.Text=_gameState.P1.Name;

            
            this.BackgroundImage = Image.FromFile($"Zasoby/Tapeta1.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// Przycisk odpowiedzialny za cofnięcie do ekranu startowego (<see cref="Start"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wstecz_Click(object sender, EventArgs e)
        {
            var startForm = new Start(_gameState);
            startForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Przycisk rozpoczynający rogrywkę (wywołuje pole <see cref="Gra"/>).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rozpocznij_Click(object sender, EventArgs e)
        {
            _gameState.Economy.setDifficulty(Trudnosc.Text);
            _gameState.P1.setName(Imie.Text);
            var startForm = new Gra(_gameState);
            startForm.Show();
            this.Hide();
        }

        private void Trudnosc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Imie_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
