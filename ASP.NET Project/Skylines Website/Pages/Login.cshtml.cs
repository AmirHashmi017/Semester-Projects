using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkyLines_Website;
using SkyLinesLibrary;
using System.Xml.Linq;
namespace Skylines_Website.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Role { get; set; }
        public void OnGet()
        {
            HttpContext.Session.Remove("UserIndex");
        }
        public IActionResult OnPostSignIn()
        {
            string result = "";
                if (ObjectHandler.GetClientDL().IsClientExist(Name, Password))
                {
                    int Index = ObjectHandler.GetClientDL().FindClient(Name, Password);
                HttpContext.Session.SetInt32("UserIndex", Index);
                    result = "User";
                return RedirectToPage("SearchFlight");

            }
                else if (ObjectHandler.GetAdminDL().IsAdminExist(Name, Password))
                {
                    result = "admin";
                return RedirectToPage("AddFlight");

            }
                if (result != "")
                { 
                return Page();
            }
            TempData["SuccessMessage"] = "You Don't have an account please Sign Up!";
            return Page();
        }
        public IActionResult OnPostSignUp()
        {
            if (ObjectHandler.GetAdminDL().CheckValidAdminName(Name) && ObjectHandler.GetClientDL().CheckValidClientName(Name))
            {
                    if (Role.ToLower() == "admin" || Role.ToLower() == "user")
                    {
                        if (Role.ToLower() == "admin")
                        {
                            Admin newAdmin = new Admin(Name, Password, Role);
                            ObjectHandler.GetAdminDL().AddAdmin(newAdmin);
                        TempData["SuccessMessage"] = "Successfully signed Up as an Admin!";
                        return Page();
                    }
                        if (Role.ToLower() == "user")
                        {
                            Client newClient = new Client(Name, Password, Role);
                            ObjectHandler.GetClientDL().AddClient(newClient);
                        TempData["SuccessMessage"] = "Successfully signed Up as User!";
                        return Page();
                    }


                    TempData["RedirectUrl"] = Url.Page("AddFlight");
                   
                }


                TempData["SuccessMessage"] = "Invalid Role!";
                return Page();
            }
            TempData["SuccessMessage"] = "Invalid Username.This Username already exists.";
            return Page();
        }
    }
}
