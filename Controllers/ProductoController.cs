using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionProyectoFinal.Models;
using SistemaGestionProyectoFinal.Repositorios;

namespace SistemaGestionProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public void CrearProducto(Producto producto)
        {
            ProductoHandler.InsertarProducto(producto);
        }

        [HttpPut]
        public void UpdateProducto(Producto producto)
        {
            ProductoHandler.UpdateProduct(producto);
        }

        [HttpDelete("{id}")]
        public void DeleteProducto(long id)
        {
            ProductoHandler.DeleteProducto(id);
        }
    }
}
