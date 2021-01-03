using System;
using System.Collections.Generic;
using System.Text;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Concrete
{
    public class CategoryBlogManager : GenericManager<CategoryBlog>,ICategoryBlogService
    {
        public CategoryBlogManager(IGenericDal<CategoryBlog> genericDal) : base(genericDal)
        {
        }
    }
}
