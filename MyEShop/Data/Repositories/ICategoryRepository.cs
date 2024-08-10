using MyEShop.Models;

namespace MyEShop.Data.Repository
{
    public interface ICategoryRepository
    {
       IEnumerable<Category> GetAllCategory();
        IEnumerable<ShowCategoryViewModel> GetCategoryForShow();
    }
}
