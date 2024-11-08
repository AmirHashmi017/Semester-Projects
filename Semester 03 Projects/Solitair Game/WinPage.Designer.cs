namespace Solitair_Game
{
    partial class WinPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.Moves = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(731, 167);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(384, 117);
            this.label1.TabIndex = 5;
            this.label1.Text = "You Won";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.BackColor = System.Drawing.Color.Transparent;
            this.Time.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.White;
            this.Time.Location = new System.Drawing.Point(691, 473);
            this.Time.Name = "Time";
            this.Time.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Time.Size = new System.Drawing.Size(477, 60);
            this.Time.TabIndex = 6;
            this.Time.Text = "Time Consumed:  23:40";
            this.Time.Click += new System.EventHandler(this.Time_Click);
            // 
            // Moves
            // 
            this.Moves.AutoSize = true;
            this.Moves.BackColor = System.Drawing.Color.Transparent;
            this.Moves.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Moves.ForeColor = System.Drawing.Color.White;
            this.Moves.Location = new System.Drawing.Point(760, 365);
            this.Moves.Name = "Moves";
            this.Moves.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Moves.Size = new System.Drawing.Size(327, 60);
            this.Moves.TabIndex = 7;
            this.Moves.Text = "Total Moves: 23";
            this.Moves.Click += new System.EventHandler(this.Moves_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(822, 609);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 56);
            this.button3.TabIndex = 10;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // WinPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 801);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Moves);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "WinPage";
            this.Text = "WinPage";
            this.Load += new System.EventHandler(this.WinPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Moves;
        private System.Windows.Forms.Button button3;
    }
}