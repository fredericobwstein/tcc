using Microsoft.AspNetCore.Mvc;
using AnimecatalogAPI.Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using AnimecatalogAPI.Core.Services;

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
            _usuarioListaDesejoService.AddListaDesejo(usuarioListaDesejo);
            return Ok();
        }

        [HttpGet("{userId}")]
        public ActionResult GetWishlistItems(Guid userId)
        {
            var items = _usuarioListaDesejoService.ObterListaItemDesejo(userId);
            return Ok(items);
        }

        [HttpDelete]
        public ActionResult RemoveWishListItem([FromBody] DeleteUsuarioListaDesejoRequest request)
        {
            _usuarioListaDesejoService.RemoveItemListaDesejo(request);
                return Ok();
        }
    }
}
