using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.DTO.DTOs.CategoryBlogDtos;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryDal = categoryDal;
        }

        public async Task<List<Category>> GetAllSortedByIdAsync()
        {
            return await _genericDal.GetAllSortedAsync(I => I.Id);
        }

        public async Task<List<CategoryWithBlogsCountDto>> GetAllWithCategoryBlogsAsync()
        {
            var categories = await _categoryDal.GetAllWithCategoryBlogsAsync();
            var listCategory = new List<CategoryWithBlogsCountDto>();

            foreach (var category in categories)
            {
                var dto = new CategoryWithBlogsCountDto
                {
                    CategoryName = category.Name,
                    CategoryId = category.Id,
                    BlogsCount = category.CategoryBlogs.Count
                };

                listCategory.Add(dto);
            }

            return listCategory;
        }
    }
}
