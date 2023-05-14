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
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(514, 75);
        pictureBox1.Margin = new Padding(6);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(466, 273);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // button1
        // 
        button1.Location = new Point(594, 395);
        button1.Name = "button1";
        button1.Size = new Size(319, 96);
        button1.TabIndex = 1;
        button1.Text = "New Game";
        button1.UseVisualStyleBackColor = true;
        button1.Click += newGame_Click;
        // 
        // button2
        // 
        button2.Enabled = false;
        button2.Location = new Point(594, 497);
        button2.Name = "button2";
        button2.Size = new Size(319, 96);
        button2.TabIndex = 2;
        button2.Text = "Continue";
        button2.UseVisualStyleBackColor = true;
        button2.Click += continueGame_Click;
        // 
        // button3
        // 
        button3.Location = new Point(594, 599);
        button3.Name = "button3";
        button3.Size = new Size(319, 96);
        button3.TabIndex = 3;
        button3.Text = "Scoreboard";
        button3.UseVisualStyleBackColor = true;
        button3.Click += openScoreBoard_Click;
        // 
        // button4
        // 
        button4.Location = new Point(594, 701);
        button4.Name = "button4";
        button4.Size = new Size(319, 96);
        button4.TabIndex = 4;
        button4.Text = "Quit";
        button4.UseVisualStyleBackColor = true;
        button4.Click += quitGame_Click;
        // 
        // Menu
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1486, 960);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(pictureBox1);
        Margin = new Padding(6);
        Name = "Menu";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private PictureBox pictureBox1;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
}
