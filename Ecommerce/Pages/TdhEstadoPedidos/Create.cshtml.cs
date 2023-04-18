using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Modelo;

namespace Ecommerce.Pages.TdhEstadoPedidos
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
        ViewData["CodDevolucion"] = new SelectList(_context.CatDevolucionesPedidos, "CodDevolucion", "CodDevolucion");
        ViewData["CodEstadoEnvio"] = new SelectList(_context.CatEstadoEnvios, "CodEstadoEnvio", "CodEstadoEnvio");
        ViewData["CodEstadoPago"] = new SelectList(_context.CatEstadoPagos, "CodEstadoPago", "CodEstadoPago");
        ViewData["CodProducto"] = new SelectList(_context.CatProductos, "CodProducto", "CodProducto");
        ViewData["CodProveedores"] = new SelectList(_context.CatProveedores, "CodProveedores", "CodProveedores");
        ViewData["CodigoLinea"] = new SelectList(_context.CatDistribuidores, "CodigoLinea", "CodigoLinea");
            return Page();
        }

        [BindProperty]
        public TdhEstadoPedido TdhEstadoPedido { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TdhEstadoPedidos == null || TdhEstadoPedido == null)
            {
                return Page();
            }

            _context.TdhEstadoPedidos.Add(TdhEstadoPedido);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
