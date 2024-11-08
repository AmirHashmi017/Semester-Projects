using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitair_Game
{
    public partial class WinPage : Form
    {
        public WinPage()
        {
            InitializeComponent();
        }

        private void WinPage_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("D:\\Semester 03\\DSA Lab\\csc200m24pid11\\Solitair Game\\Assests\\CardsImages\\ImageBest.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.WindowState = FormWindowState.Maximized;
            Moves.Text = $"Total Moves: {Form1.TotalMoves}";
            TimeSpan time = TimeSpan.FromSeconds(Form1.ElapsedSeconds);
            Time.Text = $"Time Consumed: {time:mm\\:ss}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Moves_Click(object sender, EventArgs e)
        {

        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start startform = new Start();
            this.Hide();
            startform.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}
