namespace Snake
{
    [Serializable]
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