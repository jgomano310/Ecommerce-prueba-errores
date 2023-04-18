﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Pages.EstadoPago
{

    [Authorize(Roles = "Users, Administrators")]
    public class IndexModel : PageModel
    {
        private readonly DAL.Modelo.EcommerceContext _context;

        public IndexModel(DAL.Modelo.EcommerceContext context)
        {
            _context = context;
        }

        public IList<CatEstadoPago> CatEstadoPago { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CatEstadoPagos != null)
            {
                CatEstadoPago = await _context.CatEstadoPagos.ToListAsync();
            }
        }
    }
}
