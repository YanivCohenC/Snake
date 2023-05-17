using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Slot
    {
        private protected PictureBox _image;

        public Slot()
        {
            _image = new PictureBox();
            _image.BackgroundImage = Snake.Properties.Resources.Empty;
            _image.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public PictureBox getPicture()
        {
            return _image;
        }
    }
}