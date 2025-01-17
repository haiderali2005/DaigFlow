﻿using DaigFlow.Models;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;

namespace DaigFlow.Controllers
{
    public class AuthController : Controller
    {
        ApplicationDbContext _con;
        public AuthController(ApplicationDbContext con)
        {
            this._con = con;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User _user)
        {
            _con.table_Users.Add(_user);
            _con.SaveChanges();
            TempData["register"] = "SUCCESSFULLY REGISTERED";
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
                return View();       
        }
        [HttpPost]
        public IActionResult Login(User _user)
        {
            var data = _con.table_Users.Where(user => user.Email == _user.Email && user.Password == _user.Password).FirstOrDefault();

            if (data != null)
            {
                HttpContext.Session.SetString("mysession", data.Email);
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                TempData["login"] = "THIS EMAIL DOESN'T EXIST";
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                HttpContext.Session.Remove("mysession");
                TempData["logout"] = "SUCCESSFULLY LOGOUT";
                return RedirectToAction("login");
            }
            return View();
        }
        public IActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Forgot(User _user, string Password)
        {
            var data = _con.table_Users.Where(user => user.Email == _user.Email).FirstOrDefault();
            if (data != null)
            {
                data.Password = Password;
                _con.SaveChanges();
                TempData["forgot"] = "YOUR PASSWORD HAS BEEN CHANGED";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["forgot2"] = "THIS EMAIL DOESN'T EXIST";
            }
            return View();
        }
    }
}
