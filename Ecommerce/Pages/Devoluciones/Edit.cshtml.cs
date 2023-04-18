using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.Devoluciones
{
    public class EditModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public EditModel(DAL.Modelo.EcommerceContext context)
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

            var catdevolucionespedido =  await _context.CatDevolucionesPedidos.FirstOrDefaultAsync(m => m.CodDevolucion == id);
            if (catdevolucionespedido == null)
            {
                return NotFound();
            }
            CatDevolucionesPedido = catdevolucionespedido;
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

            _context.Attach(CatDevolucionesPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatDevolucionesPedidoExists(CatDevolucionesPedido.CodDevolucion))
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

        private bool CatDevolucionesPedidoExists(string id)
        {
          return (_context.CatDevolucionesPedidos?.Any(e => e.CodDevolucion == id)).GetValueOrDefault();
        }
    }
}
