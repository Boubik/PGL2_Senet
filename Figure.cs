using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plg2_senet
{
    class Figure
    {
        int position;
        bool alive;
        int name;

        public Figure(int position, int name)
        {
            alive = true;
            this.name = name;
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

        public int GetName()
        {
            return name;
        }
    }
}
