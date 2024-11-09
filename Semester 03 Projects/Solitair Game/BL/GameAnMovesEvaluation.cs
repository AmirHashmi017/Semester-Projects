using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    internal class GameAnMovesEvaluation
    {
        //Function for checking Valid moves to Tableau column.
        public static bool IsValidTablaeuMove(Card sourcecard,Card destinationcard)
        {
            if(destinationcard==null )
            {
                if (InitializeGame.hashset.GetValue(sourcecard.Rank)==13)
                return true;
                else
                    return false;
            }
            if(sourcecard.Color!=destinationcard.Color && InitializeGame.hashset.GetValue(sourcecard.Rank)== InitializeGame.hashset.GetValue(destinationcard.Rank)-1)
            {
                return true;
            }
            return false;
        }

        //Function for checking Valid moves to Foundation Piles.
        public static bool IsValidFoundationMove(Card sourcecard, Stack Foundation)
        {
            if (Foundation.IsEmpty())
            {
                if(InitializeGame.hashset.GetValue(sourcecard.Rank) ==1)
                return true;
                else
                return false;
            }
            if (sourcecard.Color == Foundation.Peek().Color && InitializeGame.hashset.GetValue(sourcecard.Rank) == InitializeGame.hashset.GetValue(Foundation.Peek().Rank) + 1)
            {
                return true;
            }
            return false;
        }

        //Function to check game is won or not.
        public static bool IsWin()
        {
            if(InitializeGame.HeartsFoundation.GetTotalNumberOfCards()==13&&InitializeGame.hashset.GetValue(InitializeGame.HeartsFoundation.Peek().Rank)==13&& InitializeGame.DiamondsFoundation.GetTotalNumberOfCards() == 13&&InitializeGame.hashset.GetValue(InitializeGame.DiamondsFoundation.Peek().Rank) == 13&& InitializeGame.SpadesFoundation.GetTotalNumberOfCards() == 13&&InitializeGame.hashset.GetValue(InitializeGame.SpadesFoundation.Peek().Rank) == 13&& InitializeGame.ClubsFoundation.GetTotalNumberOfCards() == 13&&InitializeGame.hashset.GetValue(InitializeGame.ClubsFoundation.Peek().Rank) == 13)
            {
                return true;
            }
            return false;
        }
    }
}
