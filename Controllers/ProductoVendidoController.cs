using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionProyectoFinal.Models;
using SistemaGestionProyectoFinal.Repositorios;

namespace SistemaGestionProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public List<Producto> TraerProductosVendidos(long idUsuario)
        {
            return ProductoVendidoHandler.ObtenerProductosVendidos(idUsuario);
        }
    }
}
