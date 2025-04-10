using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlodyMilioner
{
    /// <summary>
    /// Klasa dodatków.
    /// </summary>
    public class StageAddition
    {
        /// <summary>
        /// Nazwa dodatku.
        /// </summary>
        public string Name;

        /// <summary>
        /// Określa, czy dodatek jest aktywny.
        /// </summary>
        public bool Active;

        /// <summary>
        /// konstruktor klasy <see cref="StageAddition"/> z wartościami domyślnymi.
        /// </summary>
        public StageAddition()
        {
            Name = "Add";
            Active = false;
        }

        /// <summary>
        /// Aktywuje dodatek.
        /// </summary>
        public void activation()
        {
            Active = true;
        }

        /// <summary>
        /// Dezaktywuje dodatek.
        /// </summary>
        public void deactivation()
        {
            Active = false;
        }

        /// <summary>
        /// Wykonuje akcję związaną z dodatkiem i zwraca odpowiednią wartość.
        /// </summary>
        /// <param name="price">Parametr dla porzyczki.</param>
        /// <param name="amount">Parametr dla obligacji.</param>
        /// <param name="oprocentowanie">Parametr dla akcji.</param>
        /// <returns>Wartość zmiany majątku wynikająca z działania dodatku.</returns>
        public decimal action(decimal price, int? amount = null, int? oprocentowanie = null)
        {
            if (amount == null && oprocentowanie == null)
            {
                Name = "Porzyczka";
                return price;
            }
            else if (amount != null)
            {
                Name = "Zakup obligacji";
                return price * (decimal)amount;
            }
            else if (amount != null && oprocentowanie != null)
            {
                Name = "Zakup akcji na giełdzie";
                return price * (decimal)amount;
            }
            return 123456.789M;
        }
    }
}
