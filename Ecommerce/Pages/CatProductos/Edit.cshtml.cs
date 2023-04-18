using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.CatProductos
{
    public class EditModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public EditModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatProducto CatProducto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CatProductos == null)
            {
                return NotFound();
            }

            var catproducto =  await _context.CatProductos.FirstOrDefaultAsync(m => m.CodProducto == id);
            if (catproducto == null)
            {
                return NotFound();
            }
            CatProducto = catproducto;
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

            _context.Attach(CatProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatProductoExists(CatProducto.CodProducto))
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

        private bool CatProductoExists(string id)
        {
          return (_context.CatProductos?.Any(e => e.CodProducto == id)).GetValueOrDefault();
        }
    }
}
