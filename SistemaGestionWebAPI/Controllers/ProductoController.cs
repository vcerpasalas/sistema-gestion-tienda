using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionBusiness;
using SistemaGestionEntities;
using SistemaGestionWebAPI.Requests;


namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public ActionResult<Producto> ObtenerProductos(int idUsuario)
        {
            var productos = ProductoBusiness.ListarProductos(idUsuario);

            if (productos.Count() <= 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpPost]
        public ActionResult<Producto> CrearProducto([FromBody] CrearProductoRequest request)
        {
            var ultimoProducto = ProductoBusiness.ObtenerUltimoProducto();

            Producto producto = new()
            {
                Id = ultimoProducto.Id + 1,
                Descripcion = request.descripcion,
                Costo = request.costo,
                PrecioVenta = request.precioVenta,
                Stock = request.stock,
                IdUsuario = request.idUsuario
            };

            ProductoBusiness.CrearProducto(producto);

            return Ok(producto);
        }

        [HttpPut]
        public ActionResult<Producto> ActualizarProducto([FromBody] ActualizarProductoRequest request)
        {
            var producto = ProductoBusiness.ObtenerProducto(request.idProducto);

            if (producto == null)
                return NotFound(producto);

            producto.Descripcion = request.descripcion;
            producto.Costo = request.costo;
            producto.PrecioVenta = request.precioVenta;
            producto.Stock = request.stock;

            ProductoBusiness.ModificarProducto(producto);

            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public ActionResult<Producto> EliminarProducto(int id)
        {
            var producto = ProductoBusiness.ObtenerProducto(id);

            if (producto == null)
                return NotFound(producto);

            ProductoBusiness.EliminarProducto(producto.Id);

            return Ok(new { mensaje = "El producto se ha eliminado con éxtio."});
        }
    }
}
