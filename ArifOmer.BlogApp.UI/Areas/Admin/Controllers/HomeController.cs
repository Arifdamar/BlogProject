using System.Threading.Tasks;
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

        public HomeController(UserManager<AppUser> userManager) : base(userManager)
        {

        }

        public async Task<IActionResult> Index()
        {
            //TempData["Active"] = ActivePage.Homepage;
            //var user = await GetCurrentUser();
            //ViewBag.UnassignedTaskCount = _taskService.GetUnassignedTaskCount();
            //ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCount();
            //ViewBag.UnreadNotificationCount = _notificationService.GetUnreadNotificationCountByUserId(user.Id);
            //ViewBag.TotalReportCount = _reportService.GetTotalReportCount();

            return View();
        }
    }
}
