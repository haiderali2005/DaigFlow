using DaigFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaigFlow.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext con;
        public UserController(ApplicationDbContext _Con)
        {
            this.con = _Con;
        }
        public IActionResult Index()
        {
            var data=con.table_Users.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User u)
        {
            con.table_Users.Add(u);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var data = con.table_Users.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(User u)
        {
            con.table_Users.Update(u);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = con.table_Users.Where(a => a.UserId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult dlt(int id)
        {
            var data = con.table_Users.Find(id);
            con.table_Users.Remove(data);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = con.table_Users.Where(a => a.UserId == id).FirstOrDefault();
            return View(data);
        }
    }
}
