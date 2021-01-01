using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.UI.Initializers
{
    public class BlogInitializer
    {
        public static async Task SeedData(IBlogService blogService)
        {
            if (await blogService.GetAllBlogCount() == 0)
            {
                await blogService.AddAsync(new Blog()
                {
                    AppUserId = 1,
                    Title = "Default blog post",
                    Description = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                    ShortDescription = "XXXXXX"
                });
            }
        }
    }
}
