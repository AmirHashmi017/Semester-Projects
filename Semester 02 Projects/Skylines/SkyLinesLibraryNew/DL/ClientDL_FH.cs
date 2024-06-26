using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace SkyLinesLibrary
{
    public class ClientDL_FH : IClientDL
    {
        
        public static List<Client> Clients = new List<Client>();

        
        private static ClientDL_FH ClientDL_FHInstance;

        
        private static string filepath;

        
        private ClientDL_FH(string FilePath)
        {
            filepath = FilePath; 
            LoadClients(); 
        }

       
        public static ClientDL_FH GetClientDL_FHInstance(string FilePath)
        {
            if (ClientDL_FHInstance == null)
            {
                ClientDL_FHInstance = new ClientDL_FH(FilePath); 
            }
            return ClientDL_FHInstance;
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

        // Method to load clients from the file
        public void LoadClients()
        {
            string record;
            string name, password, role, feedback;
            if (File.Exists(filepath))
            {
                StreamReader Clientfile = new StreamReader(filepath);
                while ((record = Clientfile.ReadLine()) != null)
                {
                    string[] splittedrecord = record.Split(',');
                    name = splittedrecord[0];
                    password = splittedrecord[1];
                    role = splittedrecord[2];
                    feedback = splittedrecord[3];
                    Client cl = new Client(name, password, role);
                    Clients.Add(cl); 
                    cl.SetFeedBack(feedback); 
                    string splittedflights = splittedrecord[4];
                    cl.SetBookedFlights(ReturnReservedFlights(splittedflights)); 
                }
                Clientfile.Close();
            }
            else
            {
                Console.Write("File Not Found");
            }
        }

        // Method to store clients in the file
        public void StoreClients(Client cl)
        {
            StreamWriter Clientfile = new StreamWriter(filepath, true);
            Clientfile.Write($"{cl.GetName()},{cl.GetPassword()},{cl.GetRole()},{cl.GetFeedBack()},");
            List<Flight> flights = cl.GetBookedFlights();
            for (int i = 0; i < flights.Count; i++)
            {
                Clientfile.Write(flights[i].GetFlightID());
                if (i == flights.Count - 1)
                    Clientfile.Write("\n");
                else
                    Clientfile.Write(";");
            }
            Clientfile.Flush();
            Clientfile.Close();
        }

        // Method to update client feedback
        public void UpdateFeedBack(string Name, string feedback)
        {
            File.WriteAllText(filepath, string.Empty); 
            foreach (Client cl in Clients)
            {
                StoreClients(cl); 
            }
        }

        // Method to get all clients
        public List<Client> GetAllClients()
        {
            return Clients; 
        }
public void StoreMemberShipCard(MemberShipCard Card)
{
}
        // Method to return reserved flights for a client
        public List<Flight> ReturnReservedFlights(string ClientName)
        {
            List<Flight> reservedflights = new List<Flight>();
            string FlightID;
            string[] splittedflights = ClientName.Split(';');
            for (int i = 0; i < splittedflights.Length; i++)
            {
                FlightID = splittedflights[i];
                for (int x = 0; x < FlightDL_FH.Flights.Count; x++)
                {
                    if (FlightID == FlightDL_FH.Flights[x].GetFlightID())
                    {
                        Flight fl = FlightDL_FH.Flights[x];
                        reservedflights.Add(fl); 
                    }
                }
            }
            return reservedflights;
        }

        // Method to store booked flights for a client
        public void StoreBookedFlights(string FlightID, string Name)
        {
            string clfilepath = filepath;
            File.WriteAllText(clfilepath, string.Empty); 
            foreach (Client cl in ClientDL_FH.Clients)
            {
                StoreClients(cl); 
            }
        }

        // Method to delete booked flights for a client
        public void DeleteBookedFlights(string flightID, string Name)
        {
            string clfilepath = filepath;
            File.WriteAllText(clfilepath, string.Empty);
            foreach (Client cl in ClientDL_FH.Clients)
            {
                StoreClients(cl); 
            }
        }
    }
}
