using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.CatProveedores
{
    public class EditModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public EditModel(DAL.Modelo.EcommerceContext context)
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

            var catproveedore =  await _context.CatProveedores.FirstOrDefaultAsync(m => m.CodProveedores == id);
            if (catproveedore == null)
            {
                return NotFound();
            }
            CatProveedore = catproveedore;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CatProveedore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatProveedoreExists(CatProveedore.CodProveedores))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatProveedoreExists(string id)
        {
          return (_context.CatProveedores?.Any(e => e.CodProveedores == id)).GetValueOrDefault();
        }
    }
}
