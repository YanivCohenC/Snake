using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Poop : Food
    {
        public Poop()
        {
            _image.BackgroundImage = Snake.Properties.Resources.Poop;
        }

        public int effect()
        {
            return -1;
        }
    }
}
