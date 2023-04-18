using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.EstadoEnvio
{
    public class EditModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public EditModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatEstadoEnvio CatEstadoEnvio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CatEstadoEnvios == null)
            {
                return NotFound();
            }

            var catestadoenvio =  await _context.CatEstadoEnvios.FirstOrDefaultAsync(m => m.CodEstadoEnvio == id);
            if (catestadoenvio == null)
            {
                return NotFound();
            }
            CatEstadoEnvio = catestadoenvio;
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

            _context.Attach(CatEstadoEnvio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatEstadoEnvioExists(CatEstadoEnvio.CodEstadoEnvio))
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

        private bool CatEstadoEnvioExists(string id)
        {
          return (_context.CatEstadoEnvios?.Any(e => e.CodEstadoEnvio == id)).GetValueOrDefault();
        }
    }
}
