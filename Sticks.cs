using System;

namespace senet_pgl2
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

        public static bool[] GetSticks()
        {
            return aSticks;
        }
    }
}
