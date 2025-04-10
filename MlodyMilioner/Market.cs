using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlodyMilioner
{
    /// <summary>
    /// Klasa przechowująca informacje dotyczące właściwości symulowanego rynku. Składowa GameState (<see cref="GameState.Economy"/>).
    /// </summary>
    public class Market
    {
        /// <summary>
        /// Nazwa poziomu trudności.
        /// </summary>
        public string DiffName;

        /// <summary>
        /// Wartość przechowująca wysokość podatków (mnożnik do <see cref="Stage.TaxRate"/>)
        /// </summary>
        public decimal Taxes;

        /// <summary>
        /// Poziom inflacji, (liczba wyrażona jako liczba dziesiętna)
        /// </summary>
        public decimal Inflation;


        /// <summary>
        /// Ustawia poziom trudności.
        /// </summary>
        /// <param name="diff">Nazwa poziomu trudności.</param>
        /// <exception cref="Exception">Wywoływany gdy podana nazwa jest błędna (nie pokrywa się z żadną z dostępnych).</exception>
        public void setDifficulty(string diff)
        {
            if (diff == "Łatwy")
            {
                Taxes = 0.001M;
                Inflation = 0;
            }
            else if (diff == "Normalny")
            {
                Taxes = 0.002M;
                Inflation = 0.0001M;
            }
            else if (diff == "Ciężki")
            {
                Taxes = 0.005M;
                Inflation = 0.0002M;
            }
            else
            {
                throw new Exception("Zły poziom trudności");
            }
            DiffName = diff;
        }

        /// <summary>
        /// Konstruktor klasy ustawiający poziom trudności.
        /// </summary>
        /// <param name="diff">Enum odpowiadający poziomowi trudności (<see cref="Difficulty"/>)</param>
        public Market(Difficulty diff)
        {
            DiffName = diff.ToString();
            setDifficulty(DiffName);
        }
    }
}
