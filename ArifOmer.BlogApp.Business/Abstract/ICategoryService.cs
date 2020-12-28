using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<List<Category>> GetAllSortedByIdAsync();
    }
}
