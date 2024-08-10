using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEShop.Data;
using MyEShop.Models;

namespace MyEShop.Pages.Admin.ManageUsers
{
    public class DetailsModel : PageModel
    {
        private readonly MyEShop.Data.MyEshopContext _context;

        public DetailsModel(MyEShop.Data.MyEshopContext context)
        {
            _context = context;
        }

        public Users Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.users.FirstOrDefaultAsync(m => m.UserTd == id);
            if (users == null)
            {
                return NotFound();
            }
            else
            {
                Users = users;
            }
            return Page();
        }
    }
}
