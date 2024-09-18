using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMaduussTARpv23
{
    internal class GameOver
    {
        public static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Green;

            string gameOverText = "   G A M E     O V E R     ";

            for (int i = 0; i < 5; i++)
            {
                WriteText(gameOverText, xOffset, yOffset + i);
            }
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.Write(text);
        }
    }
}
