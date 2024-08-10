using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEShop.Data;
using MyEShop.Models;

namespace MyEShop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MyEshopContext _context;
        public IEnumerable<Product> products { get; set; }

        public IndexModel(MyEshopContext context)
        {
                _context = context;
        }

        public void OnGet()
        {
           products= _context.products.Include(p => p.Item);
        }
        public void OnPost()
        {
        }
    }
}
