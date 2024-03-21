using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosData;
using ProductosVendidoData;
using SistemaGestionBusiness;
using SistemaGestionEntities;
using SistemaGestionWebAPI.Requests;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost("{idUsuario}")]
        public ActionResult CargarVenta([FromBody] CargarVentaRequest request, int idUsuario)
        {
            var ultimaVenta = VentaBusiness.ObtenerUltimaVenta();
            Producto productoBD = new Producto();

            Venta venta = new Venta()
            {
                Id = ultimaVenta.Id + 1,
                Comentarios = string.Empty
            };
            try
            {
                VentaBusiness.CrearVenta(venta);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }

            var ultimoProductoVenido = ProductoVendidoBusiness.ObtenerUltimoProductoVendido();

            foreach (var producto in request.productos)
            {
                productoBD = ProductoBusiness.ObtenerProducto(producto.id, idUsuario);
                ProductoVendidoBusiness.CargarProductos(productoBD, producto.stock, ultimoProductoVenido.Id + 1, venta.Id);
                productoBD.Stock = productoBD.Stock - producto.stock;
                ProductoBusiness.ModificarProducto(productoBD);
            }

            return Ok(venta);
        }

        [HttpDelete("{idVenta}")]
        public ActionResult BorrarVenta(int idVenta)
        {
            try
            {
                var productosVendidos = ProductoVendidoData.ObtenerProductosVendidosPorVenta(idVenta);

                foreach (var productoVendido in productosVendidos.ToList())
                {
                    var producto = ProductoBusiness.ObtenerProducto(productoVendido.IdProducto);
                    producto.Stock = producto.Stock + productoVendido.Stock;
                    ProductoBusiness.ModificarProducto(producto);
                    ProductoVendidoBusiness.EliminarProductoVendido(productoVendido.Id);
                }

                VentaBusiness.EliminarVenta(idVenta);

                return Ok(new { mensaje = "Venta eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al intentar eliminar la venta: {ex.Message}");
            }
        }
    }
}