﻿using ArifOmer.BlogApp.DTO.Abstract;

namespace ArifOmer.BlogApp.DTO.DTOs.CategoryDtos
{
    public class CategoryListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
