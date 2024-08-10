using MyEShop.Data.Repository;
using MyEShop.Models;

namespace MyEShop.Data.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyEshopContext _context;    
        public CategoryRepository(MyEshopContext context)
        {
            _context = context;
                
        }
        public IEnumerable<Category> GetAllCategory()
        {
            return _context.categories;
        }

        public IEnumerable<ShowCategoryViewModel> GetCategoryForShow()
        {
            return _context.categories
                .Select(c => new ShowCategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategotyName = c.CtegoryName,
                    ProductCount = c.CategoryToProducts.Count(g => g.CategoryId == c.CategoryId)
                }).ToList();
        }
    }
}
