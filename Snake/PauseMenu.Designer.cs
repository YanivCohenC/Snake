namespace Snake
{
    partial class PauseMenu
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 42);
            button1.Name = "button1";
            button1.Size = new Size(246, 45);
            button1.TabIndex = 0;
            button1.Text = "Resume";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 93);
            button2.Name = "button2";
            button2.Size = new Size(246, 45);
            button2.TabIndex = 1;
            button2.Text = "Exit Without Saving";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 144);
            button3.Name = "button3";
            button3.Size = new Size(246, 45);
            button3.TabIndex = 2;
            button3.Text = "Save And Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(65, 9);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 3;
            label1.Text = "Game is currently paused";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PauseMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 201);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PauseMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PauseMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}