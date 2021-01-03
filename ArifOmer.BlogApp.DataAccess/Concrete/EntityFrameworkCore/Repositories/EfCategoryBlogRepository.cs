using System;
using System.Collections.Generic;
using System.Text;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryBlogRepository : EfGenericRepository<CategoryBlog>, ICategoryBlogDal
    {
    }
}
