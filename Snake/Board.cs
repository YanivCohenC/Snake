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
        private Menu mainMenu;
        private List<Player> _playerList;
        private Slot[,] _gameMatrix;

        public Board(Menu other)
        {
            InitializeComponent();
            mainMenu = other;
            _playerList = new List<Player>();
            _gameMatrix = new Slot[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    _gameMatrix[i, j] = new Slot();
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
            
            
            readMatrix();
            
        }

        private void Board_FormClosed(object sender, FormClosedEventArgs e)
        {
            // save data after game
            // warning message exit without saving? or with

            mainMenu.Show();
        }

        private void allocateMatrix()
        {
            
        }

        private void readMatrix()
        {
            // For confirm visibility of all images set 
            this.AutoScroll = true;
            int y = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {


                    this.Controls.Add(_gameMatrix[i,j].getPicture());
                    // Following three lines set the images(picture boxes) locations
                    if (i % 100 == 0)
                       y += 100; // 3 images per rows, first image will be at (20,150)
                    _gameMatrix[i,j].getPicture().Image = Snake.Properties.Resources.Empty;

                     _gameMatrix[i, j].getPicture().Location = new Point(i * 100, y);

                    _gameMatrix[i, j].getPicture().Size = new Size(100, 100);
                }
                
            }
        }
    }
}
