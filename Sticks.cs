using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plg2_senet
{
    class Sticks
    {
        public static Random r = new Random();
        static bool[] aSticks = new bool[5];
        static int i, k, number;

        public static bool[] Roll()
        {
            i = 0;
            number = 0;

            while (i != 4)
            {
                k = r.Next(0, 2);
                aSticks[i] = k != 0;
                number += k;
                i++;
            }
            if (number == 0)
            {
                number = 5;
            }

            return aSticks;
        }

        public static int GetNumber()
        {
            return number;
        }
        public static int GetStics()
        {
            return aSticks;
        }
    }
}
