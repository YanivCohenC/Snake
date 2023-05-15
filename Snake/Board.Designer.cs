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
            p1name_b = new Label();
            SuspendLayout();
            // 
            // p1name_b
            // 
            p1name_b.AutoSize = true;
            p1name_b.Location = new Point(53, 37);
            p1name_b.Name = "p1name_b";
            p1name_b.Size = new Size(116, 25);
            p1name_b.TabIndex = 0;
            p1name_b.Text = "Player1Name";
            // 
            // Board
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 720);
            Controls.Add(p1name_b);
            Name = "Board";
            Text = "Board";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label p1name_b;
    }
}