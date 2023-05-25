using Timer = System.Windows.Forms.Timer;

namespace Snake
{
    [Serializable]
    internal class Food : Slot
    {
        private protected int _time;
        private protected Timer _foodTimer;
        private protected bool _expired;

        public Food()
        {
            _image = new PictureBox();
            _expired = false;
            _foodTimer = new Timer();
            _foodTimer.Tick += food_Tick;
            _foodTimer.Interval = 1000; // 1 second
        }

        public int getTime()
        {
            return _time;
        }

        public bool isExpired()
        {
            return _expired;
        }

        public Timer getTimer()
        {
            return _foodTimer;
        }

        public PictureBox getPicture()
        {
            return _image;
        }

        public virtual int effect()
        {
            return 0;
        }

        private void food_Tick(object sender, EventArgs e)
        {
            if (--_time == 0)
            {
                _foodTimer.Stop();
                _expired = true;
                _image.BackgroundImage = Snake.Properties.Resources.Empty;
            }
        }
    }
}