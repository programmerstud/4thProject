using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4thProject
{
    public class Auto 
    {
        public int X;
        public int Speed;

        public Auto(int s, int Height)
        {
            Speed = s;
            X = 0;
        }

        public void Move()
        {
            X += Speed;
        }
    }
}
