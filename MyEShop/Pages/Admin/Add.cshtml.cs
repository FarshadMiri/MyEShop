using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEShop.Data;
using MyEShop.Models;
using System.Runtime.CompilerServices;

namespace MyEShop.Pages.Admin
{
    public class AddModel : PageModel
    {
        private MyEshopContext _context;
        public AddModel(MyEshopContext context)
        {
            _context = context;  
        }
        [BindProperty]
        public AddEditProductViewModel product  { get; set; } 
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }

            var item = new Item()
            {
                 Price = product.Price,
                  QuantityInStock = product.QuantityInStock

            };
            _context.Add(item);
            _context.SaveChanges();
            var prod = new Product()
            {
                  ProductName=product.ProductName,
                    Item=item,
                    Description=product.Description,
                    
            };
            _context.Add(prod);
            _context.SaveChanges();
            prod.ItemId=prod.ProductId;
            _context.SaveChanges();

            if (product.Picture?.Length>0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    prod.ProductId + Path.GetExtension(product.Picture.FileName));
                using (var stream=new FileStream(filePath,FileMode.Create))
                {
                    product.Picture.CopyTo(stream);
                }

            }
            return RedirectToPage("Index");
        }
    }
}
