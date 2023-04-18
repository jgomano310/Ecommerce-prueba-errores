using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Pages.CatProductos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public IndexModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        public IList<CatProducto> CatProducto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CatProductos != null)
            {
                CatProducto = await _context.CatProductos.ToListAsync();
            }
        }
    }
}
