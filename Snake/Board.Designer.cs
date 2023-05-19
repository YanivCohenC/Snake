namespace Snake
{
    partial class Board
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            p1NameLabel = new Label();
            p2NameLabel = new Label();
            p1ScoreLabel1 = new Label();
            p2ScoreLabel1 = new Label();
            p1ScoreLabel2 = new Label();
            p2ScoreLabel2 = new Label();
            countdownLabel = new Label();
            SuspendLayout();
            // 
            // p1NameLabel
            // 
            p1NameLabel.AutoSize = true;
            p1NameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            p1NameLabel.ForeColor = Color.White;
            p1NameLabel.Location = new Point(9, 6);
            p1NameLabel.Margin = new Padding(2, 0, 2, 0);
            p1NameLabel.Name = "p1NameLabel";
            p1NameLabel.Size = new Size(77, 25);
            p1NameLabel.TabIndex = 0;
            p1NameLabel.Text = "Snake 1";
            p1NameLabel.Visible = false;
            // 
            // p2NameLabel
            // 
            p2NameLabel.AutoSize = true;
            p2NameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            p2NameLabel.ForeColor = Color.White;
            p2NameLabel.Location = new Point(901, 6);
            p2NameLabel.Margin = new Padding(2, 0, 2, 0);
            p2NameLabel.Name = "p2NameLabel";
            p2NameLabel.Size = new Size(77, 25);
            p2NameLabel.TabIndex = 1;
            p2NameLabel.Text = "Snake 2";
            p2NameLabel.Visible = false;
            // 
            // p1ScoreLabel1
            // 
            p1ScoreLabel1.AutoSize = true;
            p1ScoreLabel1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            p1ScoreLabel1.ForeColor = Color.White;
            p1ScoreLabel1.Location = new Point(9, 28);
            p1ScoreLabel1.Margin = new Padding(2, 0, 2, 0);
            p1ScoreLabel1.Name = "p1ScoreLabel1";
            p1ScoreLabel1.Size = new Size(63, 25);
            p1ScoreLabel1.TabIndex = 2;
            p1ScoreLabel1.Text = "Score:";
            p1ScoreLabel1.Visible = false;
            // 
            // p2ScoreLabel1
            // 
            p2ScoreLabel1.AutoSize = true;
            p2ScoreLabel1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            p2ScoreLabel1.ForeColor = Color.White;
            p2ScoreLabel1.Location = new Point(901, 28);
            p2ScoreLabel1.Margin = new Padding(2, 0, 2, 0);
            p2ScoreLabel1.Name = "p2ScoreLabel1";
            p2ScoreLabel1.Size = new Size(63, 25);
            p2ScoreLabel1.TabIndex = 3;
            p2ScoreLabel1.Text = "Score:";
            p2ScoreLabel1.Visible = false;
            // 
            // p1ScoreLabel2
            // 
            p1ScoreLabel2.AutoSize = true;
            p1ScoreLabel2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            p1ScoreLabel2.ForeColor = Color.White;
            p1ScoreLabel2.Location = new Point(66, 28);
            p1ScoreLabel2.Margin = new Padding(2, 0, 2, 0);
            p1ScoreLabel2.Name = "p1ScoreLabel2";
            p1ScoreLabel2.Size = new Size(22, 25);
            p1ScoreLabel2.TabIndex = 4;
            p1ScoreLabel2.Text = "0";
            p1ScoreLabel2.Visible = false;
            // 
            // p2ScoreLabel2
            // 
            p2ScoreLabel2.AutoSize = true;
            p2ScoreLabel2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            p2ScoreLabel2.ForeColor = Color.White;
            p2ScoreLabel2.Location = new Point(958, 28);
            p2ScoreLabel2.Margin = new Padding(2, 0, 2, 0);
            p2ScoreLabel2.Name = "p2ScoreLabel2";
            p2ScoreLabel2.Size = new Size(22, 25);
            p2ScoreLabel2.TabIndex = 5;
            p2ScoreLabel2.Text = "0";
            p2ScoreLabel2.Visible = false;
            // 
            // countdownLabel
            // 
            countdownLabel.AutoSize = true;
            countdownLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            countdownLabel.ForeColor = Color.White;
            countdownLabel.Location = new Point(404, 9);
            countdownLabel.Margin = new Padding(2, 0, 2, 0);
            countdownLabel.Name = "countdownLabel";
            countdownLabel.Size = new Size(177, 25);
            countdownLabel.TabIndex = 6;
            countdownLabel.Text = "Game will start in: 5";
            // 
            // Board
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 40);
            ClientSize = new Size(1024, 768);
            Controls.Add(countdownLabel);
            Controls.Add(p2ScoreLabel2);
            Controls.Add(p1ScoreLabel2);
            Controls.Add(p2ScoreLabel1);
            Controls.Add(p1ScoreLabel1);
            Controls.Add(p2NameLabel);
            Controls.Add(p1NameLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Board";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += Board_FormClosed;
            Load += Board_Load;
            Shown += Board_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label p1NameLabel;
        private Label p2NameLabel;
        private Label p1ScoreLabel1;
        private Label p2ScoreLabel1;
        private Label p1ScoreLabel2;
        private Label p2ScoreLabel2;
        private Label countdownLabel;
    }
}