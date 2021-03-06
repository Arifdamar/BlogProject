﻿using System;
using ArifOmer.BlogApp.DTO.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.DTO.DTOs.BlogDtos
{
    public class BlogListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
