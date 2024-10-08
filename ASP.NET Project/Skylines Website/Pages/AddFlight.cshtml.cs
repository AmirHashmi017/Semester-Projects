using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyLines_Website;
using SkyLinesLibrary;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Skylines_Website.Pages
{
    public class AddFlightModel : PageModel
    {
        [BindProperty]
        public List<Flight> Flights { get; set; }
        [BindProperty]
        public string FlightID { get; set; }
        [BindProperty]
        public string FlightName { get; set; }
        [BindProperty]
        public string Departure { get; set; }
        [BindProperty]
        public string Arrival{ get; set; }
        [BindProperty]
        public DateOnly TravelDate { get; set; }
        [BindProperty]
        public TimeOnly TakeoffTime { get; set; }
        [BindProperty]
        public int Seats { get; set; }

        [BindProperty]
        public int Price { get; set; }
        public void OnGet()
        {
            Flights = ObjectHandler.GetFlightDL().GetAllFlights();
        }
        public IActionResult OnPost()
        {
            if (ObjectHandler.GetFlightDL().CheckValidFlightID(FlightID))
            {
                string traveldate = TravelDate.ToString();
                string takeofftime = TakeoffTime.ToString();
                Flight f = new Flight(FlightID, FlightName, Departure, Arrival, traveldate, takeofftime, Price, Seats);
                ObjectHandler.GetFlightDL().AddFlight(f);
                TempData["ErrorMessage"]="Flight Added Successfully";
                Flights = ObjectHandler.GetFlightDL().GetAllFlights();
                return RedirectToPage();
            }
            TempData["ErrorMessage"] = "Flight ID already exists";
            Flights = ObjectHandler.GetFlightDL().GetAllFlights();
            return RedirectToPage();
        }
    }
}
