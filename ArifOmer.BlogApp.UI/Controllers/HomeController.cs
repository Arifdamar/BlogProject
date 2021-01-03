using ArifOmer.BlogApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DTO.DTOs.AppUserDtos;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

namespace ArifOmer.BlogApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBlogService _blogService;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IBlogService blogService, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _blogService = blogService;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Deneme = _localizer["Deneme"];
            return View(await _blogService.GetAllSortedByPostedTimeAsync());
        }

        public IActionResult SignIn()
        {
            return View(new AppUserSignInDto());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                    if (identityResult.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);

                        if (userRoles.Contains(AreaNames.Admin))
                        {
                            return RedirectToAction("Index", "Home", new { area = AreaNames.Admin });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = AreaNames.Member });
                        }
                    }
                }

                ModelState.AddModelError("", Messages.LoginError);
            }

            return View("Index", model);
        }

        public IActionResult Register()
        {
            return View(new AppUserAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, Roles.Member);

                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    AddErrorRange(addRoleResult.Errors);
                }

                AddErrorRange(result.Errors);
            }

            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = Messages.PageNotFound;
            }

            return View();
        }

        public IActionResult ChangeLanguage(string returnUrl)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            if (culture.Name == "en-US")
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("tr")),
                    new CookieOptions { Expires = DateTimeOffset.Now.AddDays(10) }
                );
            }
            else
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US")),
                    new CookieOptions { Expires = DateTimeOffset.Now.AddDays(10) }
                );
            }

            return Redirect(returnUrl);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        protected void AddErrorRange(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
