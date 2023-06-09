﻿using System.Data;
using Timer = System.Windows.Forms.Timer;
using Image = System.Drawing.Image;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Snake
{
    public partial class Board : Form
    {
        private const int ROWS = 20;
        private const int COLS = 20;
        private const int SIZE_X = 32;
        private const int SIZE_Y = 32;

        private Menu _mainMenu; // To access mainmenu features
        private List<Player> _playerList; // For every snake on board
        private Slot[,] _gameMatrix; // For all of the elements on board

        private Timer countdownTimer; // Count 5 seconds until game start
        private Timer boardTimer; // Board tick
        private Timer generateFoodTimer; // Food tick

        public Board(Menu other)
        {
            InitializeComponent();
            _mainMenu = other;
            _playerList = new List<Player>();
            _gameMatrix = new Slot[ROWS, COLS];
        }

        private void Board_Load(object sender, EventArgs e)
        {
            if (_mainMenu.isContinue() == false) // If new game
            {
                if (File.Exists("savegame.dat") == true) // Delete saved file
                    File.Delete("savegame.dat");
                string p1Name = p1NameLabel.Text = _mainMenu.getP1Name();
                string p2Name = p2NameLabel.Text = _mainMenu.getP2Name();
                string p2Controller = _mainMenu.getP2Controller();
                if (p1Name == "")
                    p1NameLabel.Text = p1Name = "Snake 1";
                // Creation of player 1
                Player p1 = new Player(p1Name, _mainMenu.getP1Controller(), _mainMenu.getP1Type());
                _playerList.Add(p1);
                _playerList[0].getCoordinates().Add(new snakeBody(true, p1.getPlayerType(), Direction.Down, 6, 1, true));
                _playerList[0].getCoordinates().Add(new snakeBody(false, p1.getPlayerType(), Direction.Down, 6, 0, true));
                _playerList[0].setPlayerName(p1Name);
                p1NameLabel.Visible = p1ScoreLabel1.Visible = p1ScoreLabel2.Visible = true;
                // Creation of player 2
                if (p2Controller != "" && p2Controller != "Disabled")
                {
                    if (p2Name == "")
                        p2NameLabel.Text = p2Name = "Snake 2";
                    Player p2 = new Player(p1Name, p2Controller, _mainMenu.getP2Type());
                    _playerList.Add(p2);
                    _playerList[1].getCoordinates().Add(new snakeBody(true, p2.getPlayerType(), (int)Direction.Up, 13, 18, true));
                    _playerList[1].getCoordinates().Add(new snakeBody(false, p2.getPlayerType(), (int)Direction.Up, 13, 19, true));
                    _playerList[1].setPlayerName(p2Name);
                    p2NameLabel.Visible = p2ScoreLabel1.Visible = p2ScoreLabel2.Visible = true;
                }
                initializeMatrix();
                // Place first snake locations
                updateSlot(6, 0, false, _playerList[0].getPlayerType(), Direction.Down, true);
                updateSlot(6, 1, true, _playerList[0].getPlayerType(), Direction.Down, true);
                if (_playerList.Count > 1)
                {
                    updateSlot(13, 19, false, _playerList[1].getPlayerType(), Direction.Up, true);
                    updateSlot(13, 18, true, _playerList[1].getPlayerType(), Direction.Up, true);
                }
                for (int i = 0; i < _playerList.Count; i++)
                    _playerList[i].setStatus(true); // Set status of players to alive
                // Start timers
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
            }
            else // If continue game
            {
                // Deserialize
                Stream stream = File.Open("savegame.dat", FileMode.Open);
                List<exportPlayer> temp = new List<exportPlayer>();
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                temp = (List<exportPlayer>)binaryFormatter.Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                stream.Close();
                File.Delete("savegame.dat");
                _mainMenu.hideContinue();
                foreach (var exportPlayer in temp)
                    _playerList.Add(new Player(exportPlayer));
                initializeMatrix();
                // Place first snake locations
                foreach (Player p in _playerList)
                    foreach (snakeBody s in p.getCoordinates())
                        updateSlot(s.getX(), s.getY(), s.getHead(), _playerList[_playerList.IndexOf(p)].getPlayerType(), s.getDirection(), s.getHead());
                p1NameLabel.Text = _playerList[0].getPlayerName();
                p1NameLabel.Visible = p1ScoreLabel1.Visible = p1ScoreLabel2.Visible = true;
                p1ScoreLabel2.Text = _playerList[0].getScore().ToString();
                if (_playerList.Count > 1)
                {
                    p2NameLabel.Text = _playerList[1].getPlayerName();
                    p2NameLabel.Visible = p2ScoreLabel1.Visible = p2ScoreLabel2.Visible = true;
                    p2ScoreLabel2.Text = _playerList[1].getScore().ToString();
                }
                // Start timers
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
            }
        }

        // For countdown
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
                generateFood(null, EventArgs.Empty); // Generate food on game start
                // Start the game here
            }
        }

        private void boardTimer_Tick(object sender, EventArgs e)
        {
            foreach (Player pl in _playerList)
            {
                if (pl.isAlive())
                {
                    List<snakeBody> newCoordinates = pl.getCoordinates();
                    var oldCoordinates = newCoordinates.Select(sb => new Point(sb.getX(), sb.getY())).ToList(); // copy newCoordinates by value as Point()
                    snakeBody head = newCoordinates[0];
                    Direction d = head.getDirection();
                    // Copy coordinates of previous body to current body
                    for (int i = 1; i < newCoordinates.Count; i++)
                    {
                        newCoordinates[i].setX(oldCoordinates[i - 1].X);
                        newCoordinates[i].setY(oldCoordinates[i - 1].Y);
                    }
                    // Move head by direction
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
                    // If player did an illegal move
                    if (!pl.isAlive() || head.getX() == ROWS || head.getX() < 0 || head.getY() == COLS || head.getY() < 0 || pl.getScore() < 0 || _gameMatrix[head.getX(), head.getY()] is snakeBody body) // if dead
                    {
                        pl.setStatus(false); // kill player
                        for (int i = 1; i < oldCoordinates.Count; i++) // Remove body
                            updateSlot(oldCoordinates[i].X, oldCoordinates[i].Y, false, -1, d, false);
                        updateSlot(oldCoordinates[0].X, oldCoordinates[0].Y, true, pl.getPlayerType(), d, false); // dead head
                        newCoordinates.Clear();
                    }
                    else
                    {
                        if (_gameMatrix[head.getX(), head.getY()] is Food food) // if food
                        {
                            if (food.isExpired() == false) // if food counter has not expired
                            {
                                food.getTimer().Stop();
                                pl.updateScore(food.effect()); // Polymorphysm
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
                                        newCoordinates.RemoveAt(newCoordinates.Count - 1); // Remove from tail
                                }
                                if (pl == _playerList[0]) // set score label
                                {
                                    if (pl.getScore() >= 0)
                                        p1ScoreLabel2.Text = pl.getScore().ToString();
                                    else
                                        p1ScoreLabel2.Text = "0";
                                }
                                else if (pl.getScore() >= 0) 
                                    p2ScoreLabel2.Text = pl.getScore().ToString();
                                else
                                    p2ScoreLabel2.Text = "0";
                            }
                            else // if food has expired
                                updateSlot(oldCoordinates[oldCoordinates.Count - 1].X, oldCoordinates[oldCoordinates.Count - 1].Y, false, -1, d, true);
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
                p.setLocked(false); // unlock player until next tick
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

        // Change matrix
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
            int num = rnd.Next(3); // random 0-2
            if (num == (int)foodType.Poop)
            {
                foreach (Slot s in _gameMatrix)
                    if ((s is Apple && ((Apple)s).isExpired() == false)  || (s is Cherry && ((Cherry)s).isExpired() == false)) // if there is food
                        foodExists = true;
                if (foodExists == false)
                    num = rnd.Next(2); // random 0-1
            }
            while (1 != 2) // Keep generating food until valid spot
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
                    else if (num == (int)foodType.Cherry)
                    {
                        Cherry s = new Cherry();
                        _gameMatrix[x, y] = s;
                        timer = s.getTimer();
                    }
                    else if (num == (int)foodType.Poop)
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
                        img = Snake.Properties.Resources.snake0Body;
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
                        img = Snake.Properties.Resources.snake1Body;
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
                        img = Snake.Properties.Resources.snake2Body;
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

        public void SerializeNow()
        {
            List<exportPlayer> exportPlayers = new List<exportPlayer>();
            for (int i = 0; i < _playerList.Count; i++)
                exportPlayers.Add(new exportPlayer(_playerList[i]));
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("savegame.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(stream, exportPlayers);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }

        private void Board_FormClosed(object sender, FormClosedEventArgs e)
        {
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
            if (e.KeyCode == Keys.Escape) // if pause
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
                else if (pause.getChoice() == choice.exitNoSave)
                {
                    Close();
                    _mainMenu.Show();
                }
                else if (pause.getChoice() == choice.saveExit)
                {
                    SerializeNow();
                    _mainMenu.showContinue();
                    Close();
                    _mainMenu.Show();
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
                                    _playerList[i].setLocked(true); // lock player after he chose direction
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