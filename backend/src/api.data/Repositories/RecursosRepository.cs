using api.data.Context;
using api.data.Repositories.Standard;
using api.domain.Entities;
using api.domain.Interfaces.Repositories;

namespace api.data.Repositories
{
    public class RecursosRepository : BaseRepository<RecursoEntity>, IRecursosRepository
    {
        public RecursosRepository(VotosContext context) : base(context)
        {
            _dataset = _context.Set<RecursoEntity>();
        }
    }
}
