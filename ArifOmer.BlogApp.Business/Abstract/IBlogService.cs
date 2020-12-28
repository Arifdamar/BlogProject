using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> GetAllSortedByPostedTimeAsync();
        Task<Blog> FindByBlogTitleAsync(string title);
    }
}
