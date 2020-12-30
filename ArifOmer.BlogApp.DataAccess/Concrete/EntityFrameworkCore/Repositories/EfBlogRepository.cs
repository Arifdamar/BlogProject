using System.Threading.Tasks;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDal
    {
        public Task<Blog> FindByBlogTitleAsync(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
