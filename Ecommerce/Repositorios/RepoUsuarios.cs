using Ecommerce.Areas.Identity.Data;

namespace Ecommerce.Repositorios
{
    public class RepoUsuarios:InterfazUsuario
    {
        private readonly LoginContexto _contexto;

        public RepoUsuarios(LoginContexto contexto)
        {
            _contexto = contexto;
        }

        public ICollection<EcommerceUser> GetUsers()
        {
            return _contexto.Users.ToList();
        }

        public EcommerceUser GetUser(string id)
        {
            return _contexto.Users.FirstOrDefault(u => u.Id == id);
        }

        public EcommerceUser actualizar(EcommerceUser user)
        {
            _contexto.Update(user);
            _contexto.SaveChanges();

            return user;
        }
    }
}
