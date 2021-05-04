using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plg2_senet
{
    class Render
    {
        public static void PrintArray(Game game)
        {
            int i;
            int[] array = game.GetArray();

            //border
            i = 0;
            Console.Write(" __");
            while (i != 10)
            {
                Console.Write("_____");
                i++;
            }
            Console.Write("\n| ");

            //fist line
            i = 0;
            while (i != 10)
            {
                Console.Write(" " + "kek" + " ");
                i++;
            }
            Console.Write(" |");

            Console.Write("\n| ");

            //first line second floor
            i = 0;
            while (i != 10)
            {
                Console.Write(" " + "pep" + " ");
                i++;
            }
            Console.Write(" |");

            Console.Write("\n|");

            //border
            i = 0;
            Console.Write("--");
            while (i != 10)
            {
                Console.Write("-----");
                i++;
            }
            Console.Write("|\n| ");

            //second line
            i = 19;
            while (i != 9)
            {
                Console.Write(" " + "kek" + " ");
                i--;
            }
            Console.Write(" |");

            Console.Write("\n| ");

            //second line second floor
            i = 19;
            while (i != 9)
            {
                Console.Write(" " + "pep" + " ");
                i--;
            }
            Console.Write(" |");

            Console.Write("\n|");

            //border
            i = 0;
            Console.Write("--");
            while (i != 10)
            {
                Console.Write("-----");
                i++;
            }
            Console.Write("|\n| ");


            //third line
            i = 20;
            while (i != 30)
            {
                Console.Write(" " + "kek" + " ");
                i++;
            }
            Console.Write(" |\n| ");

            //third line second floor
            i = 20;
            while (i != 30)
            {
                Console.Write(" " + "pep" + " ");
                i++;
            }
            Console.Write(" |");

            Console.Write("\n");

            //border
            i = 0;
            Console.Write(" ¯¯");
            while (i != 10)
            {
                Console.Write("¯¯¯¯¯");
                i++;
            }
        }
    }
}
