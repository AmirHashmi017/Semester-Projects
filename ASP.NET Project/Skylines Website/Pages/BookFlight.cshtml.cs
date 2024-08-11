using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyLines_Website;
using SkyLinesLibrary;
namespace Skylines_Website.Pages
{
    public class BookFlightModel : PageModel
    {
        [BindProperty]
        public List<Flight>Flights { get; set; }
        [BindProperty]
        public string FlightID { get; set; }  
        public void OnGet()
        {
            Flights =ObjectHandler.GetFlightDL().GetAllFlights();
        }
        public IActionResult OnPost()
        {
            Flight f=ObjectHandler.GetFlightDL().GetFlightByID(FlightID);
            if(f==null)
            {
                TempData["ErrorMessage"] = "No Such Flight Exist.";
                return RedirectToPage("BookFlight");
            }
            else
            {
                List<Client>Clients=ObjectHandler.GetClientDL().GetAllClients();
                int Index = HttpContext.Session.GetInt32("UserIndex").Value;
                if (Clients[Index].BookFlight(f))
                {
                    ObjectHandler.GetFlightDL().EditFlight(f.GetFlightName(), f.GetFlightID(), f.GetSource(), f.GetDestination(), f.GetTravelDate(), f.GetTakeoffTime(), f.GetPrice(), f.GetSeats());
                    ObjectHandler.GetClientDL().StoreBookedFlights(f.GetFlightID(), Clients[Index].GetName());
                    TempData["ErrorMessage"]="Flight is successfully Booked.";
                    return RedirectToPage("BookFlight");
                }
                else
                {
                    TempData["ErrorMessage"]="Flight is already Booked.";
                    return RedirectToPage("BookFlight");
                }
            }
            return Page();
            
        }
    }
}
