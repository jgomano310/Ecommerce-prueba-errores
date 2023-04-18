using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.Devoluciones
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DeleteModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CatDevolucionesPedido CatDevolucionesPedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CatDevolucionesPedidos == null)
            {
                return NotFound();
            }

            var catdevolucionespedido = await _context.CatDevolucionesPedidos.FirstOrDefaultAsync(m => m.CodDevolucion == id);

            if (catdevolucionespedido == null)
            {
                return NotFound();
            }
            else 
            {
                CatDevolucionesPedido = catdevolucionespedido;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CatDevolucionesPedidos == null)
            {
                return NotFound();
            }
            var catdevolucionespedido = await _context.CatDevolucionesPedidos.FindAsync(id);

            if (catdevolucionespedido != null)
            {
                CatDevolucionesPedido = catdevolucionespedido;
                _context.CatDevolucionesPedidos.Remove(CatDevolucionesPedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
