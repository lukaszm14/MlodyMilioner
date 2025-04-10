using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MlodyMilioner
{
    /// <summary>
    /// Reprezentuje wydarzenie rynkowe w grze, składowa <see cref="EventsHistory"/>.
    /// </summary>
    public class MarketEvent
    {
        /// <summary>
        /// Identyfikator wydarzenia.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Opis wydarzenia.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Liczba punktów przypisanych do wydarzenia.
        /// </summary>
        public decimal Points { get; set; }

        /// <summary>
        /// Wpływ wydarzenia na przyszłe tury.
        /// </summary>
        public int FutureImpact { get; set; }

        /// <summary>
        /// Tekst odpowiedzi A.
        /// </summary>
        public string AnsA { get; set; }

        /// <summary>
        /// Tekst odpowiedzi B.
        /// </summary>
        public string AnsB { get; set; }

        /// <summary>
        /// Poprawna odpowiedź na wydarzenie (A lub B).
        /// </summary>
        public char AnsCorrect { get; set; }

        /// <summary>
        /// Konstruktor klasy <see cref="MarketEvent"/>.
        /// </summary>
        public MarketEvent()
        {
        }

        /// <summary>
        /// Zapisuje dane wydarzenia do historii gry w pliku.
        /// </summary>
        /// <param name="historyFile">Ścieżka do pliku historii.</param>
        /// <param name="turn">Numer tury, w której wydarzenie miało miejsce.</param>
        /// <param name="ans">Wybrana odpowiedź gracza.</param>
        /// <param name="points">Przychód punktowy za wydarzenie.</param>
        /// <param name="money">Stan konta gracza po wydarzeniu.</param>
        public void saveToPast(string historyFile, int turn, string ans, decimal points, decimal money)
        {
            using (StreamWriter writer = File.AppendText(historyFile))
            {
                writer.WriteLine($"{DateTime.Now}\n   Tura:  {turn}\n   Opis:  {Description}\n   Odpowiedź:  {ans}\n   Stan konta:  {money}\n   Przychód:  {points}\n");
            }
        }
    }
}
