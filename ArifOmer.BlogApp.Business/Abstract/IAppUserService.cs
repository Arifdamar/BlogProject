using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        List<AppUser> GetAdminUsers();
    }
}
