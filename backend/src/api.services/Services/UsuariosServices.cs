using api.domain.Dtos.Usuario;
using api.domain.Dtos.Usuario.Standard;
using api.domain.Dtos.Validation;
using api.domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.services.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDtoCreateResult> Post(UsuarioDtoCreate usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDtoUpdateResult> Put(UsuarioDtoUpdate usuario)
        {
            throw new NotImplementedException();
        }

        public Task<DtoValidacao> Validation(UsuarioDtoValidation usuario)
        {
            throw new NotImplementedException();
        }

        public Task<DtoValidacao> Validation(UsuarioDtoValidation usuario, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
