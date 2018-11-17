using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4thProject
{
    public class TrafficLight
    {
        public bool red;
        public delegate void TrafficLightStateHandler();
        public TrafficLightStateHandler ChangeStatus;
        public TrafficLight()
        {
            red = true;
            ChangeStatus = Color;
        }

        public void Change()
        {
            ChangeStatus();
        }

        public void Color()
        {
            red = !red;
        }
    }
}
