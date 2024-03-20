using SistemaGestionEntities;
using ProductosData;

namespace SistemaGestionBusiness
{
    public static class ProductoBusiness
    {
        public static Producto ObtenerProducto(int id)
        {
            return ProductoData.ObtenerProducto(id);
        }
        public static Producto ObtenerProducto(int idProducto, int idUsuario)
        {
            return ProductoData.ObtenerProducto(idProducto, idUsuario);
        }
        public static Producto ObtenerUltimoProducto()
        {
            return ProductoData.ObtenerUltimoProducto();
        }

        public static List<Producto> ListarProductos(int idUsuario)
        {
            return ProductoData.ListarProductos(idUsuario);
        }

        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }

        public static void ModificarProducto(Producto producto)
        {
            ProductoData.ModificarProducto(producto);
        }

        public static void EliminarProducto(int id)
        {
            ProductoData.EliminarProducto(id);
        }
    }
}