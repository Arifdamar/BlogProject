using System.Threading.Tasks;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.BaseControllers;
using ArifOmer.BlogApp.UI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArifOmer.BlogApp.UI.Areas.Member.Controllers
{
    [Authorize(Roles = Roles.Member)]
    [Area(AreaNames.Member)]
    public class HomeController : BaseIdentityController
    {

        public HomeController(UserManager<AppUser> userManager) : base(userManager)
        {

        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = ActivePage.Homepage;
            var user = await GetCurrentUser();

            return View();
        }
    }
}
