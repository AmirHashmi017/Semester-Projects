using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyLines_Website;
using SkyLinesLibrary;

namespace Skylines_Website.Pages
{
    public class SearchFlightModel : PageModel
    {
        [BindProperty]
        public List<Flight> Flights { get; set; }
        [BindProperty]
        public string Departure { get; set; }
        [BindProperty]
        public string Arrival { get; set; }
        public void OnGet()
        {
            Flights = ObjectHandler.GetFlightDL().GetAllFlights();
        }
        public IActionResult OnPost()
        {

            List<Flight> flights = ObjectHandler.GetFlightDL().GetAllFlights();
            List<Flight> searched = new List<Flight>();
            foreach (Flight fl in flights)
            {
                if (fl.GetSource() == Departure && fl.GetDestination() == Arrival && fl.GetSeats() > 0)
                {
                    searched.Add(fl);
                }
            }
            Flights = searched;
            return Page();
        }
    }
}
