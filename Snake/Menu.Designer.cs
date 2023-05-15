namespace Snake;

partial class Menu
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pictureBox1 = new PictureBox();
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        button4 = new Button();
        p1Controller = new ComboBox();
        label1 = new Label();
        label2 = new Label();
        p2Controller = new ComboBox();
        p1Name = new TextBox();
        p2Name = new TextBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(249, 34);
        pictureBox1.Margin = new Padding(5);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(666, 273);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // button1
        // 
        button1.Location = new Point(457, 353);
        button1.Margin = new Padding(2);
        button1.Name = "button1";
        button1.Size = new Size(245, 75);
        button1.TabIndex = 1;
        button1.Text = "New Game";
        button1.UseVisualStyleBackColor = true;
        button1.Click += newGame_Click;
        // 
        // button2
        // 
        button2.Enabled = false;
        button2.Location = new Point(457, 433);
        button2.Margin = new Padding(2);
        button2.Name = "button2";
        button2.Size = new Size(245, 75);
        button2.TabIndex = 2;
        button2.Text = "Continue";
        button2.UseVisualStyleBackColor = true;
        button2.Click += continueGame_Click;
        // 
        // button3
        // 
        button3.Location = new Point(457, 512);
        button3.Margin = new Padding(2);
        button3.Name = "button3";
        button3.Size = new Size(245, 75);
        button3.TabIndex = 3;
        button3.Text = "Scoreboard";
        button3.UseVisualStyleBackColor = true;
        button3.Click += openScoreBoard_Click;
        // 
        // button4
        // 
        button4.Location = new Point(457, 592);
        button4.Margin = new Padding(2);
        button4.Name = "button4";
        button4.Size = new Size(245, 75);
        button4.TabIndex = 4;
        button4.Text = "Quit";
        button4.UseVisualStyleBackColor = true;
        button4.Click += quitGame_Click;
        // 
        // p1Controller
        // 
        p1Controller.FormattingEnabled = true;
        p1Controller.Location = new Point(103, 433);
        p1Controller.Name = "p1Controller";
        p1Controller.Size = new Size(220, 33);
        p1Controller.TabIndex = 5;
        p1Controller.Text = "Choose your controller:";
        p1Controller.SelectionChangeCommitted += p1Controller_SelectionChangeCommitted;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(103, 389);
        label1.Name = "label1";
        label1.Size = new Size(78, 25);
        label1.TabIndex = 6;
        label1.Text = "Player 1:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(855, 389);
        label2.Name = "label2";
        label2.Size = new Size(78, 25);
        label2.TabIndex = 8;
        label2.Text = "Player 2:";
        // 
        // p2Controller
        // 
        p2Controller.FormattingEnabled = true;
        p2Controller.Location = new Point(855, 433);
        p2Controller.Name = "p2Controller";
        p2Controller.Size = new Size(220, 33);
        p2Controller.TabIndex = 7;
        p2Controller.Text = "Choose your controller:";
        p2Controller.SelectionChangeCommitted += p2Controller_SelectionChangeCommitted;
        // 
        // p1Name
        // 
        p1Name.Location = new Point(187, 386);
        p1Name.Name = "p1Name";
        p1Name.PlaceholderText = "Enter Name";
        p1Name.Size = new Size(136, 31);
        p1Name.TabIndex = 9;
        // 
        // p2Name
        // 
        p2Name.Location = new Point(939, 386);
        p2Name.Name = "p2Name";
        p2Name.PlaceholderText = "Enter Name";
        p2Name.Size = new Size(136, 31);
        p2Name.TabIndex = 10;
        // 
        // Menu
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1178, 720);
        Controls.Add(p2Name);
        Controls.Add(p1Name);
        Controls.Add(label2);
        Controls.Add(p2Controller);
        Controls.Add(label1);
        Controls.Add(p1Controller);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(pictureBox1);
        Margin = new Padding(5);
        Name = "Menu";
        Text = "Form1";
  
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private ComboBox p1Controller;
    private Label label1;
    private Label label2;
    private ComboBox p2Controller;
    private TextBox p1Name;
    private TextBox p2Name;
}
