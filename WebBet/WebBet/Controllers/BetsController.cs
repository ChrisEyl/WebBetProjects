using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebBet.Datas;
using WebBet.Filters;
using WebBet.Models;

namespace WebBet.Controllers
{
    [AuthenticationFilter]
    public class BetsController : BaseController
    {
        protected readonly WebBetDbContext _webBetDbContext;

        public BetsController(WebBetDbContext webBetDbContext)
        {
            this._webBetDbContext = webBetDbContext;
        }

        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("USER"));
            return View(_webBetDbContext.Bets.Where(b => b.UserId == user.Id).ToList());
        }
    }
}