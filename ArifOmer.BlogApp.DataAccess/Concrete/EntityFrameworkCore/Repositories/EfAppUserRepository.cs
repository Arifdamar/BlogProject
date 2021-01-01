using System.Collections.Generic;
using System.Linq;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public List<AppUser> GetAdminUsers()
        {
            using var context = new BlogContext();

            return context.Users
                .Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                    (resultUser, resultUserRole) => new
                    {
                        user = resultUser,
                        userRole = resultUserRole
                    })
                .Join(context.Roles, userUserRole => userUserRole.userRole.RoleId, role => role.Id,
                    (resultUserUserRole, resultRole) => new
                    {
                        user = resultUserUserRole.user,
                        userRoles = resultUserUserRole.userRole,
                        roles = resultRole
                    })
                .Where(I => I.roles.Name == "Admin")
                .Select(I => new AppUser()
                {
                    Id = I.user.Id,
                    Name = I.user.Name,
                    SurName = I.user.SurName,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName
                }).ToList();
        }
    }
}
