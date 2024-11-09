using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    //GameState class for storing current state of game for undo/redo.
    public class GameState
    {
        public List<Stack> Tableaus;
        public Queue StockPile;
        public Stack WastePile;
        public  Stack HeartsFoundation;
        public  Stack DiamondsFoundation;
        public  Stack ClubsFoundation;
        public  Stack SpadesFoundation;
        public GameState(List<Stack> tableaus,
        Queue stockPile,
        Stack wastePile,
        Stack heartsFoundation,
        Stack diamondsFoundation,
        Stack clubsFoundation,
        Stack spadesFoundation)
        {
            this.Tableaus = tableaus.Select(tableau => tableau.DeepCopy()).ToList();
            this.StockPile = stockPile.DeepCopy();
            this.WastePile = wastePile.DeepCopy();
            this.HeartsFoundation = heartsFoundation.DeepCopy();
            this.DiamondsFoundation = diamondsFoundation.DeepCopy();
            this.ClubsFoundation = clubsFoundation.DeepCopy();
            this.SpadesFoundation = spadesFoundation.DeepCopy();
        }
    }
}
