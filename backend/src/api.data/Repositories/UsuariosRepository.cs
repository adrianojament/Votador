using api.data.Context;
using api.data.Repositories.Standard;
using api.domain.Entities;
using api.domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api.data.Repositories
{
    public class UsuariosRepository : BaseRepository<UsuarioEntity>, IUsuariosRepository
    {
        public UsuariosRepository(VotosContext context) : base(context)
        {
            _dataset = _context.Set<UsuarioEntity>();
        }

        public async Task<UsuarioEntity> getEmail(string email)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.eMail.Equals(email));
        }
    }
}
