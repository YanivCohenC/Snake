namespace Snake
{
    public partial class PauseMenu : Form
    {
        choice _c;

        public PauseMenu()
        {
            _c = choice.Nothing;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _c = choice.Resume;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _c = choice.exitNoSave;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _c = choice.saveExit;
            Close();
        }

        public choice getChoice()
        {
            return _c;
        }

        public void setDeath(bool s)
        {
            if (s == true)
            {
                label1.Text = "Game Over";
                button1.Hide();
                button2.Hide();
                button3.Location = new Point(12, 42);
                this.Size = new Size(270, 94);
            }
            else
            {
                label1.Text = "Game is currently paused";
                button1.Show();
                button2.Show();
                button3.Location = new Point(12, 144);
                this.Size = new Size(270, 201);
            }
        }
    }

    public enum choice
    {
        Nothing, Resume, exitNoSave, saveExit
    }
}
