namespace Snake
{
    [Serializable]
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

        public bool isExpired()
        {
            return _expired;
        }

        public PictureBox getPicture()
        {
            return _image;
        }
    }
}
