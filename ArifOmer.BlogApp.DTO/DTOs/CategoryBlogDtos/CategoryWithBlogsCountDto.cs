using System;
using System.Collections.Generic;
using System.Text;

namespace ArifOmer.BlogApp.DTO.DTOs.CategoryBlogDtos
{
    public class CategoryWithBlogsCountDto
    {
        public int BlogsCount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
