using System.Windows.Forms;

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
        string name;
        if (p1Name.Text == null)
            name = "Snake 1";
        if (p1Controller.SelectedItem == null)
            MessageBox.Show("Please choose a controller");
        else
        {
            
            //playerList.Add(name, p1Controller.SelectedItem.ToString(), );

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
        p2Controller.SelectedIndex = 0;

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