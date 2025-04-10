using System.Diagnostics;

namespace MlodyMilioner
{
    /// <summary>
    /// G��wna klasa programu.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punkt wej�cia dla aplikacji. Inicjalizuje stan gry i uruchamia ekran startowy.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// <summary>
            /// Tworzy nowy obiekt <see cref="GameState"/>, kt�ry przechowuje stan gry.
            /// </summary>
            GameState gameState = new GameState();

            /// <summary>
            /// Uruchamia okno startowe aplikacji, przekazuj�c bie��cy stan gry.
            /// </summary>
            Application.Run(new Start(gameState));
        }
    }
}
