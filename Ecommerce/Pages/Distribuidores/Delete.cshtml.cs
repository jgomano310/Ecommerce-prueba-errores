using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.Distribuidores
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DeleteModel(DAL.Modelo.EcommerceContext context)
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

            var catdistribuidore = await _context.CatDistribuidores.FirstOrDefaultAsync(m => m.CodigoLinea == id);

            if (catdistribuidore == null)
            {
                return NotFound();
            }
            else 
            {
                CatDistribuidore = catdistribuidore;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CatDistribuidores == null)
            {
                return NotFound();
            }
            var catdistribuidore = await _context.CatDistribuidores.FindAsync(id);

            if (catdistribuidore != null)
            {
                CatDistribuidore = catdistribuidore;
                _context.CatDistribuidores.Remove(CatDistribuidore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
