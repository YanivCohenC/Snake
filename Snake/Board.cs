using System.Data;
using Timer = System.Windows.Forms.Timer;
using Image = System.Drawing.Image;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Snake
{
    public partial class Board : Form
    {
        private const int ROWS = 20;
        private const int COLS = 20;
        private const int SIZE_X = 32;
        private const int SIZE_Y = 32;

        private Menu _mainMenu;
        static private List<Player> _playerList; // For scoreboard
        static private Slot[,] _gameMatrix; // For all of the elements on board

        private Timer countdownTimer;
        private Timer boardTimer;
        private Timer generateFoodTimer;

        public Board(Menu other)
        {
            InitializeComponent();

            _mainMenu = other;
            _playerList = new List<Player>();
            _gameMatrix = new Slot[ROWS, COLS];
        }

        private void Board_Load(object sender, EventArgs e)
        {
            string p1Name = p1NameLabel.Text = _mainMenu.getP1Name();
            string p2Name = p2NameLabel.Text = _mainMenu.getP2Name();
            string p2Controller = _mainMenu.getP2Controller();

            if (p1Name == "")
            {
                p1NameLabel.Text = p1Name = "Snake 1";
            }

            Player p1 = new Player(p1Name, _mainMenu.getP1Controller(), _mainMenu.getP1Type());
            _playerList.Add(p1);
            _playerList[0].getCoordinates().Add(new snakeBody(true, p1.getPlayerType(), Direction.Down, 6, 1, true));
            _playerList[0].getCoordinates().Add(new snakeBody(false, p1.getPlayerType(), Direction.Down, 6, 0, true));
            _playerList[0].setPlayerName(p1Name);

            p1NameLabel.Visible = p1ScoreLabel1.Visible = p1ScoreLabel2.Visible = true;
            if (p2Controller != "" && p2Controller != "Disabled")
            {
                if (p2Name == "")
                {
                    p2NameLabel.Text = p2Name = "Snake 2";
                }


                Player p2 = new Player(p1Name, p2Controller, _mainMenu.getP2Type());
                _playerList.Add(p2);
                _playerList[1].getCoordinates().Add(new snakeBody(true, p2.getPlayerType(), (int)Direction.Up, 13, 18, true));
                _playerList[1].getCoordinates().Add(new snakeBody(false, p2.getPlayerType(), (int)Direction.Up, 13, 19, true));
                _playerList[1].setPlayerName(p2Name);
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

            for (int i = 0; i < _playerList.Count; i++)
                _playerList[i].setStatus(true);

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

        static int count = 5;
        private void countDown_Tick(object sender, EventArgs e)
        {
            countdownLabel.Show();
            count--;
            countdownLabel.Text = "Game will start in: " + count;

            if (count == 0)
            {
                countdownTimer.Stop();
                countdownLabel.Hide();
                boardTimer.Start();
                generateFoodTimer.Start();
                generateFood(null, EventArgs.Empty);
                // Start the game here
            }
        }

        private void boardTimer_Tick(object sender, EventArgs e)
        {
            int temp = 0;
            bool finalStatus = true;
            foreach (Player pl in _playerList)
            {
                if (pl.isAlive())
                {
                    List<snakeBody> newCoordinates = pl.getCoordinates();
                    var oldCoordinates = newCoordinates.Select(sb => new Point(sb.getX(), sb.getY())).ToList(); // copy newCoordinates by value as Point()
                    snakeBody head = newCoordinates[0];
                    Direction d = head.getDirection();

                    for (int i = 1; i < newCoordinates.Count; i++)
                    {
                        newCoordinates[i].setX(oldCoordinates[i - 1].X);
                        newCoordinates[i].setY(oldCoordinates[i - 1].Y);
                    }

                    switch (d)
                    {
                        case Direction.Up:
                            head.setY(head.getY() - 1);
                            break;
                        case Direction.Down:
                            head.setY(head.getY() + 1);
                            break;
                        case Direction.Left:
                            head.setX(head.getX() - 1);
                            break;
                        case Direction.Right:
                            head.setX(head.getX() + 1);
                            break;
                    }

                    if (!pl.isAlive() || head.getX() == ROWS || head.getX() < 0 || head.getY() == COLS || head.getY() < 0 || pl.getScore() < 0 || _gameMatrix[head.getX(), head.getY()] is snakeBody body) // if dead
                    {
                        pl.setStatus(false); // kill player
                        for (int i = 1; i < oldCoordinates.Count; i++)
                        {
                            updateSlot(oldCoordinates[i].X, oldCoordinates[i].Y, false, -1, d, false);
                        }
                        updateSlot(oldCoordinates[0].X, oldCoordinates[0].Y, true, pl.getPlayerType(), d, false); // dead head
                        newCoordinates.Clear();
                    }
                    else
                    {
                        if (_gameMatrix[head.getX(), head.getY()] is Food food) // if food
                        {
                            if (food.isExpired() == false)
                            {
                                food.getTimer().Stop();
                                pl.updateScore(food.effect());
                                generateFood(null, EventArgs.Empty);
                                if (food is not Poop) // player ate apple or cherry
                                    newCoordinates.Add(new snakeBody(false, pl.getPlayerType(), d, oldCoordinates[oldCoordinates.Count - 1].X, oldCoordinates[oldCoordinates.Count - 1].Y, true));
                                else
                                { // player ate poop
                                    updateSlot(oldCoordinates[oldCoordinates.Count - 1].X, oldCoordinates[oldCoordinates.Count - 1].Y, false, -1, d, true);
                                    updateSlot(oldCoordinates[oldCoordinates.Count - 2].X, oldCoordinates[oldCoordinates.Count - 2].Y, false, -1, d, true);
                                    if (newCoordinates.Count == 1) // if only head was left
                                    {
                                        pl.setStatus(false); // kill player
                                        updateSlot(head.getX(), head.getY(), true, pl.getPlayerType(), d, false); // dead head
                                    }
                                    else
                                        newCoordinates.RemoveAt(newCoordinates.Count - 1);
                                }
                                if (pl == _playerList[0])
                                {
                                    if (pl.getScore() >= 0)
                                        p1ScoreLabel2.Text = pl.getScore().ToString();
                                    else
                                        p1ScoreLabel2.Text = "0";
                                }
                                else if (pl.getScore() >= 0)
                                {
                                    p2ScoreLabel2.Text = pl.getScore().ToString();
                                }
                                else
                                    p2ScoreLabel2.Text = "0";
                            }
                            else
                            {
                                updateSlot(oldCoordinates[oldCoordinates.Count - 1].X, oldCoordinates[oldCoordinates.Count - 1].Y, false, -1, d, true);
                            }
                        }
                        else // if regular movement, delete tail
                            updateSlot(oldCoordinates[oldCoordinates.Count - 1].X, oldCoordinates[oldCoordinates.Count - 1].Y, false, -1, d, true);
                        updateSlot(head.getX(), head.getY(), true, pl.getPlayerType(), d, true); // Move head
                        if (newCoordinates.Count == 1)
                        {
                            pl.setStatus(false); // kill player
                            updateSlot(head.getX(), head.getY(), true, pl.getPlayerType(), d, false); // dead head
                        }
                        else
                            updateSlot(newCoordinates[1].getX(), newCoordinates[1].getY(), false, pl.getPlayerType(), d, true); // Move one before head
                    }
                }
            }
            if (_playerList.Count == 2)
            {
                if (_playerList[0].getStatus() == false && _playerList[1].getStatus() == false) // if both players died
                    showDeathScreen();
            }
            else if (_playerList[0].getStatus() == false) // if the only player left died
                showDeathScreen();
            foreach (Player p in _playerList)
            {
                p.setLocked(false);
            }
        }

        private void updateScoreboard(Player pl)
        {
            Dictionary<string, int> p = Menu.getScoreboard();
            if (p.ContainsKey(pl.getPlayerName()) && p[pl.getPlayerName()] < pl.getScore())
            {
                p[pl.getPlayerName()] = pl.getScore();
            }
            else if (p.ContainsKey(pl.getPlayerName()) == false)
                p.Add(pl.getPlayerName(), pl.getScore());
        }

        private void updateSlot(int x, int y, bool isHead, int type, Direction d, bool status)
        {
            Point p = _gameMatrix[x, y].getPicture().Location;
            this.Controls.Remove(_gameMatrix[x, y].getPicture());
            if (type == -1)
                _gameMatrix[x, y] = new Slot();
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
            bool foodExists = false;
            int num = rnd.Next(3);
            if (num == (int)foodType.Poop)
            {
                foreach (Slot s in _gameMatrix)
                    if ((s is Apple && ((Apple)s).isExpired() == false)  || (s is Cherry && ((Cherry)s).isExpired() == false)) // if there is food
                        foodExists = true;
                if (foodExists == false)
                    num = rnd.Next(2);
            }
            while (1 != 2)
            {
                int x = rnd.Next(ROWS);
                int y = rnd.Next(COLS);

                if (_gameMatrix[x, y] is Slot && _gameMatrix[x, y] is not snakeBody)
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
                        Cherry s = new Cherry();
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
                    _gameMatrix[x, y].getPicture().Location = p;
                    _gameMatrix[x, y].getPicture().Size = new Size(SIZE_X, SIZE_Y);
                    this.Controls.Add(_gameMatrix[x, y].getPicture());
                    break;
                }
            }
        }

        private Image rotatePicture(Direction d, bool isHead, int type, bool status)
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

        private void showDeathScreen()
        {
            countdownTimer.Stop();
            boardTimer.Stop();
            generateFoodTimer.Stop();
            foreach (Player pl in _playerList)
                updateScoreboard(pl);
            PauseMenu pause = new PauseMenu();
            pause.setDeath(true);
            pause.ShowDialog();
            if (pause.getChoice() == choice.saveExit)
            {
                Close();
                _mainMenu.Show();
            }
        }

        private void saveAndExit()
        {
            SerializeNow();
        }

        public static void SerializeNow()
        {
            using (FileStream fileStream = new FileStream("savegame.json", FileMode.Create))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(_playerList.GetType());
                //serializer.WriteObject(fileStream, _playerList);
                serializer = new DataContractJsonSerializer(_gameMatrix.GetType());
                serializer.WriteObject(fileStream, _gameMatrix);
            }
        }
        public T DeSerializeNow<T>()
        {
            using (FileStream fileStream = new FileStream("savegame.json", FileMode.Open))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(fileStream);
            }
        }

        private void Board_FormClosed(object sender, FormClosedEventArgs e)
        {
            // save data after game
            // warning message exit without saving? or with
            count = 5;
        }

        private void initializeMatrix()
        {
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
            if (e.KeyCode == Keys.Escape)
            {
                foreach (Slot s in _gameMatrix)
                    if (s is Food f)
                        f.getTimer().Stop();
                countdownTimer.Stop();
                boardTimer.Stop();
                generateFoodTimer.Stop();
                PauseMenu pause = new PauseMenu();
                pause.setDeath(false);
                pause.ShowDialog();
                if (pause.getChoice() == choice.Resume)
                {
                    count = 5;
                    countdownLabel.Text = "Game will start in: 5";
                    countdownLabel.Show();
                    countdownTimer.Start();
                    foreach (Slot s in _gameMatrix)
                        if (s is Food f)
                            f.getTimer().Start();
                }
                else if (pause.getChoice() == choice.saveExit)
                {
                    Board.SerializeNow();
                    Close();
                }
            }
            for (int i = 0; i < _playerList.Count; i++)
            {
                if (_playerList[i].isAlive() == true && _playerList[i].isLocked() == false)
                {
                    Direction d = _playerList[i].getCoordinates()[0].getDirection();
                    if (_playerList[i].getInput() == type)
                    {
                        if (type == "Keyboard (WASD)" || type == "Keyboard (Arrows)")
                        {
                            switch (e.KeyCode)
                            {
                                case Keys.Up:
                                case Keys.W:
                                    if (d == Direction.Left || d == Direction.Right)
                                        d = Direction.Up;
                                    _playerList[i].setLocked(true);
                                    break;
                                case Keys.Left:
                                case Keys.A:
                                    if (d == Direction.Up || d == Direction.Down)
                                        d = Direction.Left;
                                    _playerList[i].setLocked(true);
                                    break;
                                case Keys.Down:
                                case Keys.S:
                                    if (d == Direction.Left || d == Direction.Right)
                                        d = Direction.Down;
                                    _playerList[i].setLocked(true);
                                    break;
                                case Keys.Right:
                                case Keys.D:
                                    if (d == Direction.Up || d == Direction.Down)
                                        d = Direction.Right;
                                    _playerList[i].setLocked(true);
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