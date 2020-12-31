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
using Microsoft.AspNetCore.Identity;

namespace ArifOmer.BlogApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBlogService _blogService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IBlogService blogService)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
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
