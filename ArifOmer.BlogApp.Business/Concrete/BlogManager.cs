using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        private readonly IBlogDal _blogDal;

        public BlogManager(IGenericDal<Blog> genericDal, IBlogDal blogDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _blogDal = blogDal;
        }

        public async Task<List<Blog>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllSortedAsync(I => I.PostedTime);
        }

        public async Task<Blog> FindByBlogTitleAsync(string title)
        {
            return await _blogDal.FindByBlogTitleAsync(title);
        }

        public async Task<int> GetAllBlogCount()
        {
            return await _blogDal.GetCount();
        }
    }
}
