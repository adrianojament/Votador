using api.domain.Dtos.Usuario;
using api.domain.Dtos.Usuario.Standard;
using api.domain.Dtos.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.domain.Interfaces.Services
{
    public interface IUsuariosServices
    {
        Task<IEnumerable<UsuarioDto>> Get();
        Task<UsuarioDto> Get(Guid id);
        Task<UsuarioDtoCreateResult> Post(UsuarioDtoCreate usuario);
        Task<UsuarioDtoUpdateResult> Put(UsuarioDtoUpdate usuario);
        Task<bool> Delete(Guid id);
        Task<DtoValidacao> Validation(UsuarioDtoValidation usuario, Guid id);        
    }
}
