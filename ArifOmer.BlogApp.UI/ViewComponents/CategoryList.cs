using System.Collections.Generic;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DTO.DTOs.CategoryDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArifOmer.BlogApp.UI.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryList(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryService.GetAllWithCategoryBlogsAsync().Result);
        }
    }
}
