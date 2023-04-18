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
    public class IndexModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public IndexModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        public IList<TdhEstadoPedido> TdhEstadoPedido { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdhEstadoPedidos != null)
            {
                TdhEstadoPedido = await _context.TdhEstadoPedidos
                .Include(t => t.CodDevolucionNavigation)
                .Include(t => t.CodEstadoEnvioNavigation)
                .Include(t => t.CodEstadoPagoNavigation)
                .Include(t => t.CodProductoNavigation)
                .Include(t => t.CodProveedoresNavigation)
                .Include(t => t.CodigoLineaNavigation).ToListAsync();
            }
        }
    }
}
