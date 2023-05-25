namespace Snake
{
    [Serializable]
    internal class Poop : Food
    {
        public Poop()
        {
            _image = new PictureBox();
            _image.BackgroundImage = Snake.Properties.Resources.Poop;
            _image.BackgroundImageLayout = ImageLayout.Stretch;
            _time = 10;
        }

        public override int effect()
        {
            return -1;
        }

        public PictureBox getPicture()
        {
            return _image;
        }
    }
}
