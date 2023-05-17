﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Apple : Food
    {
        public Apple()
        {
            _image.BackgroundImage = Snake.Properties.Resources.Apple;
        }

        public int effect()
        {
            return 1;
        }
    }
}
