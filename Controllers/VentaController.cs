using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionProyectoFinal.Models;
using SistemaGestionProyectoFinal.Repositorios;

namespace SistemaGestionProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public void CrearVenta(List<Producto> productos, long idUser)
        {
            VentaHandler.InsertVenta(productos, idUser);
        }

        [HttpGet("{idUsuario}")]
        public List<Venta> TraerVentas(long idUsuario)
        {
            return VentaHandler.ObtenerVentasRealizadas(idUsuario);
            
        }

        
    }
}
