using System.Diagnostics;

namespace MlodyMilioner
{
    /// <summary>
    /// G³ówna klasa programu.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punkt wejœcia dla aplikacji. Inicjalizuje stan gry i uruchamia ekran startowy.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// <summary>
            /// Tworzy nowy obiekt <see cref="GameState"/>, który przechowuje stan gry.
            /// </summary>
            GameState gameState = new GameState();

            /// <summary>
            /// Uruchamia okno startowe aplikacji, przekazuj¹c bie¿¹cy stan gry.
            /// </summary>
            Application.Run(new Start(gameState));
        }
    }
}
