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

namespace Snake
{
    public partial class Board : Form
    {
        public const int ROWS = 20;
        public const int COLS = 20;
        public const int SIZE_X = 50;
        public const int SIZE_Y = 50;

        private Menu mainMenu;
        private List<Player> _playerList;
        private Slot[,] _gameMatrix;

        public Board(Menu other)
        {
            InitializeComponent();
            mainMenu = other;
            _playerList = new List<Player>();
            _gameMatrix = new Slot[ROWS, COLS];
        }

        private void Board_Load(object sender, EventArgs e)
        {
            string p1Name = mainMenu.getP1Name();
            string p2Name = mainMenu.getP2Name();
            string p2Controller = mainMenu.getP2Controller();

            if (p1Name == "")
                p1Name = "Snake 1";
            Player p1 = new Player(p1Name, mainMenu.getP1Controller(), mainMenu.getP1Type());
            _playerList.Add(p1);
            if (p2Controller != "Choose your controller:" && p2Controller != "Disabled")
            {
                if (p2Name == "")
                    p2Name = "Snake 2";

                Player p2 = new Player(p1Name, p2Controller, mainMenu.getP2Type());
                _playerList.Add(p2);
            }

            initializeMatrix();
            //readMatrix();

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
                        _gameMatrix[i, j].getPicture().Location = new Point(i * SIZE_X + 300, j * SIZE_Y + 175);
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
