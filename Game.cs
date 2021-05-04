

using System;
using System.Collections.Generic;

namespace plg2_senet
{
    class Game
    {
        public int[] array = new int[30];
        bool color;
        Player player1;
        Player player2;

        public Game(int figures, bool color = true)
        {
            this.color = color;
            int i = 0;

            while (i != 30)
            {
                array[i] = 0;
                i++;
            }
            array[25] = 5; //roll 5
            array[26] = 1; //go bac to 15 (array 14)
            array[27] = 3; //roll 3
            array[28] = 2; //roll 2
            array[29] = 5; //roll any number to win

            player1 = new Player(5);
            player2 = new Player(5, false);
        }

        public Player GetPlayer1()
        {
            return player1;
        }
        public Player GetPlayer2()
        {
            return player2;
        }

        public bool GetColor()
        {
            return color;
        }

        public int[] GetArray()
        {
            return array;
        }

        public void Status()
        {
            bool end = true;
            foreach (Figure figure in player1.GetFigures())
            {
                if (figure.IsAlive())
                {
                    end = false;
                    break;
                }
            }
            if (end)
            {
                End(1);
            }

            end = true;
            foreach (Figure figure in player2.GetFigures())
            {
                if (figure.IsAlive())
                {
                    end = false;
                    break;
                }
            }
            if (end)
            {
                End(1);
            }
        }

        public void End(int i)
        {
            Console.Clear();
            Render.PrintArray(this);
            if (color)
            {
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nprvní hráč");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\ndruhý hráč");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" vyhrál!");
            }
            Console.ReadLine();
        }

        public void UpdateArray(int[] newArray)
        {
            array = newArray;
        }

        /*
         * true => no errors
         * false => didnt coplete corectly
         */
        public bool UpdateArrayAtPosition(int position, int value)
        {
            if (position >= 0 && position < 30)
            {
                array[position] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * 1 => player 1
         * 2 => player 2
         */
        public int Input(int player, bool repeat = false)
        {
            int i, number, input;
            bool[] aSticks;

            //player
            Console.Write("\n");
            if (color)
            {
                if (player == 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("hraje ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("hráč jedna");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("hraje ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("hráč dva");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("\n");
            }
            else
            {
                if (player == 1)
                {
                    Console.Write("hraje hráč jedna");
                }
                else
                {
                    Console.Write("hraje hráč dva");
                }
                Console.Write("\n");
            }

            //roll sticks
            Console.Write("hodil jsi: ");
            i = 0;
            aSticks = Sticks.GetSticks();
            number = Sticks.GetNumber();
            if (color)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(number);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" = ");
            }
            else
            {
                Console.Write(number + " = ");
            }
            while (i != 4)
            {
                Console.Write(Convert.ToInt32(aSticks[i]) + " ");
                i++;
            }

            if (repeat)
            {
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("\nšpatný vstup");
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            //picking next move
            Console.Write("\njakým kamenem budeš hrát? (");

            List<Figure> figures;
            if (player == 1)
            {
                figures = GetAvaibleFigures(player1, player2);

            }
            else
            {
                figures = GetAvaibleFigures(player2, player1);
            }


            i = 0;
            foreach (Figure figure in figures)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(figure.GetPosition() + 1);
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                i++;
            }

            Console.Write("): ");
            input = Convert.ToInt32(Console.ReadLine());
            repeat = true;
            foreach (Figure figure in figures)
            {
                if (figure.GetPosition() == input - 1)
                {
                    repeat = false;
                    break;
                }
            }
            if (repeat)
            {
                Console.Clear();
                Render.PrintArray(this);
                this.Input(player, repeat = true);
            }
            return input - 1;
        }

        public void Move(int playern)
        {
            int input = Input(playern);
            int number = Sticks.GetNumber();
            List<Figure> figures;
            Player me, other;
            if (playern == 1)
            {
                figures = GetAvaibleFigures(player1, player2);
                other = this.player2;
            }
            else
            {
                figures = GetAvaibleFigures(player2, player1);
                other = this.player1;
            }

            foreach (Figure figure in figures)
            {
                if (figure.GetPosition() == input)
                {
                    if (figure.GetPosition() + number >= 30)
                    {
                        figure.SetDeath();
                        break;
                    }
                    if (other.SearchForPosition(figure.GetPosition() + number) < 0)
                    {
                        figure.SetPosition(figure.GetPosition() + number);
                    }
                    else
                    {
                        int m = figure.GetPosition();
                        figure.SetPosition(figure.GetPosition() + number);
                        other.SetNewPosition(figure.GetPosition() + number, m);
                    }
                    break;
                }
            }
        }

        public List<Figure> GetAvaibleFigures(Player me, Player other)
        {
            int number = Sticks.GetNumber();
            int i = 0;
            List<Figure> resault = new List<Figure>();
            foreach (Figure p1 in me.GetFigures())
            {
                if (p1.GetPosition() + number < 30)
                {
                    if (me.SearchForPosition(p1.GetPosition() + number) < 0)
                    {
                        if (other.SearchForPosition(p1.GetPosition() + number) < 0)
                        {
                            resault.Add(p1);
                        }
                        else
                        {
                            if (other.SearchForPosition(p1.GetPosition() + number - 1) < 0 && other.SearchForPosition(p1.GetPosition() + number + 1) < 0)
                            {
                                resault.Add(p1);
                            }
                        }
                    }
                }
                i++;
            }
            return resault;
        }
    }
}
