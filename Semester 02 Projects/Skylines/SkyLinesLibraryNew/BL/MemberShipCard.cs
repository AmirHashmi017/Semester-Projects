using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLinesLibrary
{
    public class MemberShipCard
    {
        protected string CardNumber;
        protected string MemberName;
        protected string MemberShipTier;
        protected DateTime IssuedDate;

        public MemberShipCard(string Number, string Name, string Tier)
        {
            this.CardNumber = Number;
            this.MemberName = Name;
            this.MemberShipTier = Tier;
            this.IssuedDate = DateTime.Now;
        }
       

        //This method is used check Whether a card is expired or not and it is virtual because here is polymorphism and this function can be different in child classes.
        public virtual bool IsExpired()
        {
            if (DateTime.Now > IssuedDate)
            {
                return true;
            }
            return false;
        }
        public virtual string GetCardInfo()
        {
            return $"{CardNumber}\t\t\t{MemberName}\t\t\t{MemberShipTier}\t\t\t{IssuedDate}";
        }

        public string GetCardNumber()
        {
            return CardNumber;
        }

        public string GetMemberName()
        {
            return MemberName;
        }

        public string GetMemberShipTier()
        {
            return MemberShipTier;
        }

        public void SetCardNumber(string Number)
        {
            this.CardNumber = Number;
        }

        public void SetMemberName(string Name)
        {
            this.MemberName = Name;
        }

        public void SetMemberShipTier(string Tier)
        {
            this.MemberShipTier = Tier;
        }
    }
}
