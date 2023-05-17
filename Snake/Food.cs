using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food : Slot
    {
        private protected int _time;

        public int getTime()
        {
            return _time;
        }
    }
}