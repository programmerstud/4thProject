using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4thProject
{
    public class ES : EmergencyService
    {
        public delegate void EmergencyState();
        public event EmergencyState EmergencySituation;
        public int Speed;
        public int X;
        public bool IsOn;
        public ES(int s, int Height) 
        {
            Speed = s;
            X = Height;
            IsOn = false;
            EmergencySituation = Ride;
        }
        public double Probability()
        {
            Random rnd = new Random();
            return rnd.NextDouble();
        }
        public void Dangerous()
        {
            if (Probability() > 0.8)
            {
                EmergencySituation();
            }
        }
        private void Ride()
        {
            IsOn = true;
        }
        public void Move()
        {
            X -= Speed;
        }
    }
}
