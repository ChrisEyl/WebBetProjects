using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBet.Models.Models;

namespace WebBetHome.ServiceProvider.Interfaces
{
    public interface IUserProvider
    {
        /// <summary>
        /// Get an user by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserByIndex(int id);
    }
}
