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
    public class DetailsModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DetailsModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

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
    }
}
