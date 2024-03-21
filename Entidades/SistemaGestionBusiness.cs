using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public static class UsuarioBusiness
    {
        // Crear nuevo usuario
        public static void CrearUsuario(Usuario usuario)
        {
            UsuarioData.CrearUsuario(usuario);
        }

        // Obtener un usuario por su ID
        public static Usuario ObtenerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }

        // Modificar un usuario existente
        public static void ModificarUsuario(Usuario usuario)
        {
            UsuarioData.ModificarUsuario(usuario);
        }

        // Eliminar un usuario por su ID
        public static void EliminarUsuario(int id)
        {
            UsuarioData.EliminarUsuario(id);
        }
    }

    public static class ProductoBusiness
    {
        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }

        public static Producto ObtenerProducto(int id)
        {
            return ProductoData.ObtenerProducto(id);
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

    public static class VentaBusiness
    {
        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }

        public static Venta ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }

        public static void ModificarVenta(Venta venta)
        {
            VentaData.ModificarVenta(venta);
        }

        public static void EliminarVenta(int id)
        {
            VentaData.EliminarVenta(id);
        }
    }

    public static class ProductoVendidoBusiness
    {
        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.CrearProductoVendido(productoVendido);
        }

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.ModificarProductoVendido(productoVendido);
        }

        public static void EliminarProductoVendido(int id)
        {
            ProductoVendidoData.EliminarProductoVendido(id);
        }
    }
}