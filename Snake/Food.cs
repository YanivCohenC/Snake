using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;

namespace Snake
{
    internal class Food : Slot
    {
        private protected int _time;
        private Timer _foodTimer;

        public int getTime()
        {
            return _time;
        }

        public Timer GetTimer()
        {
            return _foodTimer;
        }
    }
}