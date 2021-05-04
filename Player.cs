
using System.Collections.Generic;

namespace plg2_senet
{
    class Player
    {
        List<Figure> figures = new List<Figure>();
        public Player(int figures, bool odd = true)
        {
            int i = 0;
            int position;

            //arry 0 is "1" so it is odd
            if (odd)
            {
                position = 0;
            }
            else
            {
                position = 1;
            }
            while (figures != i)
            {
                //figures.Add(new Figure(position));
                position += 2;
                i++;
            }

        }

        public List<Figure> GetFigures()
        {
            return figures;
        }
    }
}
