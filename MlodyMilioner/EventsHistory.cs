using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MlodyMilioner
{
    /// <summary>
    /// Klasa reprezentująca historię zdarzeń rynkowych.
    /// </summary>
    public class EventsHistory
    {
        /// <summary>
        /// Lista zdarzeń rynkowych.
        /// </summary>
        public List<MarketEvent> ListOfEvents { get; set; }

        /// <summary>
        /// Ścieżka do pliku, w którym przechowywana jest historia zdarzeń.
        /// </summary>
        private string PathToFile { get; set; }

        /// <summary>
        /// Tworzy nową instancję klasy <see cref="EventsHistory"/> na podstawie ścieżki do pliku JSON.
        /// </summary>
        /// <param name="file">Ścieżka do pliku JSON zawierającego listę zdarzeń rynkowych.</param>
        /// <exception cref="FileNotFoundException">Rzucany, gdy plik o podanej ścieżce nie istnieje.</exception>
        /// <exception cref="InvalidOperationException">Rzucany, gdy wystąpi błąd podczas deserializacji pliku JSON.</exception>
        public EventsHistory(string file)
        {
            PathToFile = file;

            // Sprawdzenie, czy plik istnieje
            if (!File.Exists(PathToFile))
            {
                throw new FileNotFoundException($"Plik {PathToFile} nie istnieje.");
            }

            try
            {
                // Wczytanie zawartości pliku JSON
                string json = File.ReadAllText(PathToFile);
                var events = JsonSerializer.Deserialize<List<MarketEvent>>(json);
                ListOfEvents = events ?? new List<MarketEvent>();
            }
            catch (JsonException ex)
            {
                // Obsługa błędów związanych z deserializacją JSON
                throw new InvalidOperationException($"Błąd {ex.Message}");
            }
        }
    }
}
