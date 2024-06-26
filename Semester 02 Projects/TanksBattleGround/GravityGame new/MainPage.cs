using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravityGame
{
    public partial class MainPage : Form
    {
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer();
        public MainPage()
        {
            InitializeComponent();
     
            sound.SoundLocation = "bgMusic.wav";
            sound.Play();
            if (sound.IsLoadCompleted)
            {
                sound.PlayLooping();

            }
            else { sound.LoadAsync(); }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Play = new Form1();
            Play.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
