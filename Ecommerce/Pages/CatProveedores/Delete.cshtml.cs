using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.CatProveedores
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DeleteModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CatProveedore CatProveedore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CatProveedores == null)
            {
                return NotFound();
            }

            var catproveedore = await _context.CatProveedores.FirstOrDefaultAsync(m => m.CodProveedores == id);

            if (catproveedore == null)
            {
                return NotFound();
            }
            else 
            {
                CatProveedore = catproveedore;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CatProveedores == null)
            {
                return NotFound();
            }
            var catproveedore = await _context.CatProveedores.FindAsync(id);

            if (catproveedore != null)
            {
                CatProveedore = catproveedore;
                _context.CatProveedores.Remove(CatProveedore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
