
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
                this.figures.Add(new Figure(position, i));
                position += 2;
                i++;
            }
            if (odd)
            {
                this.figures[0].SetPosition(5);
                this.figures[1].SetPosition(6);
            }
            else
            {
                this.figures[0].SetPosition(7);
                this.figures[1].SetPosition(8);
            }

        }

        public List<Figure> GetFigures()
        {
            return figures;
        }

        public int SearchForPosition(int position)
        {
            int i = 0;
            foreach (Figure figure in figures)
            {
                if (figure.IsAlive() && position == figure.GetPosition())
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public void SetNewPosition(int oldPosition, int newPosition)
        {
            foreach (Figure figure in figures)
            {
                if (figure.GetPosition() == oldPosition)
                {
                    figure.SetPosition(newPosition);
                    break;
                }
            }
        }
    }
}
