using Microsoft.AspNetCore.Mvc;
using MyEShop.Data;
using MyEShop.Data.Repository;
using MyEShop.Models;
using System.Threading.Tasks;

namespace MyEShop.Component
{
    public class ProductGroupsComponent:ViewComponent
    {
       private ICategoryRepository _categoryRepository;
        public ProductGroupsComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;  
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("/Views/Components/ProductGroupsComponent.cshtml",_categoryRepository.GetCategoryForShow());
        }
      
    }
}
