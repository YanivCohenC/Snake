using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Snake;

public partial class Menu : Form
{
    private const int CB_SETCUEBANNER = 0x1703;
    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

    private List<string> _controlList;
    private static Dictionary<string, int> _scoreboard;
    private bool _isContinue;
    private List<string> p1ControlsList;
    private List<string> p2ControlsList;

    public Menu()
    {
        InitializeComponent();
        // Controllers
        p1ControlsList = new List<string>() { "Keyboard (WASD)", "Keyboard (Arrows)" };
        p2ControlsList = new List<string>() { "Keyboard (WASD)", "Keyboard (Arrows)", "Disabled" };
        p1Controller.Text = p2Controller.Text = "Choose your controller:";
        p1Controller.Items.AddRange(p1ControlsList.ToArray<string>());
        p2Controller.Items.AddRange(p2ControlsList.ToArray<string>());
        SendMessage(this.p1Controller.Handle, CB_SETCUEBANNER, 0, "Choose your controller:");
        SendMessage(this.p2Controller.Handle, CB_SETCUEBANNER, 0, "Choose your controller:");
        if (File.Exists("scoreboard.dat"))
        {
            Stream stream = File.Open("scoreboard.dat", FileMode.Open);
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            _scoreboard = (Dictionary<string, int>)binaryFormatter.Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            stream.Close();
            File.Delete("scoreboard.dat");
        }    
        else
            _scoreboard = new Dictionary<string, int>();
        _isContinue = false;
        if (File.Exists("savegame.dat"))
            continueGame.Enabled = true;
        else
            continueGame.Enabled = false;
    }

    private void serializeScoreboard()
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream("scoreboard.dat", FileMode.Create, FileAccess.Write, FileShare.None))
        {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            formatter.Serialize(stream, _scoreboard);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
        }
    }

    private void newGame_Click(object sender, EventArgs e)
    {
        if (p1Controller.SelectedItem == null)
            MessageBox.Show("Please choose a controller");
        else
        {
            _isContinue = false;
            continueGame.Enabled = false;
            this.Hide();
            Board board = new Board(this);
            board.ShowDialog();
        }
    }

    private void continueGame_Click(object sender, EventArgs e)
    {
        _isContinue = true;
        this.Hide();
        Board board = new Board(this);
        board.ShowDialog();
    }

    public bool isContinue()
    {
        return _isContinue;
    }

    public void hideContinue()
    {
        continueGame.Enabled = false;
    }

    public void showContinue()
    {
        continueGame.Enabled = true;
    }

    private void openScoreBoard_Click(object sender, EventArgs e)
    {
        Hide();
        Scoreboard score = new Scoreboard();
        score.ShowDialog();
        Show();
    }

    private void quitGame_Click(object sender, EventArgs e)
    {
        serializeScoreboard();
        Close();
    }

    private void p1Controller_SelectionChangeCommitted(object sender, EventArgs e)
    {
        p2ControlsList.Remove(p1Controller.SelectedItem.ToString());
        p2Controller.Items.Clear();
        p2Controller.Items.AddRange(p2ControlsList.ToArray<string>());
        for (int i = 0; i < p1ControlsList.Count; i++)
        {
            if (p2ControlsList.Contains(p1ControlsList[i]) == false && p1Controller.SelectedItem.ToString() != p1ControlsList[i])
            {
                p2ControlsList.Add(p1ControlsList[i]);
                p2Controller.Items.Clear();
                p2Controller.Items.AddRange(p2ControlsList.ToArray<string>());
            }
        }
    }

    private void p2Controller_SelectionChangeCommitted(object sender, EventArgs e)
    {
        for (int i = 0; i < p2ControlsList.Count; i++)
        {
            if (p1ControlsList.Contains(p2ControlsList[i]) == false && p2ControlsList[i] != "Disabled")
            {
                p1ControlsList.Add(p2ControlsList[i]);
                p1Controller.Items.Clear();
                p1Controller.Items.AddRange(p1ControlsList.ToArray<string>());
            }
        }
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

    public static Dictionary<string, int> getScoreboard()
    {
        return _scoreboard;
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