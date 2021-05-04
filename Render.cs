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
            int i = 0;
            int[] array = game.GetArray();

            while (i != 10)
            {
                Console.Write(array[i] + " ");
                i++;
            }

            Console.Write("\n");

            i = 19;
            while (i != 9)
            {
                Console.Write(array[i] + " ");
                i--;
            }

            Console.Write("\n");

            i = 20;
            while (i != 30)
            {
                Console.Write(array[i] + " ");
                i++;
            }
        }
    }
}
