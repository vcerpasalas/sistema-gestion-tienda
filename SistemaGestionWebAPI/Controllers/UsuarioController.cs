using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionBusiness;
using SistemaGestionEntities;
using SistemaGestionWebAPI.Requests;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{username}/{password}")]
        public ActionResult<Usuario> IniciarSesion(string username, string password)
        {
            var usuario = UsuarioBusiness.ObtenerUsuario(username, password);

            if (usuario == null)
                return NotFound(usuario);

            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Usuario> CrearUsuario([FromBody] CrearUsuarioRequest request)
        {
            var usuarioExistente = UsuarioBusiness.ObtenerUsuario(request.nombreUsuario);

            if (usuarioExistente.Id > 0)
                return UnprocessableEntity(new { Mensaje = "El usuario ya existe." });

            Usuario ultimoUsuario = UsuarioBusiness.ObtenerUltimoUsuario();

            Usuario usuario = new()
            {
                Id = ultimoUsuario.Id + 1,
                Nombre = request.nombre,
                Apellido = request.apellido,
                NombreUsuario = request.nombreUsuario,
                Contraseña = request.contraseña,
                Mail = request.mail
            };

            UsuarioBusiness.CrearUsuario(usuario);

            return Ok(new { Mensaje = "El usuario fue creado con éxito." });
        }

        [HttpPut]
        public ActionResult<Usuario> ActualizarUsuario([FromBody] ActualizarUsuarioRequest request)
        {
            var usuario = UsuarioBusiness.ObtenerUsuario(request.id);

            if (usuario == null)
                return NotFound(new { Mensaje = "El usuario no existe." });

            usuario.Nombre = request.nombre;
            usuario.Apellido = request.apellido;
            usuario.NombreUsuario = request.nombreUsuario;
            usuario.Contraseña = request.contraseña;
            usuario.Mail = request.mail;

            UsuarioBusiness.ModificarUsuario(usuario);

            return Ok(new { Mensaje = "El usuario fue actualizado con éxito." });
        }

        [HttpGet("{NombreUsuario}")]
        public ActionResult<Usuario> ObtenerUsuario(string nombreUsuario)
        {
            var usuario = UsuarioBusiness.ObtenerUsuario(nombreUsuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult<Usuario> EliminarUsuario(int id)
        {
            UsuarioBusiness.EliminarUsuario(id);

            return Ok(new { mensaje = "El usuario se ha eliminado con éxito" });
        }
    }
}