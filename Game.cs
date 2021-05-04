

namespace plg2_senet
{
    class Game
    {
        public int[] array = new int[30];

        public Game(int figures)
        {
            int i = 0;

            while (i != 30)
            {
                array[i] = 0;
                i++;
            }

            //zavolání hráčů
        }

        public int[] GetArray()
        {
            return array;
        }

        public void UpdateArray(int[] newArray)
        {
            array = newArray;
        }

        /**
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
    }
}
