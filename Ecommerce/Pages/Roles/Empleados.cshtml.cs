using Ecommerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Roles
{

    [Authorize(Roles = "Empleados ,Administradores")]
    public class EmpleadosModel : PageModel
    {
       


        public IActionResult Index()
        {
            return Page();
        }
    }
}
