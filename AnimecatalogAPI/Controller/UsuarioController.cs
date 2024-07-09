using AnimecatalogAPI.Core.Entities;
using AnimecatalogAPI.Core.Exception;
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
            try
            {
                _usuarioService.AddUsuario(request);
                return Ok();
            }
            catch (AnimecatalogException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro genérico.");
            }
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginRequest request)
        {
            try
            {
                var usuario = _usuarioService.Autenticar(request);

                if (usuario is null)
                    throw new AnimecatalogException("Usuário ou senha inválidos.");

                return Ok(usuario);

            }
            catch (AnimecatalogException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro genérico.");
            }
        }
    }
}
