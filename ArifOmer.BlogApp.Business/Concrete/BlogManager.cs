using System.Collections.Generic;
using System.Threading.Tasks;
using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.DTO.DTOs.BlogDtos;
using ArifOmer.BlogApp.DTO.DTOs.CategoryBlogDtos;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        private readonly IGenericDal<CategoryBlog> _categoryBlogService;
        private readonly IBlogDal _blogDal;

        public BlogManager(IGenericDal<Blog> genericDal, IBlogDal blogDal, IGenericDal<CategoryBlog> categoryBlogService) : base(genericDal)
        {
            _genericDal = genericDal;
            _blogDal = blogDal;
            _categoryBlogService = categoryBlogService;
        }

        public async Task<List<Blog>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllSortedAsync(I => I.PostedTime);
        }

        public async Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _blogDal.GetAllByCategoryIdAsync(categoryId);
        }

        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var control = await _categoryBlogService.GetAsync(I => I.CategoryId == categoryBlogDto.CategoryId && I.BlogId == categoryBlogDto.BlogId);
            
            if (control == null)
            {
                await _categoryBlogService.AddAsync(new CategoryBlog
                {
                    BlogId = categoryBlogDto.BlogId,
                    CategoryId = categoryBlogDto.CategoryId
                });
            }
        }
        public async Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var deletedCategoryBlog = await _categoryBlogService.GetAsync(I => I.CategoryId == categoryBlogDto.CategoryId && I.BlogId == categoryBlogDto.BlogId);
            
            if (deletedCategoryBlog != null)
            {
                await _categoryBlogService.RemoveAsync(deletedCategoryBlog);
            }
        }

        public async Task<List<Blog>> SearchAsync(string searchString)
        {
            return await _blogDal.GetAllAsync(I => I.Title.Contains(searchString) || I.ShortDescription.Contains(searchString) || I.Description.Contains(searchString), I => I.PostedTime);
        }

        public async Task<Blog> FindByBlogTitleAsync(string title)
        {
            return await _blogDal.FindByBlogTitleAsync(title);
        }

        public async Task<int> GetAllBlogCount()
        {
            return await _blogDal.GetCount();
        }

        public async Task<List<Category>> GetCategoriesAsync(int blogId)
        {
            return await _blogDal.GetCategoriesAsync(blogId);
        }
    }
}
