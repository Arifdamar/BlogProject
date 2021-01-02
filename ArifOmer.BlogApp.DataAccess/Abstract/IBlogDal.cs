using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.DataAccess.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        Task<Blog> FindByBlogTitleAsync(string title);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId);

    }
}
