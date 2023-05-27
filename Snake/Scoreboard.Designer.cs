namespace Snake
{
    partial class Scoreboard
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
            label1 = new Label();
            highScores = new ListBox();
            deleteScore = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(141, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "High Scores:";
            // 
            // highScores
            // 
            highScores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            highScores.FormattingEnabled = true;
            highScores.ItemHeight = 15;
            highScores.Location = new Point(12, 32);
            highScores.Name = "highScores";
            highScores.Size = new Size(338, 244);
            highScores.TabIndex = 1;
            highScores.SelectedIndexChanged += highScores_SelectedIndexChanged;
            // 
            // deleteScore
            // 
            deleteScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deleteScore.Location = new Point(12, 289);
            deleteScore.Name = "deleteScore";
            deleteScore.Size = new Size(338, 38);
            deleteScore.TabIndex = 2;
            deleteScore.Text = "Delete Score";
            deleteScore.UseVisualStyleBackColor = true;
            deleteScore.Click += deleteScore_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(12, 333);
            button2.Name = "button2";
            button2.Size = new Size(338, 38);
            button2.TabIndex = 3;
            button2.Text = "Return to Main Menu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Scoreboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 383);
            Controls.Add(button2);
            Controls.Add(deleteScore);
            Controls.Add(highScores);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Scoreboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Scoreboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox highScores;
        private Button deleteScore;
        private Button button2;
    }
}