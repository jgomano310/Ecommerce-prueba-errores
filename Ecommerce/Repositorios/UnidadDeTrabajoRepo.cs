namespace Ecommerce.Repositorios
{
    public class UnidadDeTrabajoRepo:IunidadDeTrabajo
    {

        public InterfazUsuario User { get; }

        public InterfazRoles Role { get; }

        public UnidadDeTrabajoRepo(InterfazUsuario user, InterfazRoles role)
        {
            User = user;
            Role = role;
        }
    }
}
