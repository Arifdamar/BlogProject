using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DTO.DTOs.BlogDtos;
using ArifOmer.BlogApp.DTO.DTOs.CategoryBlogDtos;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.Consts;
using ArifOmer.BlogApp.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;

namespace ArifOmer.BlogApp.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(AreaNames.Admin)]
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;
        private readonly IAppUserService _appUserService;
        private readonly ICategoryService _categoryService;

        public BlogController(IMapper mapper, IBlogService blogService, IAppUserService appUserService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _blogService = blogService;
            _appUserService = appUserService;
            _categoryService = categoryService;
        }

        // GET: BlogController
        public async Task<ActionResult> Index()
        {
            TempData["Active"] = ActivePage.Blog;

            return View(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllAsync()));
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            TempData["Active"] = ActivePage.Blog;

            return View();
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            TempData["Active"] = ActivePage.Blog;

            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BlogAddDto model, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                var allAdminUsers = _appUserService.GetAdminUsers();
                var arif = allAdminUsers.FirstOrDefault(x => x.UserName == "G171210009@sakarya.edu.tr");

                if (arif != null) model.AppUserId = arif.Id;

                if (photo != null)
                {
                    string extension = Path.GetExtension(photo.FileName);
                    string photoName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + photoName);
                    await using var stream = new FileStream(path, FileMode.Create);
                    await photo.CopyToAsync(stream);
                    model.Picture = photoName;
                }

                await _blogService.AddAsync(_mapper.Map<Blog>(model));

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: BlogController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            TempData["Active"] = ActivePage.Blog;

            return View(_mapper.Map<BlogUpdateDto>(await _blogService.FindByIdAsync(id)));
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BlogUpdateDto model, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    string extension = Path.GetExtension(photo.FileName);
                    string photoName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + photoName);
                    await using var stream = new FileStream(path, FileMode.Create);
                    await photo.CopyToAsync(stream);
                    model.ImagePath = photoName;
                }

                await _blogService.UpdateAsync(_mapper.Map<Blog>(model));

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: BlogController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(await _blogService.FindByIdAsync(id));

            return Json(null);
        }

        public async Task<IActionResult> AssignCategory(int id)
        {
            TempData["Active"] = ActivePage.Blog;

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US")),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(10) }
            );

            var categories = await _categoryService.GetAllAsync();
            var blogCategories = await _blogService.GetCategoriesAsync(id);

            TempData["blogId"] = id;

            var list = new List<AssignCategoryModel>();

            foreach (var category in categories)
            {
                var model = new AssignCategoryModel
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name
                };

                foreach (var blogCategory in blogCategories)
                {
                    if (category.Id == blogCategory.Id)
                    {
                        model.Exists = true;
                    }
                }

                list.Add(model);
            }

            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> AssignCategory(List<AssignCategoryModel> list)
        {
            TempData["Active"] = ActivePage.Blog;
            int id = (int)TempData["blogId"];

            foreach (var item in list)
            {
                if (item.Exists)
                {
                    var model = new CategoryBlogDto
                    {
                        BlogId = id,
                        CategoryId = item.CategoryId
                    };

                    await _blogService.AddToCategoryAsync(model);
                }
                else
                {
                    var model = new CategoryBlogDto
                    {
                        BlogId = id,
                        CategoryId = item.CategoryId
                    };

                    await _blogService.RemoveFromCategoryAsync(model);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
