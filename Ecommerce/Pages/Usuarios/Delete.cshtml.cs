using Ecommerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ecommerce.Pages.Usuarios
{

    [Authorize(Roles = "Administradores, Empleados")]
    public class DeleteModel : PageModel
    {
        private readonly LoginContexto _contexto; // se crea un objeto de LoginContexto privado

        public DeleteModel(LoginContexto contexto) // constructor de la clase, que acepta una instancia de LoginContexto como argumento
        {
            _contexto = contexto; // asigna la instancia de LoginContexto al campo privado
        }

        [BindProperty] // atributo que indica que esta propiedad se puede vincular autom�ticamente a los valores enviados por el cliente
        public EcommerceUser user { get; set; }

        public async Task<IActionResult> OnGetAsync(string id) // m�todo que se llama cuando se realiza una solicitud HTTP GET a la p�gina
        {
            if (id == null || _contexto.ApplicationUserSet == null) // comprueba si el par�metro id es nulo o ApplicationUserSet es nulo
            {
                return NotFound(); // devuelve una respuesta 404 si id es nulo o ApplicationUserSet es nulo
            }

            var applicationUser = await _contexto.ApplicationUserSet.FirstOrDefaultAsync(m => m.Id == id); // busca un usuario en la base de datos que tenga el ID especificado

            if (applicationUser == null) // si no se encuentra ning�n usuario en la base de datos, devuelve una respuesta 404
            {
                return NotFound();
            }
            else // si se encuentra un usuario, asigna el usuario a la propiedad user
            {
                user = applicationUser;
            }

            return Page(); // devuelve la p�gina
        }

        public async Task<IActionResult> OnPostAsync(string id) // m�todo que se llama cuando se realiza una solicitud HTTP POST a la p�gina
        {
            if (id == null || _contexto.ApplicationUserSet == null) // comprueba si el par�metro id es nulo o ApplicationUserSet es nulo
            {
                return NotFound(); // devuelve una respuesta 404 si id es nulo o ApplicationUserSet es nulo
            }

            var applicationUser = await _contexto.ApplicationUserSet.FindAsync(id); // busca un usuario en la base de datos que tenga el ID especificado

            if (applicationUser != null) // si se encuentra un usuario en la base de datos con el ID especificado
            {
                user = applicationUser; // asigna el usuario a la propiedad user
                _contexto.ApplicationUserSet.Remove(user); // elimina el usuario de la base de datos
                await _contexto.SaveChangesAsync(); // guarda los cambios en la base de datos
            }

            return RedirectToPage("./Index"); // redirige al usuario a la p�gina Index despu�s de eliminar el usuario
        }
        }
}
