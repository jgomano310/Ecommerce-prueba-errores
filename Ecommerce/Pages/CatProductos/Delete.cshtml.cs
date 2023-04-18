using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.CatProductos
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DeleteModel(DAL.Modelo.EcommerceContext context)
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

            var catproducto = await _context.CatProductos.FirstOrDefaultAsync(m => m.CodProducto == id);

            if (catproducto == null)
            {
                return NotFound();
            }
            else 
            {
                CatProducto = catproducto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CatProductos == null)
            {
                return NotFound();
            }
            var catproducto = await _context.CatProductos.FindAsync(id);

            if (catproducto != null)
            {
                CatProducto = catproducto;
                _context.CatProductos.Remove(CatProducto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
