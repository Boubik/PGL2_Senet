using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senet_pgl2
{
    class Render
    {
        public static void PrintArray(Game game)
        {
            Console.Clear();
            int i, k;
            int[] array = game.GetArray();
            String[] translate = new String[10];
            translate[1] = "Bac";
            translate[2] = "Ro2";
            translate[3] = "Ro3";
            translate[4] = "Ro4";
            translate[5] = "Ro5";
            translate[9] = "Rox";

            Player player1 = game.GetPlayer1();
            Player player2 = game.GetPlayer2();

            //hints
            Console.Write("¯¯¯¯¯¯\n");
            Console.Write("P1 ==> figurky hráče 1\n");
            Console.Write("P2 ==> figurky hráče 2\n");
            Console.Write("Bac ==> vrátí tě zpět na políčko 15 pokuď je plné tak políčku nejbližší\n");
            Console.Write("Rox ==> musíš hodit x aby jsi se mohl z tohoto políčka dále posunout\n");
            Console.Write("______\n\n");

            //border
            i = 0;
            Console.Write(" ");
            while (i != 10)
            {
                Console.Write("______");
                i++;
            }
            Console.Write("\n| ");

            //fist line
            i = 0;
            while (i != 10)
            {
                if (game.GetColor())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (i == 9)
                    {
                        Console.Write("  " + (i + 1));
                    }
                    else
                    {
                        Console.Write("  " + (i + 1) + " ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" |");
                }
                else
                {
                    if (i == 9)
                    {
                        Console.Write("  " + (i + 1) + " |");
                    }
                    else
                    {
                        Console.Write("  " + (i + 1) + "  |");
                    }
                }
                i++;
            }
            Console.Write("\n| ");

            //first line second floor
            i = 0;
            while (i != 10)
            {
                k = player1.SearchForPosition(i);
                if (k >= 0)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  P1");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write("  P1 |");
                    }
                    i++;
                    continue;
                }

                k = player2.SearchForPosition(i);
                if (k >= 0)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("  P2");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write("  P2 |");
                    }
                    i++;
                    continue;
                }
                Console.Write("     |");
                i++;
            }

            Console.Write("\n| ");

            //first line third floor
            i = 0;
            while (i != 10)
            {
                if (translate[array[i]] != null)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + translate[array[i]]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write(" " + translate[array[i]] + " |");
                    }
                }
                else
                {
                    Console.Write("     |");
                }
                i++;
            }

            Console.Write("\n|");

            //border
            i = 0;
            while (i != 10)
            {
                Console.Write("------");
                i++;
            }
            Console.Write("|\n| ");

            //second line
            i = 19;
            while (i != 9)
            {
                if (game.GetColor())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("  " + (i + 1) + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                else
                {
                    Console.Write("  " + (i + 1) + " |");
                }
                i--;
            }
            Console.Write("\n| ");

            //second line second floor
            i = 19;
            while (i != 9)
            {
                k = player1.SearchForPosition(i);
                if (k >= 0)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  P1");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write("  P1 | ");
                    }
                    i--;
                    continue;
                }

                k = player2.SearchForPosition(i);
                if (k >= 0)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("  P2");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write("  P2 |");
                    }
                    i--;
                    continue;
                }
                Console.Write("     |");
                i--;
            }

            Console.Write("\n| ");

            //second line third floor
            i = 19;
            while (i != 9)
            {
                if (translate[array[i]] != null)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + translate[array[i]]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write(" " + translate[array[i]] + " |");
                    }
                }
                else
                {
                    Console.Write("     |");
                }
                i--;
            }

            Console.Write("\n|");

            //border
            i = 0;
            while (i != 10)
            {
                Console.Write("------");
                i++;
            }
            Console.Write("|\n| ");


            //third line
            i = 20;
            while (i != 30)
            {
                if (game.GetColor())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("  " + (i + 1) + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                else
                {
                    Console.Write("  " + (i + 1) + " |");
                }
                i++;
            }
            Console.Write("\n| ");

            //third line second floor
            i = 20;
            while (i != 30)
            {
                k = player1.SearchForPosition(i);
                if (k >= 0)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  P1");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write("  P1 |");
                    }
                    i++;
                    continue;
                }

                k = player2.SearchForPosition(i);
                if (k >= 0)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("  P2");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write("  P2 |");
                    }
                    i++;
                    continue;
                }
                Console.Write("     |");
                i++;
            }
            Console.Write("\n| ");

            //third line third floor
            i = 20;
            while (i != 30)
            {
                if (translate[array[i]] != null)
                {
                    if (game.GetColor())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + translate[array[i]]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write(" " + translate[array[i]] + " |");
                    }
                }
                else
                {
                    Console.Write("     |");
                }
                i++;
            }

            Console.Write("\n");

            //border
            i = 0;
            Console.Write(" ");
            while (i != 10)
            {
                Console.Write("¯¯¯¯¯¯");
                i++;
            }
            Console.Write("\n");
            game.SetReverse(false);
        }
    }
}
