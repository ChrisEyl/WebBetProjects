using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebBet.Datas;

namespace WebBet.ViewComponents
{
    public class TopMatchesViewComponent: ViewComponent
    {
        private readonly WebBetDbContext _webBetDbContext;
        public TopMatchesViewComponent(WebBetDbContext dbContext)
        {
            _webBetDbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("_TopMatches",await _webBetDbContext.Matches.Where(m => !m.Deleted).OrderByDescending(m =>m.Id).Take(5).ToListAsync());
        }
    }
}
