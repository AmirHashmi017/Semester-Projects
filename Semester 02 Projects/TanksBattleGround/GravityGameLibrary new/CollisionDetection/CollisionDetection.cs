using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravityGameLibrary
{
    public class CollisionDetection
    {
        // class for collision detection

        private GameObjectType Type1;
        private GameObjectType Type2;
        private CollisionAction Action;

        public CollisionDetection(GameObjectType type1, GameObjectType type2, CollisionAction action)
        {
            this.Type1 = type1;
            this.Type2 = type2;
            this.Action = action;
        }

        public void checkCollision(List<GameObject> gameobjects)
        {
            foreach (GameObject g1 in gameobjects)
            {
                if (g1.GetGameObjectType() == this.Type1)
                {
                    foreach (GameObject g2 in gameobjects)
                    {
                        if (g2.GetGameObjectType() == this.Type2)
                        {
                            if (g1.Pb.Bounds.IntersectsWith(g2.Pb.Bounds))
                            {
                                if (Action == CollisionAction.DecreaseHealth)
                                {
                                    g1.SetHealth(g1.GetHealth() - 1);  
                                }
                                else if (Action == CollisionAction.DecreasePlayerHealthByBullet)
                                {
                                    g1.SetHealth(0);
                                    g2.SetHealth(g2.GetHealth() - 10);
                                }
                                else if (Action == CollisionAction.Kill)
                                {
                                    g1.SetHealth(0);
                                    g2.SetHealth(g2.GetHealth()-15);  
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
    }



}

