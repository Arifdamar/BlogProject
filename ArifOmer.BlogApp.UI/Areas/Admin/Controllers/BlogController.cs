﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DTO.DTOs.BlogDtos;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ArifOmer.BlogApp.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area(AreaNames.Admin)]
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;
        private readonly IAppUserService _appUserService;

        public BlogController(IMapper mapper, IBlogService blogService, IAppUserService appUserService)
        {
            _mapper = mapper;
            _blogService = blogService;
            _appUserService = appUserService;
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
                    model.ImagePath = photoName;
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
        
    }
}
