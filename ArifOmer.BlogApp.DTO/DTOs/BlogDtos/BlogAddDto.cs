using System;
using System.Collections.Generic;
using System.Text;

namespace ArifOmer.BlogApp.DTO.DTOs.BlogDtos
{
    public class BlogAddDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }

        public int AppUserId { get; set; }
    }
}
