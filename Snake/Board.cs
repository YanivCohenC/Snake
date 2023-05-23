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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices.JavaScript;

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
        private Timer generateFoodTimer;

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
            _playerList[0].getCoordinates().Add(new snakeBody(true, p1.getPlayerType(), Direction.Down, 6, 1, true));
            _playerList[0].getCoordinates().Add(new snakeBody(false, p1.getPlayerType(), Direction.Down, 6, 0, true));

            p1NameLabel.Visible = p1ScoreLabel1.Visible = p1ScoreLabel2.Visible = true;
            if (p2Controller != "" && p2Controller != "Disabled")
            {
                if (p2Name == "")
                {
                    p2NameLabel.Text = p2Name = "Snake 2";
                }


                Player p2 = new Player(p1Name, p2Controller, mainMenu.getP2Type());
                _playerList.Add(p2);
                _playerList[1].getCoordinates().Add(new snakeBody(true, p2.getPlayerType(), (int)Direction.Up, 13, 18, true));
                _playerList[1].getCoordinates().Add(new snakeBody(false, p2.getPlayerType(), (int)Direction.Up, 13, 19, true));
                p2NameLabel.Visible = p2ScoreLabel1.Visible = p2ScoreLabel2.Visible = true;
            }
            initializeMatrix();

            updateSlot(6, 0, false, _playerList[0].getPlayerType(), Direction.Down, true);
            updateSlot(6, 1, true, _playerList[0].getPlayerType(), Direction.Down, true);


            if (_playerList.Count > 1)
            {
                updateSlot(13, 19, false, _playerList[1].getPlayerType(), Direction.Up, true);
                updateSlot(13, 18, true, _playerList[1].getPlayerType(), Direction.Up, true);
            }

          

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1 second
            countdownTimer.Tick += countDown_Tick;
            countdownTimer.Start();

            boardTimer = new Timer();
            boardTimer.Interval = 200;
            boardTimer.Tick += boardTimer_Tick;

            generateFoodTimer = new Timer();
            generateFoodTimer.Interval = 7000; // 7 seconds
            generateFoodTimer.Tick += generateFood;

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
                for (int i = 0; i < _playerList.Count; i++)
                    _playerList[i].setStatus(true);
                boardTimer.Start();
                generateFoodTimer.Start();
                generateFood(null, EventArgs.Empty);
                // Start the game here
            }
        }

        private void boardTimer_Tick(object sender, EventArgs e)
        {
            int k;
            foreach (Player pl in _playerList)
            {
                if (pl.isAlive())
                {
                    List<snakeBody> coordinates = pl.getCoordinates();
                    int xHead = coordinates[0].getX();
                    int yHead = coordinates[0].getY();
                    int xBody = coordinates[1].getX();
                    int yBody = coordinates[1].getY();
                    int xTail = coordinates[coordinates.Count - 1].getX();
                    int yTail = coordinates[coordinates.Count - 1].getY();
                    Direction d = coordinates[0].getDirection();
                    if (pl.isAlive() == true)
                    {
                        updateSlot(xTail, yTail, false, -1, d, true);

                        if (d == Direction.Up)
                        {
                            if (pl.getScore() == 0)
                            {
                                xTail = xHead;
                                yTail = yHead;
                                yHead--;
                            }
                            //else
                            //{
                            //    xTail = xBody;
                            //    yTail = yBody;
                            //    yHead--;
                            //    for (k = _playerList.Count - 1; k > 0; k--)
                            //    {
                            //        xBody = coordinates[k - 1].getX();
                            //        yBody = coordinates[k - 1].getY();
                            //    }
                            //}
                        }
                        if (d == Direction.Down)
                        {
                            if (pl.getScore() == 0)
                            {
                                xTail = xHead;
                                yTail = yHead;
                                yHead++;
                            }
                            // else


                        }
                        if (d == Direction.Left)
                        {
                            if (pl.getScore() == 0)
                            {
                                xTail = xHead;
                                yTail = yHead;
                                xHead--;
                            }
                        }
                        if (d == Direction.Right)
                        {
                            if (pl.getScore() == 0)
                            {
                                xTail = xHead;
                                yTail = yHead;
                                xHead++;
                            }
                        }
                    }
                    
                    if (pl.isAlive() == false || xHead == ROWS || xHead < 0 || yHead == COLS || yHead < 0|| pl.getScore() < 0)
                    {
                        pl.setStatus(false);
                        int j = 0;
                        for (j = coordinates.Count - 1; j >= 0; j--)
                        {
                            updateSlot(coordinates[j].getX(), coordinates[j].getY(), false, -1, d, false);
                        }
                        updateSlot(coordinates[0].getX(), coordinates[0].getY(), true, pl.getPlayerType(), d, false);
                        coordinates.Clear();
                    }
                    else
                    {
                        if (_gameMatrix[xHead, yHead] is Food food) // if food
                        {
                            pl.updateScore(food.effect());
                            if (pl == _playerList[0])
                                p1ScoreLabel2.Text = pl.getScore().ToString();
                            else
                                p2ScoreLabel2.Text = pl.getScore().ToString();
                        }
                        //    //_gameMatrix[xHead, yHead] = new Slot();

                        //}
                        coordinates[0].setX(xHead);
                        coordinates[0].setY(yHead);
                        //_playerList[i].getCoordinates()[1].setX(xBody);
                        //_playerList[i].getCoordinates()[1].setY(yBody);
                        coordinates[coordinates.Count - 1].setX(xTail);
                        coordinates[coordinates.Count - 1].setY(yTail);
                        updateSlot(xHead, yHead, true, pl.getPlayerType(), d, true);
                        //updateSlot(xBody, yBody, false, _playerList[i].getPlayerType(), d, true);
                        updateSlot(xTail, yTail, false, pl.getPlayerType(), d, true);
                    }
                }
            }
        
            this.Invalidate();
            // changes of snake and board
        }

        public void updateSlot(int x, int y, bool isHead, int type, Direction d, bool status)
        {
            Point p = _gameMatrix[x, y].getPicture().Location;
            this.Controls.Remove(_gameMatrix[x, y].getPicture());
            if (type == -1)
            {
                _gameMatrix[x, y] = new Slot();
            }
            else
            {
                _gameMatrix[x, y] = new snakeBody(isHead, type, d, x, y, status);
                _gameMatrix[x, y].getPicture().BackgroundImage = rotatePicture(d, isHead, type, status);

            }
            _gameMatrix[x, y].getPicture().Location = p;
            _gameMatrix[x, y].getPicture().Size = new Size(SIZE_X, SIZE_Y);
            this.Controls.Add(_gameMatrix[x, y].getPicture());
           
        }

        private void generateFood(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Timer timer = null;
            int num = rnd.Next(3);
          
            while (1 != 2)
            {
                int x = rnd.Next(ROWS);
                int y = rnd.Next(COLS);
 
                if (_gameMatrix[x,y] is Slot)
                {
                    Point p = _gameMatrix[x, y].getPicture().Location;
                    this.Controls.Remove(_gameMatrix[x, y].getPicture());

                    if (num == (int)foodType.Apple)
                    {
                        Apple s = new Apple();
                        _gameMatrix[x, y] = s;
                        timer = s.getTimer();
                    }
                    if (num == (int)foodType.Cherry)
                    {
                        Cherry s  = new Cherry();
                        _gameMatrix[x, y] = s;
                        timer = s.getTimer();
                    }

                    if (num == (int)foodType.Poop)
                    {
                        Poop s = new Poop();
                        _gameMatrix[x, y] = s;
                        timer = s.getTimer();
                    }

                    timer.Start();
                    _gameMatrix[x, y].getPicture().Location= p;
                    _gameMatrix[x, y].getPicture().Size = new Size(SIZE_X, SIZE_Y);
                    this.Controls.Add(_gameMatrix[x, y].getPicture());
                    break;
                }
            }
        }

        public Image rotatePicture(Direction d, bool isHead, int type, bool status)
        {
            Image img = null;
            switch (type)
            {
                case 0:
                    if (isHead == true)
                    {
                        if (status == true)
                            img = Snake.Properties.Resources.snake0Head;
                        else
                            img = Snake.Properties.Resources.head0Dead;
                    }
                    else
                    {
                        img = Snake.Properties.Resources.snake0Body;
                    }
                    break;
                case 1:
                    if (isHead == true)
                    {
                        if (status == true)
                            img = Snake.Properties.Resources.snake1Head;
                        else
                            img = Snake.Properties.Resources.head1Dead;
                    }
                    else
                    {
                        img = Snake.Properties.Resources.snake1Body;
                    }
                    break;
                case 2:
                    if (isHead == true)
                    {
                        if (status == true)
                            img = Snake.Properties.Resources.snake2Head;
                        else
                            img = Snake.Properties.Resources.head2Dead;
                    }
                    else
                    {
                        img = Snake.Properties.Resources.snake2Body;
                    }
                    break;
            }
            switch (d)
            {
                case Direction.Up:
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case Direction.Right:
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case Direction.Left:
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }
            return img;
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
        }

        private void Board_KeyDown(object sender, KeyEventArgs e)
        {
            string type = "";
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
                type = "Keyboard (WASD)";
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                type = "Keyboard (Arrows)";
            //TODO add controller
            for (int i = 0; i < _playerList.Count; i++)
            {
                if (_playerList[i].isAlive() == true)
                {
                    Direction d = _playerList[i].getCoordinates()[0].getDirection();
                    if (_playerList[i].getInput() == type)
                    {
                        if (type == "Keyboard (WASD)"  || type == "Keyboard (Arrows)")
                        {
                            switch (e.KeyCode)
                            {
                                case Keys.Up:
                                case Keys.W:
                                    if (d == Direction.Left || d == Direction.Right)
                                        d = Direction.Up;
                                    break;
                                case Keys.Left:
                                case Keys.A:
                                    if (d == Direction.Up || d == Direction.Down)
                                        d = Direction.Left;
                                    break;
                                case Keys.Down:
                                case Keys.S:
                                    if (d == Direction.Left || d == Direction.Right)
                                        d = Direction.Down;
                                    break;
                                case Keys.Right:
                                case Keys.D:
                                    if (d == Direction.Up || d == Direction.Down)
                                        d = Direction.Right;
                                    break;
                            }
                        }
                    }
                    _playerList[i].getCoordinates()[0].setDirection(d);
                }
            }
        }
    }

    public enum Direction
    {
        Up, Down, Left, Right
    }

    public enum foodType
    {
        Apple, Cherry, Poop
    }
}