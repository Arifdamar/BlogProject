using System.Collections.Generic;
using ArifOmer.BlogApp.Entities.Abstract;

namespace ArifOmer.BlogApp.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }
    }
}
