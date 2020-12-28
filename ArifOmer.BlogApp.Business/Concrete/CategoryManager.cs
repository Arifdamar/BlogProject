using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;

        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<Category>> GetAllSortedByIdAsync()
        {
            return await _genericDal.GetAllSortedAsync(I => I.Id);
        }
    }
}
