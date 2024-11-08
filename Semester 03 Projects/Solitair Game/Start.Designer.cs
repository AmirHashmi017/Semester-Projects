namespace Solitair_Game
{
    partial class Start
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
            this.Easy = new System.Windows.Forms.PictureBox();
            this.Hard = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Easy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hard)).BeginInit();
            this.SuspendLayout();
            // 
            // Easy
            // 
            this.Easy.BackColor = System.Drawing.Color.Transparent;
            this.Easy.Location = new System.Drawing.Point(712, 340);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(176, 206);
            this.Easy.TabIndex = 2;
            this.Easy.TabStop = false;
            this.Easy.Click += new System.EventHandler(this.Easy_Click);
            // 
            // Hard
            // 
            this.Hard.BackColor = System.Drawing.Color.Transparent;
            this.Hard.Location = new System.Drawing.Point(1021, 340);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(176, 206);
            this.Hard.TabIndex = 3;
            this.Hard.TabStop = false;
            this.Hard.Click += new System.EventHandler(this.Hard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(738, 97);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(437, 87);
            this.label1.TabIndex = 4;
            this.label1.Text = "Solitair Game";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 801);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hard);
            this.Controls.Add(this.Easy);
            this.Name = "Start";
            this.Text = "Solitair Game";
            this.Load += new System.EventHandler(this.Start_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Easy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Easy;
        private System.Windows.Forms.PictureBox Hard;
        private System.Windows.Forms.Label label1;
    }
}