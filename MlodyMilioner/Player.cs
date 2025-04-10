using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlodyMilioner
{
    /// <summary>
    /// Reprezentuje gracza w grze, składowa <see cref="GameState"/>.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Nazwa gracza.
        /// </summary>
        public string Name;

        /// <summary>
        /// Stan konta gracza.
        /// </summary>
        public decimal Money;

        /// <summary>
        /// Aktualny dług gracza.
        /// </summary>
        public decimal Debt;

        /// <summary>
        /// Bilans gracza, obliczany jako różnica między <see cref="Money"/> a <see cref="Debt"/>, faktyczny stan konta.
        /// </summary>
        public decimal Balance;

        /// <summary>
        /// Konstruktor klasy <see cref="Player"/> z domyślnymi wartościami finansowymi.
        /// </summary>
        /// <param name="name">Nazwa gracza.</param>
        public Player(string name)
        {
            Name = name;
            Money = 1000;
            Debt = 0;
            Balance = Money - Debt;
        }

        /// <summary>
        /// Oblicza bilans portfela gracza.
        /// </summary>
        public void calcBalance()
        {
            Balance = Money - Debt;
        }

        /// <summary>
        /// Ustawia nazwę gracza.
        /// </summary>
        /// <param name="name">Nowe imię gracza. Jeśli wartość równa null, zostanie ustawiona wartość "Gracz".</param>
        public void setName(string? name)
        {
            if (name != null)
            {
                Name = name;
            }
            else
            {
                Name = "Gracz";
            }
        }
    }
}
