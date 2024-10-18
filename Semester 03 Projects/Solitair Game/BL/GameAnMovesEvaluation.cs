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
            if(sourcecard.Color!=destinationcard.Color && RankValue[sourcecard.Rank]== RankValue[destinationcard.Rank]-1)
            {
                return true;
            }
            return false;
        }
    }
}
