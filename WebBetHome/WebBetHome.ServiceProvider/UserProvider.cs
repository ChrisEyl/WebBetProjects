using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBet.Models.Models;
using WebBetHome.ServiceProvider.Interfaces;

namespace WebBetHome.ServiceProvider
{
    public class UserProvider : IUserProvider
    {
        Task<User> IUserProvider.GetUserByIndex(int id)
        {
            return Task.Run(() => new User()
            {
                Id = id,
                Name = "Eyler",
                FirstName = "Erwann"
            });
        }
    }
}
