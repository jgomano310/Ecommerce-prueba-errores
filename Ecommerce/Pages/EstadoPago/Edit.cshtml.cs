using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.EstadoPago
{
    public class EditModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public EditModel(DAL.Modelo.EcommerceContext context)
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

            var catestadopago =  await _context.CatEstadoPagos.FirstOrDefaultAsync(m => m.CodEstadoPago == id);
            if (catestadopago == null)
            {
                return NotFound();
            }
            CatEstadoPago = catestadopago;
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

            _context.Attach(CatEstadoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatEstadoPagoExists(CatEstadoPago.CodEstadoPago))
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

        private bool CatEstadoPagoExists(string id)
        {
          return (_context.CatEstadoPagos?.Any(e => e.CodEstadoPago == id)).GetValueOrDefault();
        }
    }
}
