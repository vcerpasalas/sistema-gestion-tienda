namespace SistemaGestionWebAPI.Requests
{
    public class CargarVentaRequest
    {
        public List<ProductoRequest> productos {  get; set; }   
        public class ProductoRequest
        {
            public int id { get; set; }
            public int stock { get; set; }
        }
    }
}
