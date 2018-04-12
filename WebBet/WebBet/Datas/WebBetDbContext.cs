using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBet.Models;

namespace WebBet.Datas
{
    public class WebBetDbContext: DbContext
    {
        #region Constructeur

        public WebBetDbContext(DbContextOptions<WebBetDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        } 

        #endregion

        #region Models

        public DbSet<User> Users { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Bet> Bets { get; set; }

        #endregion
    }
}
