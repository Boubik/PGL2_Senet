using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senet_pgl2
{
    class Play
    {
        public static bool color;
        public static int figures;

        public static void Start(int newFigures = 5, bool newColor = true)
        {
            SetColor(newColor);
            if (figures == 0)
            {
                SetFigures(newFigures);
            }
            int input = 0;
            bool repeat = false;

            Game CZgame = new Game(figures, color);
            while (true)
            {
                Console.Clear();
                if (color)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("1) ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Hráč proti hráči (2 hráči)\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("2) ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Hráč proti počítači (1 hráč)\n");
                }
                else
                {
                    Console.WriteLine("1) hráč proti hráči (2 hráči)");
                    Console.WriteLine("2) hráč proti počítači (1 hráč)");
                }
                if (repeat)
                {
                    if (color)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("špatný vstup");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("špatný vstup");
                    }
                }
                Console.Write("\nVyber si: ");
                repeat = true;

                int.TryParse(Console.ReadLine(), out input);
                if (input == 1 || input == 2)
                {
                    break;
                }
            }

            switch (input)
            {
                case 1:
                    Console.Clear();
                    TwoPlayers(CZgame);
                    break;

                case 2:
                    Console.Clear();
                    OnePlayers(CZgame);
                    break;
            }
        }
        public static void TwoPlayers(Game game)
        {
            while (true)
            {
                while (true)
                {
                    Sticks.Roll();
                    Render.PrintArray(game);
                    game.Move(1);
                    game.Status();
                    if (Sticks.GetNumber() == 3 || Sticks.GetNumber() == 4)
                    {
                        break;
                    }

                }

                while (true)
                {
                    Sticks.Roll();
                    Render.PrintArray(game);
                    game.Move(2);
                    game.Status();
                    if (Sticks.GetNumber() == 3 || Sticks.GetNumber() == 4)
                    {
                        break;
                    }

                }
            }
        }

        public static void OnePlayers(Game game)
        {
            while (true)
            {
                while (true)
                {
                    Sticks.Roll();
                    Render.PrintArray(game);
                    game.Move(1);
                    game.Status();
                    if (Sticks.GetNumber() == 3 || Sticks.GetNumber() == 4)
                    {
                        break;
                    }
                }

                while (true)
                {
                    Sticks.Roll();
                    Render.PrintArray(game);
                    game.Move(2, true);
                    game.Status();
                    if (Sticks.GetNumber() == 3 || Sticks.GetNumber() == 4)
                    {
                        break;
                    }
                }
            }
        }

        public static void SetColor(bool newColor)
        {
            color = newColor;
        }

        public static void SetFigures(int newFigures)
        {
            figures = newFigures;
        }
    }
}
