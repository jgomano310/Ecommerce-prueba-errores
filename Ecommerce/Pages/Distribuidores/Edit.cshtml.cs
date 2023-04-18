using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.Distribuidores
{
    public class EditModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public EditModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatDistribuidore CatDistribuidore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CatDistribuidores == null)
            {
                return NotFound();
            }

            var catdistribuidore =  await _context.CatDistribuidores.FirstOrDefaultAsync(m => m.CodigoLinea == id);
            if (catdistribuidore == null)
            {
                return NotFound();
            }
            CatDistribuidore = catdistribuidore;
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

            _context.Attach(CatDistribuidore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatDistribuidoreExists(CatDistribuidore.CodigoLinea))
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

        private bool CatDistribuidoreExists(string id)
        {
          return (_context.CatDistribuidores?.Any(e => e.CodigoLinea == id)).GetValueOrDefault();
        }
    }
}
