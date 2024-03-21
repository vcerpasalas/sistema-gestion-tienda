using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {

        [HttpGet("{idUsuario}")]
        public ActionResult<Producto> ObtenerProductosVendidos(int idUsuario)
        {
            var productos = ProductoBusiness.ListarProductos(idUsuario);

            if (productos.Count() <= 0)
            {
                return NotFound();
            }

            var productosVendidos = ProductoVendidoBusiness.ListarProductosVendidos(productos);

            return Ok(productosVendidos);
        }
    }
}
