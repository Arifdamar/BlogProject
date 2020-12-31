using ArifOmer.BlogApp.DTO.DTOs.AppUserDtos;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.Consts;
using ArifOmer.BlogApp.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable AsyncConverter.AsyncWait

namespace ArifOmer.BlogApp.UI.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            var model = _mapper.Map<AppUserListDto>(user);
            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains(Roles.Admin))
            {
                return View(model);
            }

            return View("Member", model);
        }
    }
}
