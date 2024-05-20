using AnimecatalogAPI.Core.Entities;
using AnimecatalogAPI.Core.Messaging;
using AnimecatalogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimecatalogAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Cadastro")]
        public ActionResult AddUsuario(PostUsuarioRequest request)
        {
            _usuarioService.AddUsuario(request);
            return Ok();
        }

        [HttpPost("Login")]
        public ActionResult Login(string email, string senha) 
        {
            var usuario = _usuarioService.Autenticar(email, senha);

            if (usuario is null)
                throw new Exception("Usuário ou senha inválidos");

            return Ok(usuario);
        }
    }
}
