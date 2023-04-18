using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Pages.Distribuidores
{

    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public IndexModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        public IList<CatDistribuidore> CatDistribuidore { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CatDistribuidores != null)
            {
                CatDistribuidore = await _context.CatDistribuidores.ToListAsync();
            }
        }
    }
}
