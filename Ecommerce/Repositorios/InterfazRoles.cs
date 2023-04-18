using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Repositorios
{
    public interface InterfazRoles
    {
        ICollection<IdentityRole> GetRoles();
    }
}
