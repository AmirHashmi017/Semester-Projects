using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravityGameLibrary
{

    public class GameObject
    {
        private IMovement MovementController;
        private GameObjectType Type;
        private int Health;
        internal PictureBox Pb;
	internal ProgressBar HealthBar;
        public GameObject(Form formreference,Image img,GameObjectType type, int left, int top, IMovement controller)
        {
            Pb = new PictureBox();
            this.Type = type;
            Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            Pb.BackColor = Color.Transparent;
            Pb.Image = img;
            Pb.Width = img.Width;
            Pb.Height = img.Height;            
            Pb.Left = left;
            Pb.Top = top;
            this.MovementController = controller;
            this.Health = 100;
	if(type==GameObjectType.Player || type == GameObjectType.Enemy)
	{
	HealthBar=new ProgressBar();
	HealthBar.Top=top+2;
	HealthBar.Left=left;
	HealthBar.TabIndex=0;
	HealthBar.Size=new System.Drawing.Size(80,13);
	HealthBar.Value=Health;
                formreference.Controls.Add(HealthBar);
	}
        }
        public void Update()
        {
            this.Pb.Location = MovementController.Move(this.Pb.Location);
            if(HealthBar!=null)
	this.HealthBar.Location = new Point(Pb.Left,Pb.Top-10);
        }
        public GameObjectType GetGameObjectType()
        {
            return this.Type;
        }
        public void SetHealth(int health)
        {
            if (health >= 0)
            {
                Health = health;
            }
	else if (health <0)
            {
                Health = 0;
            }
            if(HealthBar!=null)
	this.HealthBar.Value=this.Health;
        }
        public int GetHealth()
        {
            return Health;
        }
        public IMovement GetMovementController()
        {
            return MovementController;
        }
    }
}
