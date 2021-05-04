using System;

namespace plg2_senet
{
    class Program
    {
        static void Main(string[] args)
        {
            // colors in terminal
            bool color = true;
            int input = 0;
            bool repeat = false;

            Game CZgame = new Game(5, color);
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
                input = Convert.ToInt32(Console.ReadLine());
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
                    break;
            }


            //Console.ReadLine();
        }

        public static void TwoPlayers(Game game)
        {
            while (true)
            {
                Sticks.Roll();
                Render.PrintArray(game);
                game.Move(1);
                game.Status();

                Sticks.Roll();
                Render.PrintArray(game);
                game.Move(2);
                game.Status();
            }
        }
    }
}
