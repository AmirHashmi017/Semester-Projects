using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SkyLinesLibrary
{
    public class ClientDL_DB : IClientDL
    {
        
        public static List<Client> Clients = new List<Client>();

        
        private static DbConfig db = DbConfig.GetInstance();

        
        private static ClientDL_DB ClientDL_DBInstance;

        
        private ClientDL_DB(string connectionstring)
        {
            LoadClients(); 
        }

        
        public static ClientDL_DB GetClientDL_DBInstance(string connectionstring)
        {
            if (ClientDL_DBInstance == null)
            {
                ClientDL_DBInstance = new ClientDL_DB(connectionstring); 
            }
            return ClientDL_DBInstance; 
        }

        // Method to add a client
        public void AddClient(Client client)
        {
            Clients.Add(client); 
            StoreClients(client); 
        }

        // Method to check if a client exists
        public bool IsClientExist(string name, string password)
        {
           
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].GetName() == name && Clients[i].GetPassword() == password)
                {
                    return true; 
                }
            }
            return false; 
        }

        // Method to find the index of a client
        public int FindClient(string name, string password)
        {
            int ClientNo = 10000; 
            
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].GetName() == name && Clients[i].GetPassword() == password)
                {
                    ClientNo = i; 
                    return ClientNo;
                }
            }
            return ClientNo; 
        }

        // Method to check if client name is valid
        public bool CheckValidClientName(string name)
        {
            
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].GetName() == name)
                {
                    return false; 
                }
            }
            return true; 
        }

        // Method to load clients from the database
        public void LoadClients()
        {
            string name, password, role;
            string searchquery = "Select * From Clients";
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i]["ClientName"].ToString();
                password = dt.Rows[i]["ClientPassword"].ToString();
                role = dt.Rows[i]["Role"].ToString();
                Client cl = new Client(name, password, role);
                cl.SetBookedFlights(ReturnReservedFlights(name));

                string feedback = dt.Rows[i]["FeedBack"].ToString();
                cl.SetFeedBack(feedback);
cl.AddMemberShipCard(ReturnMemberShipCard(name));
                Clients.Add(cl); 
            }
        }

        // Method to store clients in the database
        public void StoreClients(Client cl)
        {
            string query = string.Format("INSERT INTO Clients(ClientName,ClientPassword,Role,FeedBack)" + "Values ('{0}','{1}','{2}','{3}')", cl.GetName(), cl.GetPassword(), cl.GetRole(), cl.GetFeedBack());
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }

        // Method to update client feedback
        public void UpdateFeedBack(string Name, string feedback)
        {
            string query = string.Format("UPDATE Clients SET FeedBack='{0}'WHERE ClientName='{1}'", feedback, Name);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }

        // Method to get all clients
        public List<Client> GetAllClients()
        {
            return Clients; 
        }
//Method to store MemberShipCard
public void StoreMemberShipCard(MemberShipCard Card)
{
string query = string.Format("INSERT INTO MemberShipCard(CardNumber,MemberName,MemberShipTier)" + "Values ('{0}','{1}','{2}')", Card.GetCardNumber(), Card.GetMemberName(), Card.GetMemberShipTier());
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
}
//Method to return MemverShipCard
public MemberShipCard ReturnMemberShipCard(string ClientName)
        {
            string CardNumber="";string MemberName = ""; string MemberShipTier="";
            string searchquery = String.Format("Select * From MemberShipCard Where MemberName='{0}'", ClientName);
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            MemberShipCard Card;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CardNumber = reader.GetString(0);
               MemberName=reader.GetString(1);
	MemberShipTier=reader.GetString(2);
            }
            reader.Close();
	Card=new MemberShipCard(CardNumber,MemberName,MemberShipTier);
            return Card; 
        }
        // Method to return reserved flights for a client
        public List<Flight> ReturnReservedFlights(string ClientName)
        {
            string FlightID;
            string searchquery = String.Format("Select * From ReservedFlights Where ClientName='{0}'", ClientName);
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            List<Flight> reservedflights = new List<Flight>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                FlightID = reader.GetString(0);
                for (int i = 0; i < FlightDL_DB.Flights.Count; i++)
                {
                    if (FlightDL_DB.Flights[i].GetFlightID() == FlightID)
                    {
                        reservedflights.Add(FlightDL_DB.Flights[i]); 
                    }
                }
            }
            reader.Close();
            return reservedflights; 
        }

        // Method to store booked flights for a client
        public void StoreBookedFlights(string FlightID, string Name)
        {
            string query = string.Format("INSERT INTO ReservedFlights(FlightID,ClientName)" + "Values ('{0}','{1}')", FlightID, Name);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }

        // Method to delete booked flights for a client
        public void DeleteBookedFlights(string flightID, string Name)
        {
            string query = string.Format("DELETE FROM ReservedFlights WHERE FlightID='{0}' AND ClientName='{1}'", flightID, Name);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }
    }
}
