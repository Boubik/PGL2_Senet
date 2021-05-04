

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

            player1 = new Player(5);
            player2 = new Player(5, false);
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
