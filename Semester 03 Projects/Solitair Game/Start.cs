using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Solitair_Game
{
    public partial class Start : Form
    {
        public static string Difficulty;
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("D:\\Semester 03\\DSA Lab\\csc200m24pid11\\Solitair Game\\Assests\\CardsImages\\ImageBest.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            Easy.Image = Image.FromFile("D:\\Semester 03\\DSA Lab\\csc200m24pid11\\Solitair Game\\Assests\\CardsImages\\Easy.png");
            Easy.SizeMode = PictureBoxSizeMode.StretchImage;
            Easy.Cursor = Cursors.Hand;
            this.WindowState = FormWindowState.Maximized;
            Hard.Image = Image.FromFile("D:\\Semester 03\\DSA Lab\\csc200m24pid11\\Solitair Game\\Assests\\CardsImages\\Hard.png");
            Hard.SizeMode = PictureBoxSizeMode.StretchImage;
            Hard.Cursor = Cursors.Hand;
            this.WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Easy_Click(object sender, EventArgs e)
        {
            Difficulty = "Easy";
            Form1 gameForm = new Form1();
            this.Hide();
            gameForm.Show();

        }

        private void Hard_Click(object sender, EventArgs e)
        {
            Difficulty = "Hard";
            Form1 gameForm = new Form1();
            this.Hide();
            gameForm.Show();
        }
    }
}
