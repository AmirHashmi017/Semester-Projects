using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GravityGameLibrary
{
    public class Game
    {
        private Form FormReference;
        private List<GameObject> GameObjects;
        private static Game GameInstance;
        private List<CollisionDetection> CollisionDetections;
private int PlayerCount;
private int EnemyCount;
        private int PlayerFireCount;
        private int EnemyFireCount;
        private Game(Form form)
        {
            this.FormReference = form;
            GameObjects = new List<GameObject>();
            CollisionDetections = new List<CollisionDetection>();
PlayerCount=0;
EnemyCount=0;
            PlayerFireCount=0;
            EnemyFireCount=0;
        }
        public static Game GetGameInstance(Form form)
        {
            if (GameInstance == null)
            {
                GameInstance = new Game(form);
            }
            return GameInstance;
        }
        public void addGameObject(Image img,GameObjectType type, int Left, int Top, IMovement controller)
        {
            if (!(type==GameObjectType.Player&&PlayerCount>0)||(type==GameObjectType.Enemy&&EnemyCount>5)||(type == GameObjectType.PlayerFire&&PlayerFireCount > 15)||(type == GameObjectType.EnemyFire&&EnemyFireCount > 20))
            {
	if(type==GameObjectType.Player)
	{
	PlayerCount++;
	}
	else if(type==GameObjectType.Enemy)
	{
	EnemyCount++;
	}
                else if (type == GameObjectType.PlayerFire)
                {
                    PlayerFireCount++;
                }
                else if (type == GameObjectType.EnemyFire)
                {
                    EnemyFireCount++;
                }
                GameObject gameobject = new GameObject(FormReference,img,type, Left, Top, controller);
                FormReference.Controls.Add(gameobject.Pb);
                GameObjects.Add(gameobject);
            }
        }
        
        public void update()
        {
           
            foreach (GameObject gameobject in GameObjects)
            {
                gameobject.Update();
                foreach(CollisionDetection collision in CollisionDetections)
                {
                    collision.checkCollision(GameObjects);
                }
            }

        }
        public void AddCollisionDetection(CollisionDetection collision)
        {
            CollisionDetections.Add(collision);
        }
public void FirePlayer(Image img)
{
            int left = 0, top=0;
       foreach(GameObject gameobject in GameObjects)
       {
	if(gameobject.GetGameObjectType()==GameObjectType.Player)
	{
	left=gameobject.Pb.Left+gameobject.Pb.Width;
	top=(gameobject.Pb.Top)+(gameobject.Pb.Height/2);
	break;
	}
      }
	addGameObject(img,GameObjectType.PlayerFire, left, top, new FireMovement(20, new Point(FormReference.Width,FormReference.Height),Direction.Right));
}
public void FireEnemy(Image img)
{
           
	int left=0,top = 0;
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObject gameobject = GameObjects[i];
                if (gameobject.GetGameObjectType() == GameObjectType.Enemy)
                {

                    left = gameobject.Pb.Left - 3;
                    top = (gameobject.Pb.Top) + (gameobject.Pb.Height / 2);
                    addGameObject(img, GameObjectType.EnemyFire, left, top, new FireMovement(30, new Point(FormReference.Width, FormReference.Height), Direction.Left));
                }
            }
            
           

       }


        public void RemoveGameObject()
        {
            for(int i=0;i<GameObjects.Count;i++)
            {
                GameObject gameobject = GameObjects[i];
                if(gameobject.GetHealth()==0||gameobject.Pb.Location.X>FormReference.Width||gameobject.Pb.Location.Y>FormReference.Height)
                {
                    if (gameobject.GetGameObjectType() == GameObjectType.PlayerFire)
                        PlayerFireCount--;
                    else if (gameobject.GetGameObjectType() == GameObjectType.EnemyFire)
                        EnemyFireCount--;
                    if (gameobject.HealthBar != null)
                    {
                        FormReference.Controls.Remove(gameobject.HealthBar);
                    }
                    GameObjects.Remove(gameobject);
                    FormReference.Controls.Remove(gameobject.Pb);
                    
                    
                }
            }
        }
        public int GetEnemiesCount()
        {
            return EnemyCount;
        }
        public int GetCurrentEnemiesCount()
        {
            List<GameObject> Enemies = new List<GameObject>();
           
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObject gameobject = GameObjects[i];
                if (gameobject.GetGameObjectType() == GameObjectType.Enemy)
                {
                    Enemies.Add(gameobject);
                }
            }
            return Enemies.Count;
        }
        public int GetCurrentPlayersCount()
        {
            List<GameObject> Players = new List<GameObject>();

            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObject gameobject = GameObjects[i];
                if (gameobject.GetGameObjectType() == GameObjectType.Player)
                {
                    Players.Add(gameobject);
                }
            }
            return Players.Count;
        }
    }
}