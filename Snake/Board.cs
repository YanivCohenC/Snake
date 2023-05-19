using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Timer = System.Windows.Forms.Timer;

namespace Snake
{
    public partial class Board : Form
    {
        public const int ROWS = 20;
        public const int COLS = 20;
        public const int SIZE_X = 50;
        public const int SIZE_Y = 50;

        private Menu mainMenu;
        private List<Player> _playerList; // For scoreboard
        private Slot[,] _gameMatrix; // For all of the elements on board
        private List<snakeBody> _p1Session; // p1 brain
        private List<snakeBody> _p2Session;

        private Timer countdownTimer;
        private Timer boardTimer;

        public Board(Menu other)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            mainMenu = other;
            _playerList = new List<Player>();
            _gameMatrix = new Slot[ROWS, COLS];
        }

        private void Board_Load(object sender, EventArgs e)
        {
            string p1Name = p1NameLabel.Text = mainMenu.getP1Name();
            string p2Name = p2NameLabel.Text = mainMenu.getP2Name();
            string p2Controller = mainMenu.getP2Controller();

            if (p1Name == "")
            {
                p1NameLabel.Text = p1Name = "Snake 1";
            }

            Player p1 = new Player(p1Name, mainMenu.getP1Controller(), mainMenu.getP1Type());
            _playerList.Add(p1);
            _p1Session = new List<snakeBody>();
            _p1Session.Add(new snakeBody(true, p1.getPlayerType()));
            p1NameLabel.Visible = p1ScoreLabel1.Visible = p1ScoreLabel2.Visible = true;
            if (p2Controller != "" && p2Controller != "Disabled")
            {
                if (p2Name == "")
                {
                    p2NameLabel.Text = p2Name = "Snake 2";
                }


                Player p2 = new Player(p1Name, p2Controller, mainMenu.getP2Type());
                _playerList.Add(p2);
                p2NameLabel.Visible = p2ScoreLabel1.Visible = p2ScoreLabel2.Visible = true;
            }
            initializeMatrix();

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1 second
            countdownTimer.Tick += countDown_Tick;
            countdownTimer.Start();

            


            //readMatrix();
        }

        private void Board_Shown(object sender, EventArgs e)
        {
            boardTimer = new System.Windows.Forms.Timer();
            boardTimer.Interval = 500; // 0.5 second
            boardTimer.Tick += boardTimer_Tick;
            boardTimer.Start();
        }


        static int count = 5;
        private void countDown_Tick(object sender, EventArgs e)
        {
            count--;
            countdownLabel.Text = "Game will start in: " + count;

            if (count == 0)
            {
                countdownTimer.Stop();
                countdownLabel.Hide();
                // Start the game here
            }
        }

        private void boardTimer_Tick(object sender, EventArgs e)
        {

        }

        private void Board_FormClosed(object sender, FormClosedEventArgs e)
        {
            // save data after game
            // warning message exit without saving? or with

            mainMenu.Show();
        }

        private void initializeMatrix()
        {
            this.AutoScroll = true;
            int y = 0;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (_gameMatrix[i, j] == null) // Case empty slot
                    {
                        _gameMatrix[i, j] = new Slot();
                        this.Controls.Add(_gameMatrix[i, j].getPicture());
                        _gameMatrix[i, j].getPicture().Location = new Point(i * SIZE_X + 330, j * SIZE_Y + 175);
                        _gameMatrix[i, j].getPicture().Size = new Size(SIZE_X, SIZE_Y);
                    }
                }
            }
        }

        private void readMatrix()
        {
            // For confirm visibility of all images set 
            //int y = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if ()


            //        // Following three lines set the images(picture boxes) locations

            //    }

            //}
        }
    }
}
