using System.Collections.Generic;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.DataAccess.Abstract
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        List<AppUser> GetAdminUsers();
    }
}
