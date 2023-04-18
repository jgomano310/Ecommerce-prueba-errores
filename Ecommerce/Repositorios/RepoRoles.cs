using Ecommerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Repositorios
{
    public class RepoRoles:InterfazRoles
    {
        private readonly LoginContexto _Contexto;

        public RepoRoles(LoginContexto contexto)
        {
            _Contexto = contexto;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _Contexto.Roles.ToList();
        }
    }
}
