using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _appUserDal = appUserDal;
        }

        public List<AppUser> GetAdminUsers()
        {
            return _appUserDal.GetAdminUsers();
        }
    }
}
