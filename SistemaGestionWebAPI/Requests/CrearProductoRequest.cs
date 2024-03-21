namespace SistemaGestionWebAPI.Requests
{
    public class CrearProductoRequest
    {
        public int idUsuario { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
        public double precioVenta { get; set; }
        public int stock { get; set; }

    }
}
