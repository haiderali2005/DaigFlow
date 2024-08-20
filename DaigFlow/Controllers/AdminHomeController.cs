using Microsoft.AspNetCore.Mvc;

namespace DaigFlow.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
           
        }
    }
}
