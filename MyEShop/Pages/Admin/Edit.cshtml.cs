using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyEShop.Data;
using MyEShop.Models;

namespace MyEShop.Pages.Admin
{
    public class EditModel : PageModel
    {
       private MyEshopContext _context;
        public EditModel(MyEshopContext context)
        {
                _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel product { get; set; }
        public void OnGet(int id)
        {
            var pro = _context.products.Include(p => p.Item)
                .Where(p => p.ProductId == id)
                .Select(s => new AddEditProductViewModel
                {
                    ProductId = s.ProductId,
                    ProductName = s.ProductName,
                    Description = s.Description,
                    Price = s.Item.Price,
                    QuantityInStock = s.Item.QuantityInStock
                }).FirstOrDefault();

            product = pro;

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var prod=_context.products.Find(product.ProductId);
            var item = _context.items.SingleOrDefault(i => i.ItemId == prod.ItemId);
           prod.ProductName = product.ProductName;
            prod.Description = product.Description;
            item.Price=product.Price;
            item.QuantityInStock = product.QuantityInStock;
            _context.SaveChanges();
            if (product.Picture?.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                   product.ProductId + Path.GetExtension(product.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    product.Picture.CopyTo(stream);
                }

            }
            
            return RedirectToPage("Index");
        }
        
    }
}
