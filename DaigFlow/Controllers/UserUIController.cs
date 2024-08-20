using DaigFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaigFlow.Controllers
{
    public class UserUIController : Controller
    {
        ApplicationDbContext _con;
        public UserUIController(ApplicationDbContext _context)
        {
            this._con = _context;
        }
        public IActionResult Index()
        {
                List<Daig> daigs = _con.Daigs.ToList();
                ViewData["newdaig"] = daigs;
                return View();
        }
       public IActionResult Tran()
        {
            if (HttpContext.Session.GetString("mysessionfrontend") != null)
            {
                List<Daig> daigs = _con.Daigs.ToList();
                ViewData["_daig"] = daigs;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AuthUI");
            }     
        }
        [HttpPost]
        public IActionResult Tran(Transactions t)
        {
            _con.Transactions.Add(t);
            _con.SaveChanges();
            TempData["tran"] = "SUCCESSFULLY SUBMITTED";
            return RedirectToAction("Index", "UserUI");
        }
    }
}
