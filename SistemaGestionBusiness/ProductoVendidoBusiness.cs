using ProductosVendidoData;
using SistemaGestionEntities;

namespace SistemaGestionBusiness
{
    public static class ProductoVendidoBusiness
    {
        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }
        public static List<ProductoVendido> ObtenerProductosVendidosPorVenta(int idVenta)
        {
            return ProductoVendidoData.ObtenerProductosVendidosPorVenta(idVenta);
        }

        public static ProductoVendido ObtenerUltimoProductoVendido()
        {
            return ProductoVendidoData.ObtenerUltimoProductoVendido();
        }

        public static List<ProductosVendidos> ListarProductosVendidos(List<Producto> productos)
        {
            return ProductoVendidoData.ListarProductosVendidos(productos);
        }

        public static void CargarProductos(Producto producto, int stock, int correlativoProductoVendido, int idVenta)
        {
            ProductoVendidoData.CargarProductos(producto, stock, correlativoProductoVendido, idVenta);
        }

        //public static void CrearProductoVendido(ProductoVendido productoVendido)
        //{
        //    ProductoVendidoData.CrearProductoVendido(productoVendido);
        //}

        //public static void ModificarProductoVendido(ProductoVendido productoVendido)
        //{
        //    ProductoVendidoData.ModificarProductoVendido(productoVendido);
        //}

        public static void EliminarProductoVendido(int id)
        {
            ProductoVendidoData.EliminarProductoVendido(id);
        }
    }
}