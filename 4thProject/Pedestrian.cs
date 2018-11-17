using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4thProject
{
    public class Pedestrian
    {
        public int Y;
        public int Speed;
        public bool On;

        public Pedestrian(int s, int Width)
        {
            Speed = s;
            Y = Width / 2;
            On = false;
        }
        public void Move()
        {
            Y += Speed;
        }
    }
}
