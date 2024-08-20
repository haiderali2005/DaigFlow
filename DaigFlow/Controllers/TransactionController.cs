using DaigFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaigFlow.Controllers
{
    public class TransactionController : Controller
    {
        ApplicationDbContext _con;
        public TransactionController(ApplicationDbContext con)
        {
            this._con = con;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var transactions = _con.Transactions
              .Include(t => t.Daig);
                return View(await transactions.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }    
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                List<Daig> daigs = _con.Daigs.ToList();
                ViewData["newdaig"] = daigs;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }   
        }
        [HttpPost]
        public IActionResult Create(Transactions t)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                _con.Transactions.Add(t);
                _con.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }    
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                List<Daig> daigs = _con.Daigs.ToList();
                ViewData["newdaig"] = daigs;
                var data = _con.Transactions.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        [HttpPost]
        public IActionResult Edit(Transactions t)
        {
            _con.Transactions.Update(t);
            _con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _con.Transactions.Include(a => a.Daig).FirstOrDefault(i => i.Id == id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }     
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _con.Transactions.Include(a => a.Daig).FirstOrDefault(i => i.Id == id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }   
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult dlt(int id)
        {
            var data = _con.Transactions.Find(id);
            _con.Transactions.Remove(data);
            _con.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
