using DaigFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaigFlow.Controllers
{
    public class DaigController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _webHostEnvironment;
        public DaigController(ApplicationDbContext con,IWebHostEnvironment env)
        {
            this._context = con;
            this._webHostEnvironment = env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _context.Daigs.ToList();
                return View(data);
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
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        [HttpPost]
        public IActionResult Create(IFormFile ImagePath,Daig _daig)
        {
            string filename = Path.GetFileName(ImagePath.FileName);
            string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "daigpics", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            ImagePath.CopyTo(fs);
            _daig.ImagePath = filename;
            _context.Daigs.Add(_daig);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _context.Daigs.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }     
        }
        [HttpPost]
        public IActionResult Edit(Daig _daig,IFormFile ImagePath)
        {
            string filename = Path.GetFileName(ImagePath.FileName);
            string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "daigpics", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            ImagePath.CopyTo(fs);
            _daig.ImagePath = filename;
            _context.Daigs.Update(_daig);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _context.Daigs.Where(a => a.DaigId == id).FirstOrDefault();
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
                var data = _context.Daigs.Where(a => a.DaigId == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
           
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Delete2(int id)
        {
            var data = _context.Daigs.Find(id);
            _context.Daigs.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
