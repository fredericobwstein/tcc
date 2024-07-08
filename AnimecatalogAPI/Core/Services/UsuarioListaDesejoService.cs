using AnimecatalogAPI.Core.Repository.RawQueryResult;
using AnimecatalogAPI.Core.Repository.Usuario;

namespace AnimecatalogAPI.Core.Services
{
    public class UsuarioListaDesejoService
    {
        private readonly UsuarioListaDesejoRepository _usuarioListaDesejoRepository;

        public UsuarioListaDesejoService(UsuarioListaDesejoRepository usuarioListaDesejoRepository)
        {
            _usuarioListaDesejoRepository = usuarioListaDesejoRepository;
        }

        public void AddListaDesejo(PostUsuarioListaDesejoRequest request)
        {
            try
            {
                if (request.UserId == null)
                {
                    throw new Exception("Você precisa estar logado para salvar algum item da lista.");
                }

                string sql = @"
                        SELECT 
                            mal_id
                        FROM usuario_listadesejo 
                        WHERE mal_id = @MalId and usuario_id = @UserId";

                var parameters = new { MalId = request.MalId, UserId = request.UserId };

                var response = _usuarioListaDesejoRepository.Query<ConsultaMalIdRawQueryResult>(sql, parameters).Any();

                if (response)
                    throw new Exception("Você já adicionou esse item na lista.");

                    var listaDesejo = new Entities.UsuarioListaDesejo
                {
                    Id = Guid.NewGuid(),
                    MalId = request.MalId,
                    UsuarioId = request.UserId,
                    DataCadastro = DateTime.Now
                };

                _usuarioListaDesejoRepository.Insert(listaDesejo);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar a lista de desejo.");
            }
        }

        public List<UsuarioLitasDesejoRayQueryResult> ObterListaItemDesejo(Guid userId)
        {
            string sql = @"
                        SELECT 
                            mal_id,
                            id
                        FROM usuario_listadesejo 
                        WHERE usuario_id = @UserId";

            var parameters = new { UserId = userId };

            var response = _usuarioListaDesejoRepository.Query<UsuarioLitasDesejoRayQueryResult>(sql, parameters).ToList();

            return response;
        }

        public void RemoveItemListaDesejo(DeleteUsuarioListaDesejoRequest request)
        {
            try
            {
                if (request.UserId == null)
                {
                    throw new Exception("Você precisa estar logado para remover algum item da lista.");
                }

                string sql = @"
                           SELECT
                                id
                            FROM usuario_listadesejo
                            Where usuario_id = @UserId and mal_id = @MalId";

                var parameters = new { UserId = request.UserId, MalId = request.MalId };

                var idListaDesejo = _usuarioListaDesejoRepository.Query<ListaDesejoRayQueryResult>(sql, parameters).SingleOrDefault();

                var listaDesesjoRemocao = new Entities.UsuarioListaDesejo
                {
                    Id = idListaDesejo.id,
                    UsuarioId = request.UserId,
                    MalId = request.MalId
                };

                _usuarioListaDesejoRepository.Delete(listaDesesjoRemocao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível remover o item da lista de desejo.");
            }
        }
    }
}