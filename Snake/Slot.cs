using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Slot
    {
        private PictureBox _image;

        public Slot()
        {
            _image = new PictureBox();
        }
        public PictureBox getPicture()
        {
            return _image;
        }
    }
}