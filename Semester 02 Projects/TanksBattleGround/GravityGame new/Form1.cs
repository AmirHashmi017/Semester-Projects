using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using GravityGameLibrary;


namespace GravityGame
{

   


    public partial class Form1 : Form
    {
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer();
        public static Game game;
        public static int Score;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            sound.SoundLocation = "bgMusic.wav";
            sound.Play();
            if(sound.IsLoadCompleted)
            {
                sound.PlayLooping();

            }
            else { sound.LoadAsync(); }
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {

            game = Game.GetGameInstance(this);

            System.Drawing.Point boundary = new System.Drawing.Point(this.Width-100, this.Height-200);

            game.addGameObject(Properties.Resources.Player1,GameObjectType.Player, 40, 80, new KeyBoardMovement(10, boundary));
            game.addGameObject(Properties.Resources.Enemy11, GameObjectType.Enemy, 820, 170, new ZigZagMovement(10, boundary));
            game.addGameObject(Properties.Resources.Enemy2,GameObjectType.Enemy, 920,10, new VerticalMovement(10, boundary,Direction.Down));
            game.addGameObject(Properties.Resources.Enemy1, GameObjectType.Enemy, 600, 250, new Teleportation(10, boundary));
            game.addGameObject(Properties.Resources.enemy3, GameObjectType.Enemy, 820, 370, new ZigZagMovement(10, boundary));
            CollisionDetection collisionDetection1 = new CollisionDetection(GameObjectType.Player,GameObjectType.Enemy,CollisionAction.DecreaseHealth);
            CollisionDetection collisionDetection2 = new CollisionDetection(GameObjectType.PlayerFire, GameObjectType.Enemy, CollisionAction.Kill);
            CollisionDetection collisionDetection3 = new CollisionDetection(GameObjectType.EnemyFire, GameObjectType.Player, CollisionAction.DecreasePlayerHealthByBullet);
            game.AddCollisionDetection(collisionDetection1);
            game.AddCollisionDetection(collisionDetection2);
            game.AddCollisionDetection(collisionDetection3);
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        { 
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                game.FirePlayer(Properties.Resources.BulletPlayer);
            }
            game.RemoveGameObject();
            game.update();
            Score = ((game.GetEnemiesCount() - game.GetCurrentEnemiesCount()) * 100);
            label3.Text = Score.ToString();
            if (game.GetCurrentEnemiesCount() == 0 || game.GetCurrentPlayersCount() == 0)
            {
                this.Close();
                Form gameover = new GameOver();
                gameover.Show();
            }
        }

        private void Enemyfiring_Tick(object sender, EventArgs e)
        {
            game.FireEnemy(Properties.Resources.BulletEnemyy);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
