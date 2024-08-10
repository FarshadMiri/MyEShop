using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEShop.Data;

namespace MyEShop.Controllers
{
    public class ProductController : Controller
    {
        private MyEshopContext _context;
        public ProductController(MyEshopContext context)
        {
            _context = context; 
        }
        [Route("Category/{id}/{name}")]
        public IActionResult ShowProductByCategoryId(int id,string name)
        {
            ViewData["CategoryName"]=name;
            var products=_context.categoryToProducts.Where(c=>c.CategoryId==id)
                .Include(c=>c.Product)
                .Select(c=>c.Product).ToList();
            return View(products);
        }
    }
}
