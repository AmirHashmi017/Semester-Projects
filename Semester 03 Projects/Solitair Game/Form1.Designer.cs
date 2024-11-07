namespace Solitair_Game
{
    partial class Form1
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
            this.DisplayList = new System.Windows.Forms.Panel();
            this.UndoPicture = new System.Windows.Forms.PictureBox();
            this.Undo = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.Moves = new System.Windows.Forms.Label();
            this.DisplayList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UndoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayList
            // 
            this.DisplayList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))));
            this.DisplayList.Controls.Add(this.UndoPicture);
            this.DisplayList.Controls.Add(this.Undo);
            this.DisplayList.Controls.Add(this.Time);
            this.DisplayList.Controls.Add(this.Moves);
            this.DisplayList.Location = new System.Drawing.Point(240, 903);
            this.DisplayList.Name = "DisplayList";
            this.DisplayList.Size = new System.Drawing.Size(1600, 100);
            this.DisplayList.TabIndex = 0;
            this.DisplayList.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // UndoPicture
            // 
            this.UndoPicture.BackColor = System.Drawing.Color.Transparent;
            this.UndoPicture.Location = new System.Drawing.Point(1164, 33);
            this.UndoPicture.Name = "UndoPicture";
            this.UndoPicture.Size = new System.Drawing.Size(67, 53);
            this.UndoPicture.TabIndex = 3;
            this.UndoPicture.TabStop = false;
            // 
            // Undo
            // 
            this.Undo.AutoSize = true;
            this.Undo.BackColor = System.Drawing.Color.Transparent;
            this.Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Undo.Location = new System.Drawing.Point(1237, 44);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(71, 29);
            this.Undo.TabIndex = 2;
            this.Undo.Text = "Undo";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.BackColor = System.Drawing.Color.Transparent;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.Location = new System.Drawing.Point(757, 44);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(139, 29);
            this.Time.TabIndex = 1;
            this.Time.Text = "Time: 02:30";
            this.Time.Click += new System.EventHandler(this.Time_Click);
            // 
            // Moves
            // 
            this.Moves.AutoSize = true;
            this.Moves.BackColor = System.Drawing.Color.Transparent;
            this.Moves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Moves.Location = new System.Drawing.Point(308, 44);
            this.Moves.Name = "Moves";
            this.Moves.Size = new System.Drawing.Size(122, 29);
            this.Moves.TabIndex = 0;
            this.Moves.Text = "Moves: 20";
            this.Moves.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.DisplayList);
            this.Name = "Form1";
            this.Text = "Solitair Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CursorChanged += new System.EventHandler(this.Form1_MouseHover);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            this.DisplayList.ResumeLayout(false);
            this.DisplayList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UndoPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DisplayList;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Moves;
        private System.Windows.Forms.Label Undo;
        private System.Windows.Forms.PictureBox UndoPicture;
    }
}

