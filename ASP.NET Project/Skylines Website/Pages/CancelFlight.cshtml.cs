using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyLines_Website;
using SkyLinesLibrary;

namespace Skylines_Website.Pages
{
    public class CancelFlightModel : PageModel
    {
        [BindProperty]
        public List<Flight> Flights { get; set; }
        [BindProperty]
        public string FlightID { get; set; }
        public void OnGet()
        {
            int Index = HttpContext.Session.GetInt32("UserIndex").Value;
            List<Client> clients = ObjectHandler.GetClientDL().GetAllClients();
            Flights = clients[Index].GetBookedFlights();
        }
        public IActionResult OnPost()
        {
            List<Client> Clients = ObjectHandler.GetClientDL().GetAllClients();
            int Index = HttpContext.Session.GetInt32("UserIndex").Value;
            Flight f = Clients[Index].CancelFlight(FlightID);
            if (f != null)
            {
                ObjectHandler.GetFlightDL().EditFlight(f.GetFlightName(), f.GetFlightID(), f.GetSource(), f.GetDestination(), f.GetTravelDate(), f.GetTakeoffTime(), f.GetPrice(), f.GetSeats());
                ObjectHandler.GetClientDL().DeleteBookedFlights(FlightID, Clients[Index].GetName());

                TempData["ErrorMessage"] = "Flight is successfully Cancelled.";
                return RedirectToPage("CancelFlight");
            }
            else
            {
                TempData["ErrorMessage"] = "No such booking you have";
                return RedirectToPage("CancelFlight");
            }
            return Page();

        }
    }
}
