using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.DTO.DTOs.BlogDtos;
using ArifOmer.BlogApp.DTO.DTOs.CategoryBlogDtos;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> GetAllSortedByPostedTimeAsync();
        Task<Blog> FindByBlogTitleAsync(string title);
        Task<int> GetAllBlogCount();
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task<List<Blog>> SearchAsync(string searchString);
    }
}
