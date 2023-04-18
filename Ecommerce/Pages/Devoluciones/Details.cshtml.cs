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
    public class DetailsModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DetailsModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

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
    }
}
