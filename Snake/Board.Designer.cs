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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // p1name_b
            // 
            p1name_b.AutoSize = true;
            p1name_b.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            p1name_b.ForeColor = Color.White;
            p1name_b.Location = new Point(12, 9);
            p1name_b.Name = "p1name_b";
            p1name_b.Size = new Size(114, 38);
            p1name_b.TabIndex = 0;
            p1name_b.Text = "Snake 1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(850, 9);
            label1.Name = "label1";
            label1.Size = new Size(114, 38);
            label1.TabIndex = 1;
            label1.Text = "Snake 2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 47);
            label2.Name = "label2";
            label2.Size = new Size(92, 38);
            label2.TabIndex = 2;
            label2.Text = "Score:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(850, 47);
            label3.Name = "label3";
            label3.Size = new Size(92, 38);
            label3.TabIndex = 3;
            label3.Text = "Score:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(95, 47);
            label4.Name = "label4";
            label4.Size = new Size(32, 38);
            label4.TabIndex = 4;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(932, 47);
            label5.Name = "label5";
            label5.Size = new Size(32, 38);
            label5.TabIndex = 5;
            label5.Text = "0";
            // 
            // Board
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 40);
            ClientSize = new Size(1258, 968);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(p1name_b);
            Name = "Board";
            Text = "Board";
            FormClosed += Board_FormClosed;
            Load += Board_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label p1name_b;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}