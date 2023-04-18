using Ecommerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Roles
{

    [Authorize(Roles = "Usuarios, Empleados, Administradores")]
    public class UsuariosModel : PageModel
    {
        public IActionResult Index()
        {
            return Page();
        }
    }
}
