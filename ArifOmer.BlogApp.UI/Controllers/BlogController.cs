using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DTO.DTOs.BlogDtos;
using ArifOmer.BlogApp.DTO.DTOs.CommentDtos;
using ArifOmer.BlogApp.Entities.Concrete;
using ArifOmer.BlogApp.UI.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArifOmer.BlogApp.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper, ICommentService commentService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                ViewBag.ActiveCategory = categoryId;

                return View(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllByCategoryIdAsync((int)categoryId)));
            }

            return View(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTimeAsync()));
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.Comments = _mapper.Map<List<CommentListDto>>(await _commentService.GetAllWithSubCommentsAsync(id, null));


            return View(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }

        public async Task<IActionResult> AddComment(CommentAddDto model)
        {
            model.PostedTime = DateTime.Now;
            await _commentService.AddAsync(_mapper.Map<Comment>(model));

            return RedirectToAction("Detail", new { id = model.BlogId });
        }
    }
}
