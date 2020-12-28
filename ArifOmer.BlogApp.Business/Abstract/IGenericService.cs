using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Entities.Abstract;

namespace ArifOmer.BlogApp.Business.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
