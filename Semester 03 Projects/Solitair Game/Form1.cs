using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitair_Game
{
    public partial class Form1 : Form
    {
        public PictureBox stockPilePictureBox;
        public PictureBox wastePilePictureBox;
        public Stack wastePile = new Stack();
        public PictureBox selectedCardPictureBox1;
        public PictureBox selectedCardPictureBox2;
        public Card selectedCard;
        public Stack sourcePile;
        public PictureBox heartsFoundation;
        public PictureBox diamondsFoundation;
        public PictureBox spadesFoundation;
        public PictureBox clubsFoundation;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            this.WindowState = FormWindowState.Maximized;
            InitializeGame.InitializeGameFunction();
            DisplayStockPile();
            DisplayTableaus();
            DisplayFoundations();
        }

        private void DisplayStockPile()
        {
            stockPilePictureBox = new PictureBox();
            stockPilePictureBox.Location = new Point(20, 20);
            stockPilePictureBox.Size = new Size(CardSpecifications.CardWidth, CardSpecifications.CardHeight);
            stockPilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            UpdateStockPileDisplay();
            this.Controls.Add(stockPilePictureBox);
            stockPilePictureBox.Click += new EventHandler(StockPileClick);
        }

        private void StockPileClick(object sender, EventArgs e)
        {
            if (InitializeGame.StockPile.GetTotalNumberOfCards() > 0)
            {
                Card drawnCard = InitializeGame.StockPile.Dequeue();
                drawnCard.IsFaceUp = true;
                wastePile.Push(drawnCard);

                UpdateStockPileDisplay();
                DisplayWastePile();
            }
            else
            {
                RetailCards();
            }
        }

        private void RetailCards()
        {
            
            wastePilePictureBox.Image = null;

            while (wastePile.Peek()!=null)
            {
                Card card = wastePile.Pop();
                card.IsFaceUp = false;
                InitializeGame.StockPile.Enqueue(card);
            }
            UpdateStockPileDisplay();
        }

        private void UpdateStockPileDisplay()
        {
            if (InitializeGame.StockPile.GetTotalNumberOfCards() > 0)
            {
                Card topStockCard = InitializeGame.StockPile.Peek();
                stockPilePictureBox.Image = Image.FromFile(topStockCard.BackImg);
            }
            else
            {
                string retailPath = $"{CardSpecifications.CardsImagePath}retail.png";
                stockPilePictureBox.Image = Image.FromFile(retailPath);
            }
        }

        private void DisplayWastePile()
        {
            this.Controls.Add(wastePilePictureBox);
            if (wastePilePictureBox == null)
            {
                wastePilePictureBox = new PictureBox();
                wastePilePictureBox.Location = new Point(150, 20);
                wastePilePictureBox.Size = new Size(CardSpecifications.CardWidth, CardSpecifications.CardHeight);
                wastePilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(wastePilePictureBox);
                wastePilePictureBox.Click += new EventHandler(Card_Click);
            }

            if (wastePile.GetTotalNumberOfCards()> 0)
            {
                Card topWasteCard = wastePile.Peek();
                wastePilePictureBox.Image = Image.FromFile(topWasteCard.CardImg);
                wastePilePictureBox.Tag = new Tuple<Stack, Card>(wastePile, topWasteCard);
            }
            else
            {
                wastePilePictureBox.Image = null; 
            }
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
                int y = startY + NumberOfCards * 38;
                int count = 0;
                Node currentNode = tableau.Top;
                if(currentNode==null)
                {
                    y = y + 38;
                    PictureBox EmptytableauCardPictureBox = new PictureBox();
                    EmptytableauCardPictureBox.Location = new Point(x, y);
                    EmptytableauCardPictureBox.Size = new Size(CardSpecifications.CardWidth, CardSpecifications.CardHeight);
                    EmptytableauCardPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    string retailPath = $"{CardSpecifications.CardsImagePath}retail.png";
                    EmptytableauCardPictureBox.Image = Image.FromFile(retailPath);
                    EmptytableauCardPictureBox.Tag = new Tuple<Stack, Card>(tableau, null);
                    EmptytableauCardPictureBox.Click += new EventHandler(Card_Click);
                    this.Controls.Add(EmptytableauCardPictureBox);
                }
                while (currentNode != null)
                {
                    Card card = currentNode.CurrentCard;
                    PictureBox tableauCardPictureBox = new PictureBox();
                    tableauCardPictureBox.Location = new Point(x, y);
                    tableauCardPictureBox.Size = new Size(CardSpecifications.CardWidth, CardSpecifications.CardHeight);
                    tableauCardPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (count == 0)
                    {
                        card.IsFaceUp = true;
                        
                    }
                    if (card.IsFaceUp)
                    {
                        tableauCardPictureBox.Click += new EventHandler(Card_Click);
                    }
                    if(card.IsFaceUp)
                    {
                        tableauCardPictureBox.Image = Image.FromFile(card.CardImg);
                    }
                    else
                    {
                        tableauCardPictureBox.Image = Image.FromFile(card.BackImg);
                    }
                    tableauCardPictureBox.Tag = new Tuple<Stack, Card>(tableau, card);
                    this.Controls.Add(tableauCardPictureBox);

                    y -= cardOffsetY;
                    count++;
                    currentNode = currentNode.Next;
                }
            }
        }
        private void DisplayFoundations()
        {
            heartsFoundation= new PictureBox();
            diamondsFoundation = new PictureBox();
            spadesFoundation = new PictureBox();
            clubsFoundation = new PictureBox();

            heartsFoundation.Size = new Size(90, 130);
            heartsFoundation.Location = new Point(450, 20); 
            heartsFoundation.SizeMode = PictureBoxSizeMode.StretchImage;

            diamondsFoundation.Size = new Size(90, 130);
            diamondsFoundation.Location = new Point(570, 20);
            diamondsFoundation.SizeMode = PictureBoxSizeMode.StretchImage;

            spadesFoundation.Size = new Size(90, 130);
            spadesFoundation.Location = new Point(690, 20);
            spadesFoundation.SizeMode = PictureBoxSizeMode.StretchImage;

            clubsFoundation.Size = new Size(90, 130);
            clubsFoundation.Location = new Point(810, 20);
            clubsFoundation.SizeMode = PictureBoxSizeMode.StretchImage;

            heartsFoundation.Image = Image.FromFile("D:\\Semester 03\\DSA Lab\\csc200m24pid11\\Solitair Game\\Assests\\CardsImages\\Heart.png");
            diamondsFoundation.Image = Image.FromFile("D:\\Semester 03\\DSA Lab\\csc200m24pid11\\Solitair Game\\Assests\\CardsImages\\Diamond.png");
            spadesFoundation.Image = Image.FromFile("D:\\Semester 03\\DSA Lab\\csc200m24pid11\\Solitair Game\\Assests\\CardsImages\\Spade.png");
            clubsFoundation.Image = Image.FromFile("D:\\Semester 03\\DSA Lab\\csc200m24pid11\\Solitair Game\\Assests\\CardsImages\\Club.png");


            heartsFoundation.Tag = new Tuple<Stack, string>(InitializeGame.HeartsFoundation, "hearts");
            diamondsFoundation.Tag = new Tuple<Stack, string>(InitializeGame.DiamondsFoundation, "diamonds");
            spadesFoundation.Tag = new Tuple<Stack, string>(InitializeGame.SpadesFoundation, "spades");
            clubsFoundation.Tag = new Tuple<Stack, string>(InitializeGame.ClubsFoundation, "clubs");
            heartsFoundation.Click += new EventHandler(FoundationCard_Click);
            diamondsFoundation.Click += new EventHandler(FoundationCard_Click);
            spadesFoundation.Click += new EventHandler(FoundationCard_Click);
            clubsFoundation.Click += new EventHandler(FoundationCard_Click);
            this.Controls.Add(heartsFoundation);
            this.Controls.Add(diamondsFoundation);
            this.Controls.Add(spadesFoundation);
            this.Controls.Add(clubsFoundation);

           
        }
        private void UpdateFoundationDisplay()
        {
            if(!InitializeGame.HeartsFoundation.IsEmpty())
            {
                Card card = InitializeGame.HeartsFoundation.Peek();
                heartsFoundation.Image = Image.FromFile(card.CardImg);
            }
            if (!InitializeGame.DiamondsFoundation.IsEmpty())
            {
                Card card = InitializeGame.DiamondsFoundation.Peek();
                diamondsFoundation.Image = Image.FromFile(card.CardImg);
            }
            if (!InitializeGame.ClubsFoundation.IsEmpty())
            {
                Card card = InitializeGame.ClubsFoundation.Peek();
                clubsFoundation.Image = Image.FromFile(card.CardImg);
            }
            if (!InitializeGame.SpadesFoundation.IsEmpty())
            {
                Card card = InitializeGame.SpadesFoundation.Peek();
                spadesFoundation.Image = Image.FromFile(card.CardImg);
            }
        }
        private void FoundationCard_Click(object sender, EventArgs e)
        {
            PictureBox clickedFoundationPictureBox = sender as PictureBox;
            var clickedFoundationInfo = (Tuple<Stack,string>)clickedFoundationPictureBox.Tag;
            Stack FoundationPile=clickedFoundationInfo.Item1;
            string foundationsuit = clickedFoundationInfo.Item2;
            if(selectedCard!=null)
            {
                if(selectedCard.Suit==foundationsuit)
                {
                    if(GameAnMovesEvaluation.IsValidFoundationMove(selectedCard,FoundationPile))
                    {
                        Card card = sourcePile.Pop();
                        FoundationPile.Push(card);
                        UpdatePilesAfterMove();
                    }
                }
            }
            HighlightCard(selectedCardPictureBox1, false);


        }

        private void Card_Click(object sender, EventArgs e)
        {
            PictureBox clickedCardPictureBox = sender as PictureBox;
            var clickedCardInfo = (Tuple<Stack, Card>)clickedCardPictureBox.Tag;
            Stack clickedPile = clickedCardInfo.Item1;
            Card clickedCard = clickedCardInfo.Item2;
            if (selectedCardPictureBox1 == null&&clickedCard!=null)
            {
                selectedCardPictureBox1 = clickedCardPictureBox;
                selectedCard = clickedCard;
                sourcePile = clickedPile;
                HighlightCard(clickedCardPictureBox, true);
            }
            else
            {
                selectedCardPictureBox2= clickedCardPictureBox;
                if (IsValidMove(selectedCard, clickedCard, sourcePile, clickedPile))
                {
                    Node topcardnode = sourcePile.Top;
                    List<Card>CardstoShift=new List<Card>();
                    while (topcardnode.CurrentCard!=selectedCard)
                    {
                        Card cardtomove = sourcePile.Pop();
                        CardstoShift.Add(cardtomove);
                        topcardnode=topcardnode.Next;
                    }
                    Card cardselected = sourcePile.Pop();
                    CardstoShift.Add(cardselected);
                    for(int i=CardstoShift.Count-1; i>=0; i--)
                    {
                        clickedPile.Push(CardstoShift[i]);
                    }


                    UpdatePilesAfterMove();
                    HighlightCard(selectedCardPictureBox1, false);
                }
                else
                {
                    HighlightCard(selectedCardPictureBox1, false);
                }
                selectedCardPictureBox1 = null;
                selectedCardPictureBox2 = null;
                selectedCard = null;
                sourcePile = null;
            }
        }

        private bool IsValidMove(Card sourceCard, Card destinationCard,Stack sourcepile,Stack destinationpile)
        {
            if (destinationpile == wastePile||sourcepile==null)
            { 
                return false; 
            }
            if(GameAnMovesEvaluation.IsValidTablaeuMove(sourceCard, destinationCard))
            {  
                return true; 
            }
            return false; 
        }

        private void UpdatePilesAfterMove()
        {
            this.Controls.Clear();

            DisplayStockPile();
            DisplayWastePile();
            DisplayTableaus();
            DisplayFoundations();
            UpdateFoundationDisplay();
            if(GameAnMovesEvaluation.IsWin())
            {
                this.Close();
            }
        }

        private void HighlightCard(PictureBox cardPictureBox, bool highlight)
        {
            if (highlight)
            {
                ControlPaint.DrawBorder(cardPictureBox.CreateGraphics(),
                                        cardPictureBox.ClientRectangle,
                                        Color.Yellow, 3, ButtonBorderStyle.Solid,
                                        Color.Yellow, 3, ButtonBorderStyle.Solid,
                                        Color.Yellow, 3, ButtonBorderStyle.Solid,
                                        Color.Yellow, 3, ButtonBorderStyle.Solid);
            }
            else
            {
                if(cardPictureBox!=null)
                { 
                    cardPictureBox.Invalidate();
                }
                
            }
        }
    }
}
