using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlodyMilioner
{
    /// <summary>
    /// Dostępne etapy w grze.
    /// </summary>
    public enum Stages
    {
        Nizsza,
        Srednia,
        Wyzsza
    }

    /// <summary>
    /// Reprezentuje aktualny etap rozgrywki gracza.
    /// </summary>
    public class Stage
    {
        /// <summary>
        /// Nazwa aktualnego etapu.
        /// </summary>
        public string Name;

        /// <summary>
        /// Majątek gracza.
        /// </summary>
        public decimal Wealth;

        /// <summary>
        /// Stawka podatkowa.
        /// </summary>
        public decimal TaxRate;

        /// <summary>
        /// Lista dodatków dostępnych na danym etapie gry.
        /// </summary>
        public List<StageAddition> Additions;

        private string NewStage;

        /// <summary>
        /// Konstruktor klasy <see cref="Stage"/> z wartościami domyślnymi.
        /// </summary>
        public Stage()
        {
            Name = "Klasa niższa";
            Wealth = 0;
            TaxRate = 1;
            Additions = new List<StageAddition>();
            NewStage = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                Additions.Add(new StageAddition());
            }
            Additions.ElementAt(0).activation();
        }

        /// <summary>
        /// Sprawdza, czy etap gry uległ zmianie.
        /// </summary>
        /// <returns>True, jeśli etap gry uległ zmianie, false w przeciwnym wypadku.</returns>
        private bool checkStage()
        {
            if (NewStage == Name)
            {
                return false;
            }
            else
            {
                Name = NewStage;
                return true;
            }
        }

        /// <summary>
        /// Aktualizuje etap gry na podstawie majątku gracza.
        /// </summary>
        /// <param name="wealth">Aktualny majątek gracza.</param>
        public void newStage(decimal wealth)
        {
            if (checkStage())
            {
                Wealth = wealth;

                if (Wealth > 0 && Wealth <= 100000)
                {
                    Name = "Klasa niższa";
                    TaxRate = 1;
                }
                else if (Wealth > 100000 && Wealth <= 700000)
                {
                    Name = "Klasa średnia";
                    TaxRate = 5;
                }
                else if (Wealth > 700000 && Wealth < 1000000)
                {
                    Name = "Klasa wyższa";
                    TaxRate = 15;
                }
                else if (Wealth >= 1000000)
                {
                    Name = "Milioner";
                }
                else if (Wealth < 0)
                {
                    Name = "Bankrut";
                }
            }
        }

        /// <summary>
        /// Dodaje nowy dodatek do listy dodatków i aktywuje go.
        /// </summary>
        public void newAddition()
        {
            Additions.Add(new StageAddition());
            Additions.ElementAt(Additions.Count - 1).activation();
        }

        /// <summary>
        /// Wykorzystuje wybrany dodatek.
        /// </summary>
        /// <param name="addId">Id dodatku (numer elementu <see cref="Additions"/>).</param>
        /// <param name="x">Podstawowy parametr <see cref="StageAddition.action(decimal, int?, int?)"/>.</param>
        /// <param name="y">Opcjonalny parametr <see cref="StageAddition.action(decimal, int?, int?)"/>.</param>
        /// <param name="z">Opcjonalny parametr <see cref="StageAddition.action(decimal, int?, int?)"/>.</param>
        /// <exception cref="InvalidOperationException">Wywoływany w przypadku błędu.</exception>
        public void useAddition(int addId, decimal x, int? y = null, int? z = null)
        {
            if (!Additions.ElementAt(addId).Active)
            {
                throw new InvalidOperationException("Brak aktywacji dodatku");
            }
            try
            {
                Additions.ElementAt(addId).deactivation();

                if (z == null && y == null)
                {
                    Wealth += Additions.ElementAt(addId).action(x);
                }
                else if (z == null)
                {
                    Wealth += Additions.ElementAt(addId).action(x, y ?? 0);
                }
                else
                {
                    Wealth += Additions.ElementAt(addId).action(x, y ?? 0, z ?? 0);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
