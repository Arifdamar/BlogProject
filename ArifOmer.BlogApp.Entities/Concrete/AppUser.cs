using System.Collections.Generic;
using ArifOmer.BlogApp.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace ArifOmer.BlogApp.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
