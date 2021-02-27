using api.domain.Entities;
using api.domain.Interfaces.Repositories.Standard;
using System.Threading.Tasks;

namespace api.domain.Interfaces.Repositories
{
    public interface IUsuariosRepository : IBaseRepository<UsuarioEntity>
    {
        Task<UsuarioEntity> getEmail(string email);
    }
}
