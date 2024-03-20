﻿namespace SistemaGestionWebAPI.Requests
{
    public class ActualizarProductoRequest
    {
        public int idProducto {  get; set; }
        public int idUsuario { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
        public double precioVenta { get; set; }
        public int stock { get; set; }
    }
}
