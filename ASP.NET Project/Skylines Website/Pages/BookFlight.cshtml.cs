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
        public void OnGet()
        {
            Flights=ObjectHandler.GetFlightDL().GetAllFlights();
        }
    }
}
