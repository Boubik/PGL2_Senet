using System;
using System.Linq;
using System.Collections.Generic;

namespace plg2_senet
{
    class Game
    {
        public int[] array = new int[30];
        bool color;
        Player player1;
        Player player2;
        bool reverse;
        bool skip_move;

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
                    Console.Write("\nprvní hráč ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\ndruhý hráč ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("vyhrál!");
            }
            else
            {

                if (i == 1)
                {
                    Console.Write("\nprvní hráč vyhrál!");
                }
                else
                {
                    Console.Write("\ndruhý hráč vyhrál!");
                }
            }
            Console.ReadLine();
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
                    Console.ForegroundColor = ConsoleColor.Blue;
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

            if (skip_move)
            {
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("\nnemáš jak se hýbat. zmáčkni enter pro pokračování ");
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ReadLine();
                return 99;
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

        public int AiSelectOption()
        {
            Random r = new Random();
            int i, k;
            List<Figure> figures = GetAvaibleFigures(player2, player1);
            if (figures.Count > 0)
            {
                k = r.Next(0, figures.Count - 1);
                Console.WriteLine("random je " + k);
                i = 0;
                foreach (Figure figure in figures)
                {
                    if (k == i)
                    {
                        AiWrite(figure.GetPosition() + Sticks.GetNumber());
                        return figure.GetPosition();
                    }
                    i++;
                }
            }
            AiWrite(0);
            return 99;
        }

        public void AiWrite(int move)
        {
            Console.WriteLine();
            Console.Write("hreje ");
            if (color)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("AI\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            //roll sticks
            Console.Write("hodil jsi: ");
            int i = 0;
            bool[] aSticks = Sticks.GetSticks();
            int number = Sticks.GetNumber();
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
            if (move == 0)
            {
                Console.Write("\nAI se nemůže hnout");
            }
            else
            {
                Console.Write("\nAI posune kámen z ");
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(move + 1 - Sticks.GetNumber());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(move + 1 - Sticks.GetNumber());
                }
                Console.Write(" na ");
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(move + 1);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(move + 1);
                }

            }
            Console.Write(" pro pokračování zmáčkni ");
            if (color)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("enter ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("enter ");
            }
            Console.ReadLine();
        }
        public void Move(int playern, bool ai = false)
        {
            int input;
            if (ai)
            {
                input = AiSelectOption();
            }
            else
            {
                input = Input(playern);
            }
            if (input != 99)
            {
                int number = Sticks.GetNumber();
                List<Figure> figures;
                Player other;
                int i;
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
                            if (figure.GetPosition() + number == 26)
                            {
                                i = 0;
                                while (true)
                                {
                                    if (player1.SearchForPosition(14 + i) < 0 && player2.SearchForPosition(14 + i) < 0)
                                    {
                                        figure.SetPosition(14 + i);
                                        break;
                                    }
                                    if (player1.SearchForPosition(14 - i) < 0 && player2.SearchForPosition(14 - i) < 0)
                                    {
                                        figure.SetPosition(14 - i);
                                        break;
                                    }
                                    i++;
                                }
                                break;
                            }
                            figure.SetPosition(figure.GetPosition() + number);
                        }
                        else
                        {
                            int m = figure.GetPosition();
                            other.SetNewPosition(figure.GetPosition() + number, m);
                            figure.SetPosition(figure.GetPosition() + number);
                        }
                        break;
                    }
                }
            }
        }

        public List<Figure> GetAvaibleFigures(Player me, Player other)
        {
            int move = Sticks.GetNumber();
            if (reverse)
            {
                move = -move;
            }
            int i = 0;
            List<Figure> resault = new List<Figure>();
            foreach (Figure p1 in me.GetFigures())
            {
                if (me.SearchForPosition(p1.GetPosition() + move) < 0)
                {
                    if (other.SearchForPosition(p1.GetPosition() + move) < 0 && SpecialPlacesMagic(p1.GetPosition(), move))
                    {
                        resault.Add(p1);
                    }
                    else
                    {
                        if (other.SearchForPosition(p1.GetPosition() + move - 1) < 0 && other.SearchForPosition(p1.GetPosition() + move + 1) < 0 && SpecialPlacesMagic(p1.GetPosition(), move))
                        {
                            resault.Add(p1);
                        }
                    }
                }
                i++;
            }
            if (resault.Count > 0)
            {
                reverse = false;
                skip_move = false;
            }
            else
            {
                reverse = true;
                resault = GetAvaibleFigures(me, other);
                if (resault.Count > 0)
                {
                    skip_move = true;
                }
                else
                {
                    skip_move = false;
                }
            }
            List<Figure> orderedList = resault.OrderBy(x => x.GetPosition()).ToList();
            return orderedList;
        }
        /*
         * false => you cant use this figure
         * true => you can use this figure
         */
        public bool SpecialPlacesMagic(int position, int move)
        {
            if (array[position] > 1)
            {
                if (move == array[position])
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
