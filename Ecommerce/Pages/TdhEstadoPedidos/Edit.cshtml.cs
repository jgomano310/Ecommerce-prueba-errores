using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace Ecommerce.Pages.TdhEstadoPedidos
{
    public class EditModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public EditModel(DAL.Modelo.EcommerceContext context)
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

            var tdhestadopedido =  await _context.TdhEstadoPedidos.FirstOrDefaultAsync(m => m.Id == id);
            if (tdhestadopedido == null)
            {
                return NotFound();
            }
            TdhEstadoPedido = tdhestadopedido;
           ViewData["CodDevolucion"] = new SelectList(_context.CatDevolucionesPedidos, "CodDevolucion", "CodDevolucion");
           ViewData["CodEstadoEnvio"] = new SelectList(_context.CatEstadoEnvios, "CodEstadoEnvio", "CodEstadoEnvio");
           ViewData["CodEstadoPago"] = new SelectList(_context.CatEstadoPagos, "CodEstadoPago", "CodEstadoPago");
           ViewData["CodProducto"] = new SelectList(_context.CatProductos, "CodProducto", "CodProducto");
           ViewData["CodProveedores"] = new SelectList(_context.CatProveedores, "CodProveedores", "CodProveedores");
           ViewData["CodigoLinea"] = new SelectList(_context.CatDistribuidores, "CodigoLinea", "CodigoLinea");
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

            _context.Attach(TdhEstadoPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdhEstadoPedidoExists(TdhEstadoPedido.Id))
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

        private bool TdhEstadoPedidoExists(long id)
        {
          return (_context.TdhEstadoPedidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
