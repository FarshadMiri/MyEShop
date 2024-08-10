using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEShop.Data;
using MyEShop.Models;

namespace MyEShop.Pages.Admin.ManageUsers
{
    public class EditModel : PageModel
    {
        private readonly MyEShop.Data.MyEshopContext _context;

        public EditModel(MyEShop.Data.MyEshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users =  await _context.users.FirstOrDefaultAsync(m => m.UserTd == id);
            if (users == null)
            {
                return NotFound();
            }
            Users = users;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
       

            _context.Attach(Users).State = EntityState.Modified;

            
           
                await _context.SaveChangesAsync();
            
           

            return RedirectToPage("./Index");
        }

        private bool UsersExists(int id)
        {
            return _context.users.Any(e => e.UserTd == id);
        }
    }
}
