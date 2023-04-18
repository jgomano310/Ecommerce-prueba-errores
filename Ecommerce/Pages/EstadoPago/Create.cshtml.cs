using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Modelo;

namespace Ecommerce.Pages.EstadoPago
{
    public class CreateModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public CreateModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CatEstadoPago CatEstadoPago { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CatEstadoPagos == null || CatEstadoPago == null)
            {
                return Page();
            }

            _context.CatEstadoPagos.Add(CatEstadoPago);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
