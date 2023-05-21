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
        public const int SIZE_X = 32;
        public const int SIZE_Y = 32;

        private Menu mainMenu;
        private List<Player> _playerList; // For scoreboard
        private Slot[,] _gameMatrix; // For all of the elements on board

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
            _playerList[0].getCoordinates().Add(new snakeBody(true, p1.getPlayerType(), (int)Direction.Down, 6 ,1));
            _playerList[0].getCoordinates().Add(new snakeBody(false, p1.getPlayerType(), (int)Direction.Down, 6 ,0));

            p1NameLabel.Visible = p1ScoreLabel1.Visible = p1ScoreLabel2.Visible = true;
            if (p2Controller != "" && p2Controller != "Disabled")
            {
                if (p2Name == "")
                {
                    p2NameLabel.Text = p2Name = "Snake 2";
                }


                Player p2 = new Player(p1Name, p2Controller, mainMenu.getP2Type());
                _playerList.Add(p2);
                _playerList[1].getCoordinates().Add(new snakeBody(true, p2.getPlayerType(), (int)Direction.Up, 13, 18));
                _playerList[1].getCoordinates().Add(new snakeBody(false, p2.getPlayerType(), (int)Direction.Up, 13, 19));
                p2NameLabel.Visible = p2ScoreLabel1.Visible = p2ScoreLabel2.Visible = true;
            }
            initializeMatrix();

            updateSlot(6, 0, false, _playerList[0].getPlayerType(), Direction.Down);
            updateSlot(6, 1, true, _playerList[0].getPlayerType(), Direction.Down);
            

            if (_playerList.Count > 1)
            {
                updateSlot(13, 19, false, _playerList[1].getPlayerType(), Direction.Up);
                updateSlot(13, 18, true, _playerList[1].getPlayerType(), Direction.Up);
            }


            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1 second
            countdownTimer.Tick += countDown_Tick;
            countdownTimer.Start();

            boardTimer = new System.Windows.Forms.Timer();
            boardTimer.Interval = 500; // 1 second
            boardTimer.Tick += boardTimer_Tick;


            //readMatrix();
        }

        private void Board_Shown(object sender, EventArgs e)
        {
            
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
                boardTimer.Start();
                // Start the game here
            }
        }

        private void boardTimer_Tick(object sender, EventArgs e)
        {
            int x = _playerList[0].getCoordinates()[0].getX();
            int y = _playerList[0].getCoordinates()[0].getY();
            Direction d = (Direction)_playerList[0].getCoordinates()[0].getDirection();
            if (d == Direction.Up)
            {
                y--;
            }
            if (d == Direction.Down)
            {
                _playerList[0].getCoordinates()[0].setY(++y);
            }
            if (d == Direction.Left)
            {
                x--;
            }
            if (d == Direction.Right)
            {
                x++;
            }
            updateSlot(x, y, true, _playerList[0].getPlayerType(), d);
            this.Invalidate();
            // changes of snake and board
        }

        public void updateSlot(int x, int y, bool isHead, int type, Direction d)
        {
            Point p = _gameMatrix[x, y].getPicture().Location;
            this.Controls.Remove(_gameMatrix[x, y].getPicture());
            _gameMatrix[x, y] = new snakeBody(isHead, type, (int)d, x, y);
            _gameMatrix[x, y].getPicture().Location = p;
            _gameMatrix[x, y].getPicture().Size = new Size(SIZE_X, SIZE_Y);
            this.Controls.Add(_gameMatrix[x, y].getPicture());
        }

        private void Board_KeyDown(object sender, KeyEventArgs e, string keyController, int direction)
        {
            if (e.KeyCode == Keys.A)
            {
                if (direction == 0) 
                    direction = 1;
                if (direction == 1)
                    direction = 0;
            }
            if (e.KeyCode == Keys.D)
            { 
                if (direction == 0)
                    direction = 2;
                if (direction == 2)
                    direction = 0;
            }
            if (e.KeyCode == Keys.W)
            {
                if (direction == 1 || direction == 2)
                    direction = 3;
            }
            if (e.KeyCode==Keys.S)
            {
                if (direction == 1 || direction == 2)
                    direction = 0;
            }

            switch (direction)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
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
                        _gameMatrix[i, j].getPicture().Location = new Point(i * SIZE_X + 200, j * SIZE_Y + 75);
                        _gameMatrix[i, j].getPicture().Size = new Size(SIZE_X, SIZE_Y);
                    }
                }
            }
            //_gameMatrix[0, 6] = _p1Session[0];
        }
    }

    public enum Direction
    {
        Up, Down, Left, Right
    }
}