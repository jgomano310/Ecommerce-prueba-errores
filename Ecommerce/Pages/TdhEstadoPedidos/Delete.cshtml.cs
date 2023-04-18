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
    public class DeleteModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public DeleteModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.TdhEstadoPedidos == null)
            {
                return NotFound();
            }
            var tdhestadopedido = await _context.TdhEstadoPedidos.FindAsync(id);

            if (tdhestadopedido != null)
            {
                TdhEstadoPedido = tdhestadopedido;
                _context.TdhEstadoPedidos.Remove(TdhEstadoPedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
