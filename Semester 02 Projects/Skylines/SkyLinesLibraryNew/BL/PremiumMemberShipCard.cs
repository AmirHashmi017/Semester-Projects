using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLinesLibrary
{
    public class PremiumMemberShipCard : MemberShipCard
    {
        private TimeSpan MemberShipDuration;
        private double MemberShipPrice;
        private double MonthlyProfit;

        public PremiumMemberShipCard(string Number, string Name, string Tier) : base(Number, Name, Tier)
        {
            MemberShipDuration = TimeSpan.FromDays(730);
            MemberShipPrice = 100000;
            MonthlyProfit = 7000;
        }
        //This method checks whether the card is expired or not and it is definition of an abstract method of parent class.
        public  override bool IsExpired()
        {
            DateTime expiryDate = IssuedDate.Add(MemberShipDuration);
            if (DateTime.Now > expiryDate)
            {
                return true;
            }
            return false;
        }
        //This method returnstheinformation of membership card and it is overriding a method of parent class.
        public override string GetCardInfo()
        {
            string CardInfo = base.GetCardInfo();
            CardInfo += $"\t\t\t{MemberShipDuration}\t\t\t{MemberShipPrice}\t\t\t{MonthlyProfit}";
            return CardInfo;
        }
    }
}
