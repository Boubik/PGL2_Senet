

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
