using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    internal class GameAnMovesEvaluation
    {
        public static Dictionary<string, int> RankValue = new Dictionary<string, int> { { "ace", 1 }, { "2", 2}, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 }, { "jack", 11 }, { "queen", 12 }, { "king", 13 } };
        public static bool IsValidTablaeuMove(Card sourcecard,Card destinationcard)
        {
            if(destinationcard==null)
            {
                return true;
            }
            if(sourcecard.Color!=destinationcard.Color && RankValue[sourcecard.Rank]== RankValue[destinationcard.Rank]-1)
            {
                return true;
            }
            return false;
        }
        public static bool IsValidFoundationMove(Card sourcecard, Stack Foundation)
        {
            if (Foundation.IsEmpty())
            {
                if(RankValue[sourcecard.Rank]==1)
                return true;
                else
                return false;
            }
            if (sourcecard.Color == Foundation.Peek().Color && RankValue[sourcecard.Rank] == RankValue[Foundation.Peek().Rank] + 1)
            {
                return true;
            }
            return false;
        }
        public static bool IsWin()
        {
            if(InitializeGame.HeartsFoundation.GetTotalNumberOfCards()==13&&RankValue[InitializeGame.HeartsFoundation.Peek().Rank]==13&& InitializeGame.DiamondsFoundation.GetTotalNumberOfCards() == 13&&RankValue[InitializeGame.DiamondsFoundation.Peek().Rank] == 13&& InitializeGame.SpadesFoundation.GetTotalNumberOfCards() == 13&&RankValue[InitializeGame.SpadesFoundation.Peek().Rank] == 13&& InitializeGame.ClubsFoundation.GetTotalNumberOfCards() == 13&&RankValue[InitializeGame.ClubsFoundation.Peek().Rank] == 13)
            {
                return true;
            }
            return false;
        }
    }
}
