using Ecommerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly LoginContexto _context;

        public IndexModel(LoginContexto context)
        {
            _context = context; // Inicializa el contexto de la base de datos en el constructor
        }

        public IList<EcommerceUser> user { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Users != null) // Comprueba si hay usuarios en la base de datos
            {
                user = await _context.Users.ToListAsync(); // Obtiene la lista de usuarios de la base de datos y la asigna a la propiedad 'user'
            }
        }
    }
}
