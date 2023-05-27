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
        openScoreboard = new Button();
        button4 = new Button();
        p1Controller = new ComboBox();
        label1 = new Label();
        label2 = new Label();
        p2Controller = new ComboBox();
        p1Name = new TextBox();
        p2Name = new TextBox();
        p1Type0 = new Button();
        p1Type1 = new Button();
        p1Type2 = new Button();
        p2Type2 = new Button();
        p2Type1 = new Button();
        p2Type0 = new Button();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        label6 = new Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = Color.Transparent;
        pictureBox1.BackgroundImage = Properties.Resources.SnakeLogo;
        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBox1.Location = new Point(87, 39);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(845, 245);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // button1
        // 
        button1.Location = new Point(424, 340);
        button1.Margin = new Padding(2, 1, 2, 1);
        button1.Name = "button1";
        button1.Size = new Size(171, 45);
        button1.TabIndex = 1;
        button1.Text = "New Game";
        button1.UseVisualStyleBackColor = true;
        button1.Click += newGame_Click;
        // 
        // button2
        // 
        button2.Enabled = false;
        button2.Location = new Point(424, 440);
        button2.Margin = new Padding(2, 1, 2, 1);
        button2.Name = "button2";
        button2.Size = new Size(171, 45);
        button2.TabIndex = 2;
        button2.Text = "Continue";
        button2.UseVisualStyleBackColor = true;
        // 
        // openScoreboard
        // 
        openScoreboard.Location = new Point(424, 540);
        openScoreboard.Margin = new Padding(2, 1, 2, 1);
        openScoreboard.Name = "openScoreboard";
        openScoreboard.Size = new Size(171, 45);
        openScoreboard.TabIndex = 3;
        openScoreboard.Text = "Scoreboard";
        openScoreboard.UseVisualStyleBackColor = true;
        openScoreboard.Click += openScoreBoard_Click;
        // 
        // button4
        // 
        button4.Location = new Point(424, 640);
        button4.Margin = new Padding(2, 1, 2, 1);
        button4.Name = "button4";
        button4.Size = new Size(171, 45);
        button4.TabIndex = 4;
        button4.Text = "Quit";
        button4.UseVisualStyleBackColor = true;
        button4.Click += quitGame_Click;
        // 
        // p1Controller
        // 
        p1Controller.DropDownStyle = ComboBoxStyle.DropDownList;
        p1Controller.FormattingEnabled = true;
        p1Controller.Location = new Point(156, 456);
        p1Controller.Margin = new Padding(2);
        p1Controller.Name = "p1Controller";
        p1Controller.Size = new Size(181, 23);
        p1Controller.TabIndex = 5;
        p1Controller.SelectionChangeCommitted += p1Controller_SelectionChangeCommitted;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = Color.Transparent;
        label1.ForeColor = Color.White;
        label1.Location = new Point(187, 355);
        label1.Margin = new Padding(2, 0, 2, 0);
        label1.Name = "label1";
        label1.Size = new Size(51, 15);
        label1.TabIndex = 6;
        label1.Text = "Player 1:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.BackColor = Color.Transparent;
        label2.ForeColor = Color.White;
        label2.Location = new Point(787, 355);
        label2.Margin = new Padding(2, 0, 2, 0);
        label2.Name = "label2";
        label2.Size = new Size(51, 15);
        label2.TabIndex = 8;
        label2.Text = "Player 2:";
        // 
        // p2Controller
        // 
        p2Controller.DropDownStyle = ComboBoxStyle.DropDownList;
        p2Controller.FormattingEnabled = true;
        p2Controller.Location = new Point(751, 456);
        p2Controller.Margin = new Padding(2);
        p2Controller.Name = "p2Controller";
        p2Controller.Size = new Size(181, 23);
        p2Controller.TabIndex = 7;
        p2Controller.SelectionChangeCommitted += p2Controller_SelectionChangeCommitted;
        // 
        // p1Name
        // 
        p1Name.Location = new Point(156, 399);
        p1Name.Margin = new Padding(2);
        p1Name.MaxLength = 13;
        p1Name.Name = "p1Name";
        p1Name.PlaceholderText = "Enter Name";
        p1Name.Size = new Size(181, 23);
        p1Name.TabIndex = 9;
        // 
        // p2Name
        // 
        p2Name.Location = new Point(751, 399);
        p2Name.Margin = new Padding(2);
        p2Name.MaxLength = 13;
        p2Name.Name = "p2Name";
        p2Name.PlaceholderText = "Enter Name";
        p2Name.Size = new Size(181, 23);
        p2Name.TabIndex = 10;
        // 
        // p1Type0
        // 
        p1Type0.BackColor = Color.LimeGreen;
        p1Type0.BackgroundImageLayout = ImageLayout.Center;
        p1Type0.Location = new Point(87, 515);
        p1Type0.Margin = new Padding(2);
        p1Type0.Name = "p1Type0";
        p1Type0.Size = new Size(50, 50);
        p1Type0.TabIndex = 11;
        p1Type0.UseVisualStyleBackColor = false;
        p1Type0.Click += p1Type0_Click;
        // 
        // p1Type1
        // 
        p1Type1.BackColor = Color.Red;
        p1Type1.BackgroundImageLayout = ImageLayout.Center;
        p1Type1.Location = new Point(187, 515);
        p1Type1.Margin = new Padding(2);
        p1Type1.Name = "p1Type1";
        p1Type1.Size = new Size(50, 50);
        p1Type1.TabIndex = 12;
        p1Type1.UseVisualStyleBackColor = false;
        p1Type1.Click += p1Type1_Click;
        // 
        // p1Type2
        // 
        p1Type2.BackColor = Color.Blue;
        p1Type2.BackgroundImageLayout = ImageLayout.Center;
        p1Type2.Location = new Point(287, 515);
        p1Type2.Margin = new Padding(2);
        p1Type2.Name = "p1Type2";
        p1Type2.Size = new Size(50, 50);
        p1Type2.TabIndex = 13;
        p1Type2.UseVisualStyleBackColor = false;
        p1Type2.Click += p1Type2_Click;
        // 
        // p2Type2
        // 
        p2Type2.BackColor = Color.Blue;
        p2Type2.BackgroundImageLayout = ImageLayout.Center;
        p2Type2.Location = new Point(887, 515);
        p2Type2.Margin = new Padding(2);
        p2Type2.Name = "p2Type2";
        p2Type2.Size = new Size(50, 50);
        p2Type2.TabIndex = 16;
        p2Type2.UseVisualStyleBackColor = false;
        p2Type2.Click += p2Type2_Click;
        // 
        // p2Type1
        // 
        p2Type1.BackColor = Color.Red;
        p2Type1.BackgroundImageLayout = ImageLayout.Center;
        p2Type1.Location = new Point(787, 515);
        p2Type1.Margin = new Padding(2);
        p2Type1.Name = "p2Type1";
        p2Type1.Size = new Size(50, 50);
        p2Type1.TabIndex = 15;
        p2Type1.UseVisualStyleBackColor = false;
        p2Type1.Click += p2Type1_Click;
        // 
        // p2Type0
        // 
        p2Type0.BackColor = Color.FromArgb(0, 192, 0);
        p2Type0.BackgroundImageLayout = ImageLayout.Center;
        p2Type0.Location = new Point(687, 515);
        p2Type0.Margin = new Padding(2);
        p2Type0.Name = "p2Type0";
        p2Type0.Size = new Size(50, 50);
        p2Type0.TabIndex = 14;
        p2Type0.UseVisualStyleBackColor = false;
        p2Type0.Click += p2Type0_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.BackColor = Color.Transparent;
        label3.ForeColor = Color.Transparent;
        label3.Location = new Point(687, 402);
        label3.Margin = new Padding(2, 0, 2, 0);
        label3.Name = "label3";
        label3.Size = new Size(42, 15);
        label3.TabIndex = 17;
        label3.Text = "Name:";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.BackColor = Color.Transparent;
        label4.ForeColor = Color.Transparent;
        label4.Location = new Point(687, 459);
        label4.Margin = new Padding(2, 0, 2, 0);
        label4.Name = "label4";
        label4.Size = new Size(55, 15);
        label4.TabIndex = 18;
        label4.Text = "Controls:";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.BackColor = Color.Transparent;
        label5.ForeColor = Color.White;
        label5.Location = new Point(87, 402);
        label5.Margin = new Padding(2, 0, 2, 0);
        label5.Name = "label5";
        label5.Size = new Size(42, 15);
        label5.TabIndex = 19;
        label5.Text = "Name:";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.BackColor = Color.Transparent;
        label6.ForeColor = Color.Transparent;
        label6.Location = new Point(87, 459);
        label6.Margin = new Padding(2, 0, 2, 0);
        label6.Name = "label6";
        label6.Size = new Size(55, 15);
        label6.TabIndex = 20;
        label6.Text = "Controls:";
        // 
        // Menu
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        BackgroundImage = Properties.Resources.backGMenu;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(1024, 768);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(p2Type2);
        Controls.Add(p2Type1);
        Controls.Add(p2Type0);
        Controls.Add(p1Type2);
        Controls.Add(p1Type1);
        Controls.Add(p1Type0);
        Controls.Add(p2Name);
        Controls.Add(p1Name);
        Controls.Add(label2);
        Controls.Add(p2Controller);
        Controls.Add(label1);
        Controls.Add(p1Controller);
        Controls.Add(button4);
        Controls.Add(openScoreboard);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(pictureBox1);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.None;
        Name = "Menu";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Main Menu";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Button button1;
    private Button button2;
    private Button openScoreboard;
    private Button button4;
    private ComboBox p1Controller;
    private Label label1;
    private Label label2;
    private ComboBox p2Controller;
    private TextBox p1Name;
    private TextBox p2Name;
    private Button p1Type0;
    private Button p1Type1;
    private Button p1Type2;
    private Button p2Type2;
    private Button p2Type1;
    private Button p2Type0;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
}
