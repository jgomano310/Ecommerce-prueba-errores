using Ecommerce.Areas.Identity.Data;
using Ecommerce.Modelo;
using Ecommerce.Repositorios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Pages.Usuarios
{
    public class editarModel : PageModel
    {
        private readonly UnidadDeTrabajoRepo _unidad;
        private readonly SignInManager<EcommerceUser> _signInManager;

        // Constructor que recibe la Unidad de Trabajo y el SignInManager para autenticaci�n.
        public editarModel(UnidadDeTrabajoRepo unitOfWork, SignInManager<EcommerceUser> signInManager)
        {
            _unidad = unitOfWork;
            _signInManager = signInManager;
        }

        // Propiedad BindProperty para el modelo EditUser.
        [BindProperty]
        public EditUser UserModel { get; set; } = default!;

        // M�todo para la solicitud GET de la p�gina, recibe el ID del usuario.
        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Obtiene el usuario y los roles asociados a �l.
            var user = _unidad.User.GetUser(id);
            var roles = _unidad.Role.GetRoles();

            // Obtiene los roles asignados al usuario actual.
            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

            // Crea una lista de SelectListItem para cada rol, indicando si est� seleccionado o no.
            var roleItems = roles.Select(role =>
                new SelectListItem(
                    role.Name,
                    role.Id,
                    userRoles.Any(ur => ur.Contains(role.Name))
                )
            ).ToList();

            // Crea un objeto EditUser con el usuario y los roles asociados y lo establece como UserModel.
            var userModel = new EditUser
            {
                User = user,
                Roles = roleItems
            };

            UserModel = userModel;

            // Retorna la p�gina.
            return Page();
        }

        // M�todo para la solicitud POST de la p�gina, recibe el modelo EditUser.
        public async Task<IActionResult> OnPostAsync(EditUser UserModel)
        {
            // Obtiene el usuario desde la Unidad de Trabajo utilizando el ID del usuario en el modelo EditUser.
            var user = _unidad.User.GetUser(UserModel.User.Id);

            // Si el usuario no existe, retorna un error 404.
            if (user == null)
            {
                return NotFound();
            }

            // Obtiene los roles asignados al usuario actual.
            var userRolesInDb = await _signInManager.UserManager.GetRolesAsync(user);

            // Crea listas para almacenar los roles a agregar y quitar.
            var rolesToAdd = new List<string>();
            var rolesToRemove = new List<string>();

            foreach (var role in UserModel.Roles)
            {
                // Busca el rol en los roles asignados al usuario actual.
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);

                // Si el rol est� seleccionado en el modelo EditUser y no est� asignado al usuario, lo agrega a la lista de roles a agregar.
                if (role.Selected)
                {
                    if (assignedInDb == null)
                    {
                        rolesToAdd.Add(role.Text);
                    }
                }
                // Si el rol no est� seleccionado en el modelo EditUser y est� asignado al usuario, lo agrega a la lista de roles a quitar.
                else
                {
                    if (assignedInDb != null)
                    {
                        rolesToRemove.Add(role.Text);
                    }
                }
            }

            // Agrega los roles a agregar al usuario utilizando el UserManager del SignInManager.
            if (rolesToAdd.Any())
            {
                await _signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            // Quita los roles a quitar del usuario utilizando el UserManager del SignInManager.
            if (rolesToRemove.Any())
            {
                await _signInManager.UserManager.RemoveFromRolesAsync(user, rolesToRemove);
            }

            // Actualiza el nombre de usuario, correo electr�nico y n�mero de tel�fono del usuario.
            user.UserName = UserModel.User.UserName;
            user.Email = UserModel.User.Email;
            user.PhoneNumber = UserModel.User.PhoneNumber;

            // Actualiza el usuario en la Unidad de Trabajo.
            _unidad.User.actualizar(user);

            // Redirige a la p�gina Index.
            return RedirectToPage("./Index");
        }
    }
}
