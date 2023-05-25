namespace Snake
{
    [Serializable]
    internal class Cherry : Food
    {
        public Cherry()
        {
            _image = new PictureBox();
            _image.BackgroundImage = Snake.Properties.Resources.Cherry;
            _image.BackgroundImageLayout = ImageLayout.Stretch;
            _time = 5;
        }

        public override int effect()
        {
            return 2;
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
