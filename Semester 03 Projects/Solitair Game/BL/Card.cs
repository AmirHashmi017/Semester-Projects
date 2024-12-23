﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{

    //Card class containing attributes of card.
    public class Card
    {
        public string Suit;
        public string Rank;
        public string CardImg;
        public string BackImg;
        public bool IsFaceUp;
        public string Color;

        //Copy Constructor for deep copy of card.
        public Card(Card card)
        {
            this.Suit = card.Suit;
            this.Rank = card.Rank;
            this.CardImg = card.CardImg;
            this.BackImg = card.BackImg;
            this.IsFaceUp = card.IsFaceUp;
            this.Color = card.Color;
        }

        //Parameterized Constructor for creating Card.
        public Card(string Suit, string Rank)
        {
            this.Suit = Suit;
            this.Rank = Rank;
            this.CardImg = $"{CardSpecifications.CardsImagePath}{Rank}_of_{Suit}.png";
            this.BackImg = $"{CardSpecifications.CardsImagePath}CardBackImage.png";
            this.IsFaceUp = false;
            if (Suit == "hearts" || Suit == "diamonds")
            {
                this.Color = "Red";
            }
            else
            {
                this.Color = "Black";
            }

        }
    }
}
