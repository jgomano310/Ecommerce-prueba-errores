using Ecommerce.Areas.Identity.Data;

namespace Ecommerce.Repositorios
{
    public interface InterfazUsuario
    {
        ICollection<EcommerceUser> GetUsers();
        EcommerceUser GetUser(string id);
        EcommerceUser actualizar(EcommerceUser user);

    }
}
