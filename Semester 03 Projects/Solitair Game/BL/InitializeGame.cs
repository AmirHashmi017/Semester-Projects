using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    internal class InitializeGame
    {
        public static List<Card> Deck = new List<Card>();
        public static Queue StockPile = new Queue();
        public static List<Stack>Tableaus=new List<Stack>();
        public static Stack HeartsFoundation;
        public static Stack DiamondsFoundation;
        public static Stack ClubsFoundation;
        public static Stack SpadesFoundation;
        public static void InitializeGameFunction()
        {
            HeartsFoundation=new Stack();
            ClubsFoundation=new Stack();
            DiamondsFoundation=new Stack();
            SpadesFoundation=new Stack();
            CreateDeck();
            ShuffleDeck();
            CreateTableausAndStockpile();
        }
        public static void CreateDeck()
        {
            List<string> Suits = new List<string> { "hearts", "diamonds", "clubs", "spades" };
            List<string> Ranks = new List<string> { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };
            foreach (string Suit in Suits)
            {
                foreach (string Rank in Ranks)
                {
                    Card card = new Card(Suit, Rank);
                    Deck.Add(card);
                }
            }
        }
        public static void ShuffleDeck()
        {
            Random rand = new Random();
            for (int i = 0; i < Deck.Count; i++)
            {
                int RandIndex = rand.Next(Deck.Count);
                Card swap = Deck[i];
                Deck[i] = Deck[RandIndex];
                Deck[RandIndex] = swap;
            }
        }
        public static void CreateTableausAndStockpile()
        {
            for(int i=0;i<7;i++)
            {
                Stack Tableau= new Stack();
                int CardsinTableau = i + 1;
                for(int j=0;j<CardsinTableau;j++)
                {
                    Tableau.Push(Deck[0]);
                    Deck.RemoveAt(0);
                }
                Tableaus.Add(Tableau);
            }
            for(int i=0;i<Deck.Count;i++)
            {
                StockPile.Enqueue(Deck[i]);
            }
        }
    }
}
