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

        public static ProductoVendido ObtenerUltimoProductoVendido()
        {
            return ProductoVendidoData.ObtenerUltimoProductoVendido();
        }

        public static List<ProductosVendidos> ListarProductosVendidos(List<Producto> productos)
        {
            return ProductoVendidoData.ListarProductosVendidos(productos);
        }

        public static void CargarProductos(List<Producto> productos, int correlativoProductoVendido, int idVenta)
        {
            ProductoVendidoData.CargarProductos(productos, correlativoProductoVendido, idVenta);
        }

        //public static void CrearProductoVendido(ProductoVendido productoVendido)
        //{
        //    ProductoVendidoData.CrearProductoVendido(productoVendido);
        //}

        //public static void ModificarProductoVendido(ProductoVendido productoVendido)
        //{
        //    ProductoVendidoData.ModificarProductoVendido(productoVendido);
        //}

        //public static void EliminarProductoVendido(int id)
        //{
        //    ProductoVendidoData.EliminarProductoVendido(id);
        //}
    }
}