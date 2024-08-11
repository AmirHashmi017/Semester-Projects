using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyLines_Website;
using SkyLinesLibrary;

namespace Skylines_Website.Pages
{
    public class ViewReservedFlightsModel : PageModel
    {
        [BindProperty]
        public List<Flight> Flights { get; set; }
        public void OnGet()
        {
            int Index = HttpContext.Session.GetInt32("UserIndex").Value;
            List<Client> clients = ObjectHandler.GetClientDL().GetAllClients();
            Flights = clients[Index].GetBookedFlights();
        }
    }
}
