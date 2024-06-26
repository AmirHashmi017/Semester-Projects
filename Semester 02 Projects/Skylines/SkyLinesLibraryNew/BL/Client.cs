using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkyLinesLibrary
{
    // This 'Client' Class is a Child Class which is inheriting 'Person' class.
    public class Client : Person
    {
        private string FeedBack; 
        private List<Flight> BookedFlights; 
private MemberShipCard MemberCard;
        
        public Client(string name, string password, string role) : base(name, password, role)
        {
            BookedFlights = new List<Flight>(); 
        }

        // Method to submit feedback
        public void SubmitFeedBack(string feedback)
        {
            this.FeedBack = feedback; 
        }

        // Method to view feedback
        public string ViewFeedBack()
        {
            return ($" FeedBack By {Name}:  {FeedBack}");
        }

        // Method to book a flight
        public bool BookFlight(Flight f)
        {
            for (int i = 0; i < BookedFlights.Count; i++)
            {
                if (BookedFlights[i].GetFlightID() == f.GetFlightID())
                {
                    return false;
                }
            }
            double Seats = f.GetSeats() - 1; 
            f.SetSeats(Seats); 
            BookedFlights.Add(f); 
            return true; 
        }

        // Method to cancel a booked flight
        public Flight CancelFlight(string ID)
        {
            for (int i = 0; i < BookedFlights.Count; i++)
            {
                if (BookedFlights[i].GetFlightID() == ID)
                {
                    double Seats = BookedFlights[i].GetSeats() + 1; 
                    BookedFlights[i].SetSeats(Seats); 
                    Flight f = BookedFlights[i]; 
                    BookedFlights.RemoveAt(i); 
                    return f; 
                }
            }
            return null; 
        }
//Method to add MemberShip Card
public void AddMemberShipCard(MemberShipCard Card)
{
if(Card.GetMemberShipTier().ToLower()=="premium")
{MemberCard=new PremiumMemberShipCard(Card.GetCardNumber(),this.Name,Card.GetMemberShipTier());}
else if(Card.GetMemberShipTier().ToLower()=="gold")
{MemberCard=new GoldMemberShipCard(Card.GetCardNumber(),this.Name,Card.GetMemberShipTier());}
else if(Card.GetMemberShipTier().ToLower()=="silver")
{MemberCard=new SilverMemberShipCard(Card.GetCardNumber(),this.Name,Card.GetMemberShipTier());}
            
}
        // Method to get the feedback
        public string GetFeedBack()
        {
            return FeedBack; 
        }

        // Method to set the feedback
        public void SetFeedBack(string FeedBack)
        {
            this.FeedBack = FeedBack; 
        }

        // Method to get the list of booked flights
        public List<Flight> GetBookedFlights()
        {
            return BookedFlights; 
        }

        // Method to set the list of booked flights
        public void SetBookedFlights(List<Flight> BookedFlights)
        {
            this.BookedFlights = BookedFlights; 
        }
//Method to get card.
public MemberShipCard GetCard()
        {
            return this.MemberCard;
        }
    }
}
