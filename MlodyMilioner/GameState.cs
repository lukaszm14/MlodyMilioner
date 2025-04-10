using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MlodyMilioner
{
    /// <summary>
    /// Poziomy trudności gry.
    /// </summary>
    public enum Difficulty
    {
        Łatwy,
        Normalny,
        Ciężki
    }

    /// <summary>
    /// Klasa reprezentująca stan gry.
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Gracz w bieżącej rozgrywce.
        /// </summary>
        public Player P1;

        /// <summary>
        /// Obiekt rynku zarządzający mechaniką ekonomiczną.
        /// </summary>
        public Market Economy;

        /// <summary>
        /// Historia zdarzeń w grze.
        /// </summary>
        public EventsHistory History;

        /// <summary>
        /// Etap gry.
        /// </summary>
        public Stage StageOfGame;

        /// <summary>
        /// Identyfikator bieżącego zdarzenia.
        /// </summary>
        public int EventId = 0;

        /// <summary>
        /// Kwota pożyczek.
        /// </summary>
        public decimal Porzyczka = 0;

        /// <summary>
        /// Wartość obligacji posiadanych przez gracza.
        /// </summary>
        public decimal Obligacje = 0;

        /// <summary>
        /// Wartość akcji posiadanych przez gracza.
        /// </summary>
        public decimal Akcje = 0;

        /// <summary>
        /// Dodatkowy komentarz informacyjny.
        /// </summary>
        public string AddComment = "";  
        
        /// <summary>
        /// Numer bieżącej tury gry.
        /// </summary>
        public int Turn = 0;

        /// <summary>
        /// Status rozpoczęcia gry.
        /// </summary>
        public bool Started = false;

        /// <summary>
        /// Identyfikator tła używanego w interfejsie gry.
        /// </summary>
        public int BackgroundId = 1;

        /// <summary>
        /// Konstruktor domyślny klasy <see cref="GameState"/>. Inicjalizuje gracza, rynek, historię i etap gry.
        /// </summary>
        public GameState()
        {
            P1 = new Player("Gracz");
            Economy = new Market(Difficulty.Normalny);
            History = new EventsHistory("Pliki/plik.json");
            StageOfGame = new Stage();
        }

        /// <summary>
        /// Konstruktor pozwalający na dostosowanie gracza, poziomu trudności i pliku historii zdarzeń.
        /// </summary>
        /// <param name="playerName">Nazwa gracza.</param>
        /// <param name="diff">Poziom trudności gry.</param>
        /// <param name="historyFile">Ścieżka do pliku z historią zdarzeń.</param>
        public GameState(string playerName, Difficulty diff, string historyFile)
        {
            P1 = new Player(playerName);
            Economy = new Market(diff);
            History = new EventsHistory(historyFile);
            StageOfGame = new Stage();
        }

        /// <summary>
        /// Ustawia korektę rynkową dla stanu konta gracza.
        /// </summary>
        /// <returns>Wartość korekty.</returns>
        public decimal setMarketCorection()
        {
            decimal temp = 0;
            temp -= P1.Money * Economy.Inflation;
            temp -= P1.Money * Economy.Taxes * StageOfGame.TaxRate;

            return Math.Round(temp, 2);
        }

        /// <summary>
        /// Dodaje pożyczkę do stanu gracza.
        /// </summary>
        public void porzyczka()
        {
            decimal money = 1000;
            P1.Money += money;
            Porzyczka += money;
            AddComment = $"Pożyczono {money} (oprocentowanie równe 5%, za każdą turę).";
        }

        /// <summary>
        /// Oblicza procent wartości pożyczki.
        /// </summary>
        /// <param name="money">Kwota pożyczki.</param>
        /// <param name="percent">Procent do obliczenia.</param>
        /// <returns>Wartość procentowa.</returns>
        public decimal procentPorzyczki(decimal money, int percent)
        {
            decimal temp = money;
            temp *= (decimal)percent / 100;

            Math.Round(temp, 2);
            Porzyczka += temp;

            return temp;
        }

        /// <summary>
        /// Spłaca całość bieżącej pożyczki, jeśli gracz ma wystarczające środki.
        /// </summary>
        public void splacPorzyczke()
        {
            if (P1.Balance > Porzyczka)
            {
                P1.Money -= Porzyczka;
                Porzyczka = 0;
                AddComment = "Dokonano spłaty długu.";
            }
            else
            {
                AddComment = "Próba spłaty: Zbyt mało środków na koncie.";
            }
        }

        /// <summary>
        /// Kupuje obligacje, jeżeli gracz posiada odpowiednią iliść środków na koncie.
        /// </summary>
        /// <param name="price">Cena kupywanych obligacji</param>
        public void kupObligacje(decimal price)
        {
            if(P1.Money > price)
            {
                P1.Money-=price;
                AddComment = $"Zakupiono obligacje za {price} (stały procent równy 5%).";
                Obligacje += price;
            }
        }

        /// <summary>
        /// Wylicza nową wartość posiadanych obligacji, wedle podanego oprocentowania.
        /// </summary>
        /// <param name="procent">Oprocentowanie obligacji</param>
        public void cenaObligacji(int procent)
        {
            decimal proc = (decimal)procent * 0.01M;
            Obligacje += Obligacje * proc;
            Math.Round(Obligacje, 2);
        }

        /// <summary>
        /// Sprzedaje obligacje.
        /// </summary>
        public void sprzedajObligacje()
        {
            P1.Money += Obligacje;
            AddComment = $"Wykupiono obligacje za {Math.Round(Obligacje, 2)}";
            Obligacje = 0;
        }

        /// <summary>
        /// Kupuje akcje, jeżeli gracz posiada odpowiednią ilość środków na koncie.
        /// </summary>
        /// <param name="price">Cena zakupu akcji</param>
        public void kupAkcje(decimal price)
        {
            if (P1.Money > price)
            {
                P1.Money -= price;
                AddComment = $"Zakupiono akcje za {price}.";
                Akcje += price;
            }
        }

        /// <summary>
        /// Wylicza wartość akcji, wedle losowanego oprocentowania (wylicenie z oprocentowaniem z przedziału od -25 do 25).
        /// </summary>
        public void cenaAkcji()
        {
            Random random = new Random();

            int procent = random.Next(-25, 25);
            Akcje += Akcje * (decimal)procent / 100;

            if (Akcje < 0)
            {
                Akcje = 0;
            }
            Math.Round(Obligacje, 2);
        }

        /// <summary>
        /// Dokonuje sprzedaży akcji posiadanych przez gracza.
        /// </summary>
        public void sprzedajAkcje()
        {
            P1.Money += Akcje;
            AddComment = $"Sprzedano akcje za {Math.Round(Akcje, 2)}";
            Akcje = 0;
        }

        /// <summary>
        /// Sprawdza poprawność odpowiedzi na pytanie oraz dopisuje punkty do stanu konta gracza jeżeli odpowie poprawnie, lub w przeciwnym wypadku je odejmuje.
        /// Zwiększa ilczbę <see cref="Turn"/>
        /// Wywołuje <see cref="setMarketCorection"/>
        /// </summary>
        /// <param name="quest">Obiekt zdarzenia (wczytywany z pliku do obiektu <see cref="MarketEvent"/>)</param>
        /// <param name="ans">Poprawna odpowiedź.</param>
        /// <returns></returns>
        public decimal checkQuestion(MarketEvent quest, char ans)
        {
            decimal tempPoints;
            decimal points = P1.Money / quest.Points;
            if (points < 10)
            {
                points = quest.Points;
            }
            if (ans == quest.AnsCorrect)
            {
                P1.Money += points;
                tempPoints = points;
            }
            else
            {
                if(Economy.DiffName != "Ciężki")
                {
                    P1.Money -= points;
                    tempPoints = -points;
                }
                else
                {
                    P1.Money -= 2* points;
                    tempPoints = -2* points;
                }
            }
            
            if(EventId < History.ListOfEvents.Count()-1)
            {
                EventId++;
            }
            else
            {
                EventId = 0;
            }
            Turn++;
            P1.Money += setMarketCorection();
            P1.Money = Math.Round(P1.Money,2);
            return Math.Round(tempPoints,2);
        }

        /// <summary>
        /// Sprawdza warunek zakończenia rozgrywki.
        /// </summary>
        /// <returns>Prawda jeżeli spełniony warunek końca, fałsz w przeciwnym wypadku.</returns>
        public bool endOfGame()
        {
            P1.calcBalance();
            if (P1.Balance >= 1000000 && Porzyczka != 0)
            {
                return false;
            }
            else if (P1.Balance <= 0 || P1.Balance >= 1000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Usuwa zawartość pliku histori nadpisywanego podczas rozgrywki.
        /// </summary>
        /// <param name="file">Scierzka do pliku przechowującego historię.</param>
        /// <exception cref="Exception">Wywoływane, gdy plik nie istnieje.</exception>
        public void clearPast(string file)
        {
            try
            {
                File.WriteAllText(file, string.Empty);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Nadpisuje plik historii rozgrywki o liczby z użytego dodatku.
        /// </summary>
        /// <param name="historyFile">Ścierzka do pliku przechowującego historię.</param>
        /// <param name="turn">Numer aktualnej tury</param>
        /// <param name="addition">Nazwa użytego dodatku</param>
        public void saveAdditionToPast(string historyFile, int turn, string addition)
        {
            using (StreamWriter writer = File.AppendText(historyFile))
            {
                writer.WriteLine($"{DateTime.Now}\n   Tura:  {turn}\n   Opis:  {addition}\n");
            }
        }
    }
}
