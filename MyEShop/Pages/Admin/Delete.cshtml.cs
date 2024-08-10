using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEShop.Data;
using MyEShop.Models;

namespace MyEShop.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private MyEshopContext _context;
        public DeleteModel(MyEshopContext context)
        {
            _context = context;

        }
        [BindProperty]
        public Product product { get; set; }
        public void OnGet(int id)
        {
            product = _context.products.FirstOrDefault(p => p.ProductId == id);


        }
        public IActionResult OnPost(int id)
        {
            var prod = _context.products.Find(product.ProductId);
            var item = _context.items.SingleOrDefault(i => i.ItemId == prod.ItemId);
            _context.items.Remove(item);
            _context.products.Remove(prod);
            _context.SaveChanges();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
              "wwwroot",
               "Images",
                prod.ProductId + ".jpg");

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);    
            }
            return RedirectToPage("Index");


        }
    }
}
