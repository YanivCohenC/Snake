using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace Snake
{
    internal class Apple : Food
    {
       
        public Apple()
        {
            _image = new PictureBox();
            _image.BackgroundImage = Snake.Properties.Resources.Apple;
            _image.BackgroundImageLayout = ImageLayout.Stretch;
            _time = 10;
        }

        public override int effect()
        {
            return 1;
        }

        public PictureBox getPicture()
        {
            return _image;
        }
    }
}
