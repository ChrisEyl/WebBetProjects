using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBet.Datas;
using WebBet.Models;

namespace WebBet.Controllers
{
    public class UsersController : BaseController
    {
        protected readonly WebBetDbContext _webBetDbContext;

        public UsersController(WebBetDbContext webBetDbContext)
        {
            this._webBetDbContext = webBetDbContext;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (!id.HasValue)
            {
                return View();
            }
            return View(_webBetDbContext.Find<User>(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                model.IdCrypt = Guid.NewGuid();

                // Save State
                _webBetDbContext.Users.Add(model);
                _webBetDbContext.SaveChanges();

                DisplayMessage("Compte crée avec succès", MessageType.OK);

                //return RedirectToAction("Index","Home"); // identique a la route ci dessous
                return RedirectToRoute("home", null);
            }
            DisplayMessage("Erreur", MessageType.ERROR);
            return View(model);
        }
    }
}