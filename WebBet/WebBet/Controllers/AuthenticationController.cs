using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebBet.Datas;
using WebBet.Models;

namespace WebBet.Controllers
{
    public class AuthenticationController : BaseController
    {
        protected readonly WebBetDbContext _webBetDbContext;
        public AuthenticationController(
            WebBetDbContext webBetDbContext)
        {
            this._webBetDbContext = webBetDbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AuthenticationLoginViewModel model)
        {
            User user = _webBetDbContext.Users.SingleOrDefault(u => u.Email == model.Login && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(user));
                return RedirectToAction("Index", "Bets");
            }

            DisplayMessage("Login / mot de passe incorrect", MessageType.ERROR);
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            if (HttpContext.Session.Keys.Contains("USER"))
            {
                var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("USER"));
                @ViewBag.Personne = user.Name + " " + user.FirstName;
                HttpContext.Session.Remove("USER");
            }
            return View();
        }
    }
}