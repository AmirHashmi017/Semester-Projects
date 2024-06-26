using GravityGameLibrary;
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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void status_Click(object sender, EventArgs e)
        {
            
        }

        private void score_Click(object sender, EventArgs e)
        {

        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            int Score = ((Form1.game.GetEnemiesCount() - Form1.game.GetCurrentEnemiesCount()) * 100);
            if (Form1.game.GetCurrentEnemiesCount() == 0)
            {
                status.Text = "You Win";
            }
            else
            {
                status.Text = "You Lose";
            }
            label2.Text = Score.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
