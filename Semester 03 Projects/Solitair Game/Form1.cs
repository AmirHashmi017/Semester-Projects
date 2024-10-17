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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            this.WindowState = FormWindowState.Maximized;
            InitializeGame.InitializeGameFunction();
            DisplayStockPile();
            DisplayTableaus();
        }
        private void DisplayStockPile()
        {
            PictureBox stockPilePictureBox = new PictureBox();
            stockPilePictureBox.Location = new Point(20, 20);
            stockPilePictureBox.Size = new Size(CardSpecifications.CardWidth, CardSpecifications.CardHeight); // Standard card size

                Card topStockCard =InitializeGame.StockPile.Peek();
                stockPilePictureBox.Image = Image.FromFile(topStockCard.BackImg);
                stockPilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Controls.Add(stockPilePictureBox);
        }

        private void DisplayTableaus()
        {
            int startX = 200;
            int startY = 180;
            int cardOffsetY = 38;
            for (int i = 0; i < InitializeGame.Tableaus.Count; i++)
            {
                Stack tableau = InitializeGame.Tableaus[i];
                int x = startX + i * 120;
                int NumberOfCards = tableau.GetTotalNumberOfCards();
                int y = startY+NumberOfCards*38;
                int count = 0;
                while(tableau.Peek()!=null)
                {
                    Card card= tableau.Pop();
                    PictureBox tableauCardPictureBox = new PictureBox();
                    tableauCardPictureBox.Location = new Point(x, y);
                    tableauCardPictureBox.Size = new Size(CardSpecifications.CardWidth, CardSpecifications.CardHeight);
                    if(count==0)
                    {
                        card.IsFaceUp = true;
                    }
                    string cardImagePath;
                    if(card.IsFaceUp )
                    {
                        cardImagePath=card.CardImg;
                    }
                    else
                    {
                        cardImagePath=card.BackImg;
                    }
                    tableauCardPictureBox.Image = Image.FromFile(cardImagePath);
                    tableauCardPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    this.Controls.Add(tableauCardPictureBox);

                    y -= cardOffsetY;
                    count++;
                }
            }
        }
    }
}
