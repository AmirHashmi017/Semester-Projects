using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityGameLibrary
{
    public class Teleportation : IMovement
    {
        
        private int speed;
        private Point boundary;
        private Random random;
        private DateTime lastTeleportTime;
        private TimeSpan teleportDelay;

        public Teleportation(int speed, Point boundary)
        {
            this.speed = speed;
            this.boundary = boundary;
            random = new Random();
            lastTeleportTime = DateTime.Now;
            teleportDelay = TimeSpan.FromSeconds(2); 
        }



        public Point Move(Point location)
        {
            
            if (DateTime.Now - lastTeleportTime >= teleportDelay)
            {
               
                int x = random.Next(0, boundary.X);
                int y = random.Next(0, boundary.Y);
                location = new Point(x, y);

                
                lastTeleportTime = DateTime.Now;
            }

            
            return location;
        }
    }
}
