using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.BaseControllers;
using ArifOmer.BlogApp.UI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArifOmer.BlogApp.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(AreaNames.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IBlogService _blogService;
        public HomeController(UserManager<AppUser> userManager, IBlogService blogService) : base(userManager)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = ActivePage.Homepage;
            ViewBag.TotalBlogCount = await _blogService.GetAllBlogCount();

            return View();
        }
    }
}
