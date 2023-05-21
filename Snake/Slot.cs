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
        private void randomFood()
        {
            int i, j;
            int foodType;
            Random rnd = new Random();
            i = rnd.Next(25);
            j = rnd.Next(25);
            foodType = rnd.Next(3);

            switch (foodType)
            {
                case 0:
                    _image = new PictureBox();
                    _image.BackgroundImage = Snake.Properties.Resources.Apple;
                    break;
                case 1:
                    _image = new PictureBox();
                    _image.BackgroundImage = Snake.Properties.Resources.Cherry;
                    break;
                case 2:
                    _image = new PictureBox();
                    _image.BackgroundImage = Snake.Properties.Resources.Poop;
                    break;

            }
        }
    }
}