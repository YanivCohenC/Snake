using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Snake;

public partial class Menu : Form
{
    private List<string> _controlList;

    public Menu()
    {
        InitializeComponent();
        // Controllers
        _controlList = new List<string>();
        _controlList.Add("Keyboard (WASD)");
        _controlList.Add("Keyboard (Arrows)");
        p1Controller.SelectedItem = p2Controller.SelectedItem = null;
        p1Controller.Text = p2Controller.Text = "Choose your controller:";
        p1Controller.Items.AddRange(_controlList.ToArray<String>());
        p2Controller.Items.AddRange(_controlList.ToArray<String>());
    }

    private void newGame_Click(object sender, EventArgs e)
    {
        if (p1Controller.SelectedItem == null)
            MessageBox.Show("Please choose a controller");
        else
        {
            //new Form and ful screen
            this.Hide();
            Board board = new Board(this);
            board.ShowDialog();
        }
    }

    private void continueGame_Click(object sender, EventArgs e)
    {

    }

    private void openScoreBoard_Click(object sender, EventArgs e)
    {

    }

    private void quitGame_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void p1Controller_SelectionChangeCommitted(object sender, EventArgs e)
    {
        object selectedItem = p1Controller.SelectedItem;
        p2Controller.Items.Clear();
        p2Controller.Items.AddRange(_controlList.ToArray<String>());
        p2Controller.Items.Remove(selectedItem);
        p2Controller.SelectedItem = "Disabled";

        if (p2Controller.FindString("Disabled") == -1)
            p2Controller.Items.Add("Disabled");
    }

    private void p2Controller_SelectionChangeCommitted(object sender, EventArgs e)
    {
        object selectedItem = p2Controller.SelectedItem;
        p1Controller.Items.Clear();
        p1Controller.Items.AddRange(_controlList.ToArray<String>());
        p1Controller.Items.Remove(selectedItem);
        p1Controller.SelectedIndex = 0;
    }

    public string getP1Name()
    {
        return p1Name.Text;
    }

    public string getP2Name()
    {
        return p2Name.Text;
    }

    public string getP1Controller()
    {
        return p1Controller.Text;
    }

    public string getP2Controller()
    {
        return p2Controller.Text;
    }

    private void p1Type0_Click(object sender, EventArgs e)
    {
        p1Type0.Enabled = false;
        p1Type0.BackColor = Color.Green;
        p1Type0.BackgroundImage = Snake.Properties.Resources.pixel_snake;
        if (p1Type1.Enabled == false)
        {
            p1Type1.Enabled = true;
            p1Type1.BackColor = Color.Red;
            p1Type1.BackgroundImage = null;
        }
        if (p1Type2.Enabled == false)
        {
            p1Type2.Enabled = true;
            p1Type2.BackColor = Color.Blue;
            p1Type2.BackgroundImage = null;
        }
    }

    private void p1Type1_Click(object sender, EventArgs e)
    {
        p1Type1.Enabled = false;
        p1Type1.BackColor = Color.Brown;
        p1Type1.BackgroundImage = Snake.Properties.Resources.pixel_snake;
        if (p1Type0.Enabled == false)
        {
            p1Type0.Enabled = true;
            p1Type0.BackColor = Color.LimeGreen;
            p1Type0.BackgroundImage = null;
        }
        if (p1Type2.Enabled == false)
        {
            p1Type2.Enabled = true;
            p1Type2.BackColor = Color.Blue;
            p1Type2.BackgroundImage = null;
        }
    }

    private void p1Type2_Click(object sender, EventArgs e)
    {
        p1Type2.Enabled = false;
        p1Type2.BackColor = Color.DarkBlue;
        p1Type2.BackgroundImage = Snake.Properties.Resources.pixel_snake;
        if (p1Type0.Enabled == false)
        {
            p1Type0.Enabled = true;
            p1Type0.BackColor = Color.LimeGreen;
            p1Type0.BackgroundImage = null;
        }
        if (p1Type1.Enabled == false)
        {
            p1Type1.Enabled = true;
            p1Type1.BackColor = Color.Red;
            p1Type1.BackgroundImage = null;
        }
    }

    private void p2Type0_Click(object sender, EventArgs e)
    {
        p2Type0.Enabled = false;
        p2Type0.BackColor = Color.Green;
        p2Type0.BackgroundImage = Snake.Properties.Resources.pixel_snake;
        if (p2Type1.Enabled == false)
        {
            p2Type1.Enabled = true;
            p2Type1.BackColor = Color.Red;
            p2Type1.BackgroundImage = null;
        }
        if (p2Type2.Enabled == false)
        {
            p2Type2.Enabled = true;
            p2Type2.BackColor = Color.Blue;
            p2Type2.BackgroundImage = null;
        }
    }

    private void p2Type1_Click(object sender, EventArgs e)
    {
        p2Type1.Enabled = false;
        p2Type1.BackColor = Color.Brown;
        p2Type1.BackgroundImage = Snake.Properties.Resources.pixel_snake;
        if (p2Type0.Enabled == false)
        {
            p2Type0.Enabled = true;
            p2Type0.BackColor = Color.LimeGreen;
            p2Type0.BackgroundImage = null;
        }
        if (p2Type2.Enabled == false)
        {
            p2Type2.Enabled = true;
            p2Type2.BackColor = Color.Blue;
            p2Type2.BackgroundImage = null;
        }
    }

    private void p2Type2_Click(object sender, EventArgs e)
    {
        p2Type2.Enabled = false;
        p2Type2.BackColor = Color.DarkBlue;
        p2Type2.BackgroundImage = Snake.Properties.Resources.pixel_snake;
        if (p2Type0.Enabled == false)
        {
            p2Type0.Enabled = true;
            p2Type0.BackColor = Color.LimeGreen;
            p2Type0.BackgroundImage = null;
        }
        if (p2Type1.Enabled == false)
        {
            p2Type1.Enabled = true;
            p2Type1.BackColor = Color.Red;
            p2Type1.BackgroundImage = null;
        }
    }

    public int getP1Type()
    {
        if (!p1Type0.Enabled)
            return 0;
        if (!p1Type1.Enabled)
            return 1;
        if (!p1Type2.Enabled)
            return 2;
        return 0;
    }

    public int getP2Type()
    {
        if (!p2Type0.Enabled)
            return 0;
        if (!p2Type1.Enabled)
            return 1;
        if (!p2Type2.Enabled)
            return 2;
        return 1;
    }
}