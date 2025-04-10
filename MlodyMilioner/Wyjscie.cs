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
    /// Klasa obsługująca okienko wyjścia z poziomu aktywnej rogrywki.
    /// </summary>
    public partial class Wyjscie : Form
    {
        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        public Wyjscie()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.BackgroundImage = Image.FromFile($"Zasoby/Tapeta1.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// Przycisk kończący rozgrywkę.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tak_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Pliki/historia.txt", string.Empty);
            Application.Exit();
        }

        /// <summary>
        /// Przycisk wracający do rozgrywki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nie_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
