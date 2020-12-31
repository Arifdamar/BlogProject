using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArifOmer.BlogApp.DTO.DTOs.AppUserDtos;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.Models;
using AutoMapper;

namespace ArifOmer.BlogApp.UI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            #region AppUser-AppUserDto

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();

            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();

            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();

            #endregion
        }
    }
}
