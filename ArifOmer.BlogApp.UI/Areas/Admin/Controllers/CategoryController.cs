using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DTO.DTOs.CategoryDtos;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArifOmer.BlogApp.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(AreaNames.Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"]= ActivePage.Category;

            return View(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllAsync()));
        }

        public IActionResult Create()
        {
            TempData["active"] = ActivePage.Category;

            return View(new CategoryAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddDto model)
        {

            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(_mapper.Map<Category>(model));

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            TempData["active"] = ActivePage.Category;

            var categoryList = await _categoryService.FindByIdAsync(id);

            return View(new CategoryUpdateDto
            {
                Id = categoryList.Id,
                Name = categoryList.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto model)
        {
            TempData["active"] = ActivePage.Category;

            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(_mapper.Map<Category>(model));

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            TempData["active"] = ActivePage.Category;

            await _categoryService.RemoveAsync(new Category() {Id = id});

            return RedirectToAction("Index");
        }

        public IActionResult SignOut(){
            HttpContext.Session.Remove("token");
            return RedirectToAction("Index","Home",new {area=""});
        }
    }
}