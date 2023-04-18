using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.EstadoPago
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DeleteModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CatEstadoPago CatEstadoPago { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CatEstadoPagos == null)
            {
                return NotFound();
            }

            var catestadopago = await _context.CatEstadoPagos.FirstOrDefaultAsync(m => m.CodEstadoPago == id);

            if (catestadopago == null)
            {
                return NotFound();
            }
            else 
            {
                CatEstadoPago = catestadopago;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CatEstadoPagos == null)
            {
                return NotFound();
            }
            var catestadopago = await _context.CatEstadoPagos.FindAsync(id);

            if (catestadopago != null)
            {
                CatEstadoPago = catestadopago;
                _context.CatEstadoPagos.Remove(CatEstadoPago);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
