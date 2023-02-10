using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionProyectoFinal.Models;
using SistemaGestionProyectoFinal.Repositorios;

namespace SistemaGestionProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{usuario}/{passw}")]
        public Usuario Login(string usuario, string passw)
        {
            return UsuarioHandler.Login(usuario, passw);
        }

        [HttpPost]
        public void Register(Usuario user)
        {
            UsuarioHandler.Register(user);
        }

        [HttpPut]
        public void ModificarUsuario(Usuario user)
        {
            UsuarioHandler.UpdateUser(user);
        }

        [HttpGet("{usuario}")]
        public Usuario traerUsuario(string usuario)
        {
            return UsuarioHandler.TraerUsuario(usuario);
        }

    }
}
