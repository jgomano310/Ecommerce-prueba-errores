
using Ecommerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Modelo
{
    public class EditUser
    {
        public EcommerceUser User { get; set; }
        public IList<SelectListItem> Roles { get; set; }
    }
}
