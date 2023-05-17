using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Cherry : Food
    {
        public Cherry()
        {
            //_image.BackgroundImage = Snake.Properties.Resources.Cherry;
        }

        public int effect()
        {
            return 2;
        }
    }
}
