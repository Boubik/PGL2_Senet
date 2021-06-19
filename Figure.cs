using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senet_pgl2
{
    class Figure
    {
        int position;
        bool alive;

        public Figure(int position, int name)
        {
            alive = true;
            SetPosition(position);
        }

        public void SetPosition(int position)
        {
            this.position = position;
        }

        public int GetPosition()
        {
            return position;
        }

        public void SetDeath()
        {
            alive = false;
        }

        public bool IsAlive()
        {
            return alive;
        }
    }
}
