using api.domain.Dtos.Recurso;
using api.domain.Dtos.Recurso.Standard;
using api.domain.Dtos.Validation;
using api.domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.services.Services
{
    public class RecursosServices : IRecursosServices
    {
        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecursoDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<RecursoDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RecursoDtoCreateResult> Post(RecursoDtoCreate recurso)
        {
            throw new NotImplementedException();
        }

        public Task<RecursoDtoUpdateResult> Put(RecursoDtoUpdate recurso)
        {
            throw new NotImplementedException();
        }

        public Task<DtoValidacao> Validation(RecursoDtoValidation recurso)
        {
            throw new NotImplementedException();
        }

        public Task<DtoValidacao> Validation(RecursoDtoValidation recurso, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
