using System;
using System.Collections.Generic;
using System.Text;

namespace ArifOmer.BlogApp.DTO.DTOs.BlogDtos
{
    public class BlogUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public int AppUserId { get; set; }
    }
}
