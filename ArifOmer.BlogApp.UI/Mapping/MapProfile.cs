using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArifOmer.BlogApp.DTO.DTOs.AppUserDtos;
using ArifOmer.BlogApp.DTO.DTOs.BlogDtos;
using ArifOmer.BlogApp.DTO.DTOs.CategoryDtos;
using ArifOmer.BlogApp.DTO.DTOs.CommentDtos;
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

            #region Blog-BlogDto

            CreateMap<Blog, BlogListDto>();
            CreateMap<BlogListDto, Blog>();

            CreateMap<Blog, BlogAddDto>();
            CreateMap<BlogAddDto, Blog>();

            CreateMap<Blog, BlogUpdateDto>();
            CreateMap<BlogUpdateDto, Blog>();

            #endregion

            #region Category-CategoryDto

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            #endregion

            #region Category-CategoryDto

            CreateMap<Comment, CommentListDto>();
            CreateMap<CommentListDto, Comment>();

            CreateMap<Comment, CommentAddDto>();
            CreateMap<CommentAddDto, Comment>();

            #endregion


            CreateMap<Comment, CommentListDto>();
            CreateMap<CommentListDto, Comment>();

            CreateMap<Comment, CommentAddDto>();
            CreateMap<CommentAddDto, Comment>();
        }
    }
}
