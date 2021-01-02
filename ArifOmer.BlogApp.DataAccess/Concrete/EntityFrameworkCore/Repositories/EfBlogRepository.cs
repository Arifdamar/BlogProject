using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ArifOmer.BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ArifOmer.BlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDal
    {
        public async Task<Blog> FindByBlogTitleAsync(string title)
        {
            await using var context = new BlogContext();

            return await context.Blogs.FirstOrDefaultAsync(x => x.Title == title);
        }


        public async Task<List<Category>> GetCategoriesAsync(int blogId)
        {
            await using var context = new BlogContext();

            return await context.Categories.Join(context.CategoryBlogs, c => c.Id, cb => cb.CategoryId, (category, categoryBlog) => new
            {
                category,
                categoryBlog
            }).Where(I => I.categoryBlog.BlogId == blogId).Select(I => new Category
            {
                Id = I.category.Id,
                Name = I.category.Name
            }).ToListAsync();
        }

        public async Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            await using var context = new BlogContext();

            return await context.Blogs.Join(context.CategoryBlogs, b => b.Id, cb => cb.BlogId, (blog, categoryBlog) => new
            {
                blog,
                categoryBlog
            }).Where(I => I.categoryBlog.CategoryId == categoryId).Select(I => new Blog
            {
                AppUser = I.blog.AppUser,
                AppUserId = I.blog.AppUserId,
                CategoryBlogs = I.blog.CategoryBlogs,
                Comments = I.blog.Comments,
                Description = I.blog.Description,
                Id = I.blog.Id,
                ImagePath = I.blog.ImagePath,
                PostedTime = I.blog.PostedTime,
                ShortDescription = I.blog.ShortDescription,
                Title = I.blog.Title
            }).ToListAsync();
        }
    }
}
