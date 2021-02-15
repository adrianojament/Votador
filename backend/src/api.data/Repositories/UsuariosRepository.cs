using api.data.Context;
using api.data.Repositories.Standard;
using api.domain.Entities;
using api.domain.Interfaces.Repositories;

namespace api.data.Repositories
{
    public class UsuariosRepository : BaseRepository<UsuarioEntity>, IUsuariosRepository
    {
        public UsuariosRepository(VotosContext context) : base(context)
        {
            _dataset = _context.Set<UsuarioEntity>();
        }
    }
}
