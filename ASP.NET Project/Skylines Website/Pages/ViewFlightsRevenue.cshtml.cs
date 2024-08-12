using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyLines_Website;
using SkyLinesLibrary;
using System.Security.Cryptography.X509Certificates;

namespace Skylines_Website.Pages
{
    public class ViewFlightsRevenueModel : PageModel
    {
        [BindProperty]
        public List<Flight>Flights { get; set; }
        public void OnGet()
        {
           
            Flights=ObjectHandler.GetFlightDL().GetAllFlights();
            
        }
        
    }
}
