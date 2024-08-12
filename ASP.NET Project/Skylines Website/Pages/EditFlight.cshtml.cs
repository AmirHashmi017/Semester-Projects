using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyLines_Website;
using SkyLinesLibrary;

namespace Skylines_Website.Pages
{
    public class EditFlightModel : PageModel
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
        public string Arrival { get; set; }
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
            string tdate = TravelDate.ToString();
            string takeoff = TakeoffTime.ToString();
            ObjectHandler.GetFlightDL().EditFlight(FlightName, FlightID, Departure, Arrival, tdate, takeoff, Price, Seats);
            TempData["ErrorMessage"] = "Flight Edited Successfully";
            return RedirectToPage();
        }
    }
}
