using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<Producto> productos = new();
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

            foreach (var producto in request.productos)
            {
                productoBD = ProductoBusiness.ObtenerProducto(producto.id, idUsuario);
                productoBD.Stock = productoBD.Stock - producto.stock;
                ProductoBusiness.ModificarProducto(productoBD);
                productos.Add(productoBD);
            }

            var ultimoProductoVenido = ProductoVendidoBusiness.ObtenerUltimoProductoVendido();

            ProductoVendidoBusiness.CargarProductos(productos, ultimoProductoVenido.Id + 1, venta.Id);

            return Ok(venta);
        }
    }
}