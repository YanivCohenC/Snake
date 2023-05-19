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
        p1Type0 = new Button();
        p1Type1 = new Button();
        p1Type2 = new Button();
        p2Type2 = new Button();
        p2Type1 = new Button();
        p2Type0 = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBox1.Location = new Point(324, 44);
        pictureBox1.Margin = new Padding(6);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(866, 349);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // button1
        // 
        button1.Location = new Point(594, 452);
        button1.Name = "button1";
        button1.Size = new Size(318, 96);
        button1.TabIndex = 1;
        button1.Text = "New Game";
        button1.UseVisualStyleBackColor = true;
        button1.Click += newGame_Click;
        // 
        // button2
        // 
        button2.Enabled = false;
        button2.Location = new Point(594, 554);
        button2.Name = "button2";
        button2.Size = new Size(318, 96);
        button2.TabIndex = 2;
        button2.Text = "Continue";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new Point(594, 655);
        button3.Name = "button3";
        button3.Size = new Size(318, 96);
        button3.TabIndex = 3;
        button3.Text = "Scoreboard";
        button3.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.Location = new Point(594, 758);
        button4.Name = "button4";
        button4.Size = new Size(318, 96);
        button4.TabIndex = 4;
        button4.Text = "Quit";
        button4.UseVisualStyleBackColor = true;
        button4.Click += quitGame_Click;
        // 
        // p1Controller
        // 
        p1Controller.DropDownStyle = ComboBoxStyle.DropDownList;
        p1Controller.FormattingEnabled = true;
        p1Controller.Location = new Point(134, 554);
        p1Controller.Margin = new Padding(4);
        p1Controller.Name = "p1Controller";
        p1Controller.Size = new Size(295, 40);
        p1Controller.TabIndex = 5;
        p1Controller.SelectionChangeCommitted += p1Controller_SelectionChangeCommitted;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(134, 498);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(103, 32);
        label1.TabIndex = 6;
        label1.Text = "Player 1:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(1112, 498);
        label2.Margin = new Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new Size(103, 32);
        label2.TabIndex = 8;
        label2.Text = "Player 2:";
        // 
        // p2Controller
        // 
        p2Controller.DropDownStyle = ComboBoxStyle.DropDownList;
        p2Controller.FormattingEnabled = true;
        p2Controller.Location = new Point(1112, 554);
        p2Controller.Margin = new Padding(4);
        p2Controller.Name = "p2Controller";
        p2Controller.Size = new Size(295, 40);
        p2Controller.TabIndex = 7;
        p2Controller.SelectionChangeCommitted += p2Controller_SelectionChangeCommitted;
        // 
        // p1Name
        // 
        p1Name.Location = new Point(243, 494);
        p1Name.Margin = new Padding(4);
        p1Name.MaxLength = 13;
        p1Name.Name = "p1Name";
        p1Name.PlaceholderText = "Enter Name";
        p1Name.Size = new Size(186, 39);
        p1Name.TabIndex = 9;
        // 
        // p2Name
        // 
        p2Name.Location = new Point(1221, 494);
        p2Name.Margin = new Padding(4);
        p2Name.MaxLength = 13;
        p2Name.Name = "p2Name";
        p2Name.PlaceholderText = "Enter Name";
        p2Name.Size = new Size(186, 39);
        p2Name.TabIndex = 10;
        // 
        // p1Type0
        // 
        p1Type0.BackColor = Color.LimeGreen;
        p1Type0.BackgroundImageLayout = ImageLayout.Center;
        p1Type0.Location = new Point(134, 607);
        p1Type0.Margin = new Padding(4);
        p1Type0.Name = "p1Type0";
        p1Type0.Size = new Size(69, 67);
        p1Type0.TabIndex = 11;
        p1Type0.UseVisualStyleBackColor = false;
        p1Type0.Click += p1Type0_Click;
        // 
        // p1Type1
        // 
        p1Type1.BackColor = Color.Red;
        p1Type1.BackgroundImageLayout = ImageLayout.Center;
        p1Type1.Location = new Point(243, 607);
        p1Type1.Margin = new Padding(4);
        p1Type1.Name = "p1Type1";
        p1Type1.Size = new Size(69, 67);
        p1Type1.TabIndex = 12;
        p1Type1.UseVisualStyleBackColor = false;
        p1Type1.Click += p1Type1_Click;
        // 
        // p1Type2
        // 
        p1Type2.BackColor = Color.Blue;
        p1Type2.BackgroundImageLayout = ImageLayout.Center;
        p1Type2.Location = new Point(351, 607);
        p1Type2.Margin = new Padding(4);
        p1Type2.Name = "p1Type2";
        p1Type2.Size = new Size(69, 67);
        p1Type2.TabIndex = 13;
        p1Type2.UseVisualStyleBackColor = false;
        p1Type2.Click += p1Type2_Click;
        // 
        // p2Type2
        // 
        p2Type2.BackColor = Color.Blue;
        p2Type2.BackgroundImageLayout = ImageLayout.Center;
        p2Type2.Location = new Point(1329, 607);
        p2Type2.Margin = new Padding(4);
        p2Type2.Name = "p2Type2";
        p2Type2.Size = new Size(69, 67);
        p2Type2.TabIndex = 16;
        p2Type2.UseVisualStyleBackColor = false;
        p2Type2.Click += p2Type2_Click;
        // 
        // p2Type1
        // 
        p2Type1.BackColor = Color.Red;
        p2Type1.BackgroundImageLayout = ImageLayout.Center;
        p2Type1.Location = new Point(1221, 607);
        p2Type1.Margin = new Padding(4);
        p2Type1.Name = "p2Type1";
        p2Type1.Size = new Size(69, 67);
        p2Type1.TabIndex = 15;
        p2Type1.UseVisualStyleBackColor = false;
        p2Type1.Click += p2Type1_Click;
        // 
        // p2Type0
        // 
        p2Type0.BackColor = Color.FromArgb(0, 192, 0);
        p2Type0.BackgroundImageLayout = ImageLayout.Center;
        p2Type0.Location = new Point(1112, 607);
        p2Type0.Margin = new Padding(4);
        p2Type0.Name = "p2Type0";
        p2Type0.Size = new Size(69, 67);
        p2Type0.TabIndex = 14;
        p2Type0.UseVisualStyleBackColor = false;
        p2Type0.Click += p2Type0_Click;
        // 
        // Menu
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(1531, 922);
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
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(pictureBox1);
        Margin = new Padding(6);
        Name = "Menu";
        StartPosition = FormStartPosition.CenterScreen;
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
    private Button p1Type0;
    private Button p1Type1;
    private Button p1Type2;
    private Button p2Type2;
    private Button p2Type1;
    private Button p2Type0;
}
