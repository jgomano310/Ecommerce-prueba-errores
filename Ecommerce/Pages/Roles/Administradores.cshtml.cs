using Ecommerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Roles
{

    [Authorize(Roles = "Administradores")]
    public class AdministradoresModel : PageModel
    {
        


        public IActionResult Index()
        {
            return Page();
        }
    }
}
