using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombreController: ControllerBase
    {
        public NombreController()
        {
                
        }

        [HttpGet]
        public ActionResult<string> Hola()
        {
            return Ok(new { Nombre = "Sistema de gestión"});
        }
    }
}
