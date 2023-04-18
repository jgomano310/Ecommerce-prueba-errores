using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.TdhEstadoPedidos
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DetailsModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

      public TdhEstadoPedido TdhEstadoPedido { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TdhEstadoPedidos == null)
            {
                return NotFound();
            }

            var tdhestadopedido = await _context.TdhEstadoPedidos.FirstOrDefaultAsync(m => m.Id == id);
            if (tdhestadopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdhEstadoPedido = tdhestadopedido;
            }
            return Page();
        }
    }
}
