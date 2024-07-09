using Microsoft.AspNetCore.Mvc;
using AnimecatalogAPI.Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using AnimecatalogAPI.Core.Services;
using AnimecatalogAPI.Core.Exception;

namespace AnimecatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWishlistController : ControllerBase
    {
        private readonly UsuarioListaDesejoService _usuarioListaDesejoService;

        public UserWishlistController(UsuarioListaDesejoService usuarioListaDesejoService)
        {
            _usuarioListaDesejoService = usuarioListaDesejoService;
        }

        [HttpPost]
        public ActionResult AddToWishlist([FromBody] PostUsuarioListaDesejoRequest usuarioListaDesejo)
        {
            try
            {
                _usuarioListaDesejoService.AddListaDesejo(usuarioListaDesejo);
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

        [HttpGet("{userId}")]
        public ActionResult GetWishlistItems(Guid userId)
        {
            try
            {
                var items = _usuarioListaDesejoService.ObterListaItemDesejo(userId);
                return Ok(items);
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

        [HttpDelete]
        public ActionResult RemoveWishListItem([FromBody] DeleteUsuarioListaDesejoRequest request)
        {
            try
            {
                _usuarioListaDesejoService.RemoveItemListaDesejo(request);
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
    }
}
