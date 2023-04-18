using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.EstadoEnvio
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DetailsModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

      public CatEstadoEnvio CatEstadoEnvio { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CatEstadoEnvios == null)
            {
                return NotFound();
            }

            var catestadoenvio = await _context.CatEstadoEnvios.FirstOrDefaultAsync(m => m.CodEstadoEnvio == id);
            if (catestadoenvio == null)
            {
                return NotFound();
            }
            else 
            {
                CatEstadoEnvio = catestadoenvio;
            }
            return Page();
        }
    }
}
