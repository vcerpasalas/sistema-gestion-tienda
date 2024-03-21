namespace SistemaGestionWebAPI.Requests
{
    public class CrearUsuarioRequest
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombreUsuario { get; set; }
        public string contraseña { get; set; }
        public string mail { get; set; }
    }
}
