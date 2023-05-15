using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Snake;

public partial class Menu : Form
{
    private List<Player> playerList;
    private List<string> controlList;

    public Menu()
    {
        InitializeComponent();
        // Players
        playerList = new List<Player>();

        // Controllers
        controlList = new List<string>();
        controlList.Add("Keyboard (WASD)");
        controlList.Add("Keyboard (Arrows)");
        p1Controller.SelectedItem = p2Controller.SelectedItem = null;
        p1Controller.Text = p2Controller.Text = "Choose your controller:";
        p1Controller.Items.AddRange(controlList.ToArray<String>());
        p2Controller.Items.AddRange(controlList.ToArray<String>());
    }

    private void newGame_Click(object sender, EventArgs e)
    {
        playerList = new List<Player>();

        string name = "";
        if (p1Name.Text == null)
            name = "Snake 1";
        else
        {
            name = p1Name.Text;
        }
        if (p1Controller.SelectedItem == null)
            MessageBox.Show("Please choose a controller");
        else
        {
            Player p1 = new Player(name, (string)p1Controller.SelectedItem);
            playerList.Add(p1);

            if (p2Controller.SelectedItem != null && (string)p2Controller.SelectedItem != "Disabled")
            {
                if (p2Name.Text == null)
                    name = "Snake 2";
                else
                {
                    name = p2Name.Text;
                }
                Player p2 = new Player(name, (string)p2Controller.SelectedItem);
                playerList.Add(p2);
            }


            //new form and ful screen
            Form f2 = new Form();
            f2.Size = new Size();
            this.Hide();
            f2.WindowState = FormWindowState.Normal;
            f2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f2.Bounds = Screen.PrimaryScreen.Bounds;
            f2.ShowDialog();
            this.Close();
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
        p2Controller.Items.AddRange(controlList.ToArray<String>());
        p2Controller.Items.Remove(selectedItem);
        p2Controller.SelectedItem = "Disabled";

        if (p2Controller.FindString("Disabled") == -1)
            p2Controller.Items.Add("Disabled");
    }

    private void p2Controller_SelectionChangeCommitted(object sender, EventArgs e)
    {
        object selectedItem = p2Controller.SelectedItem;
        p1Controller.Items.Clear();
        p1Controller.Items.AddRange(controlList.ToArray<String>());
        p1Controller.Items.Remove(selectedItem);
        p1Controller.SelectedIndex = 0;
    }


}