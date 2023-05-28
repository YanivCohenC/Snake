using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Scoreboard : Form
    {
        public Scoreboard()
        {
            InitializeComponent();
            if (Menu.getScoreboard().Count != 0)
                highScores.DataSource = new BindingSource(Menu.getScoreboard(), null);
            else
                deleteScore.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteScore_Click(object sender, EventArgs e)
        {
            Menu.getScoreboard().Remove(Menu.getScoreboard().ElementAt(highScores.SelectedIndex).Key);
            if (Menu.getScoreboard().Count != 0)
                highScores.DataSource = new BindingSource(Menu.getScoreboard(), null);
            else
            {
                highScores.DataSource = null;
                deleteScore.Enabled = false;
            }
        }

        private void highScores_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteScore.Enabled = true;
        }
    }
}