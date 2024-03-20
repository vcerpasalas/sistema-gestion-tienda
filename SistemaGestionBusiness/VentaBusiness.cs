using SistemaGestionEntities;
using VentasData;

namespace SistemaGestionBusiness
{
    public static class VentaBusiness
    {
        public static Venta ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }

        //public static List<Venta> ListarVentas()
        //{
        //    return VentaData.ListarVentas();
        //}

        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }

        public static Venta ObtenerUltimaVenta()
        {
            return VentaData.ObtenerUltimaVenta();
        }

        //public static void ModificarVenta(Venta venta)
        //{
        //    VentaData.ModificarVenta(venta);
        //}

        //public static void EliminarVenta(int id)
        //{
        //    VentaData.EliminarVenta(id);
        //}
    }
}