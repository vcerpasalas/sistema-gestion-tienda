using SistemaGestionEntities;
using UsuariosData;

namespace SistemaGestionBusiness
{
    public static class UsuarioBusiness
    {
        public static Usuario ObtenerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }
        public static Usuario ObtenerUsuario(string username, string password)
        {
            return UsuarioData.ObtenerUsuario(username, password);
        }
        public static Usuario ObtenerUsuario(string username)
        {
            return UsuarioData.ObtenerUsuario(username);
        }

        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

        public static Usuario ObtenerUltimoUsuario()
        {
            return UsuarioData.ObtenerUltimoUsuario();
        }

        public static void CrearUsuario(Usuario usuario)
        {
            UsuarioData.CrearUsuario(usuario);
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            UsuarioData.ModificarUsuario(usuario);
        }

        public static void EliminarUsuario(int id)
        {
            UsuarioData.EliminarUsuario(id);
        }
    }
}