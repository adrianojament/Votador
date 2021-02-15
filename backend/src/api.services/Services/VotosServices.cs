using api.domain.Dtos.Validation;
using api.domain.Dtos.Voto;
using api.domain.Dtos.Voto.Standard;
using api.domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.services.Services
{
    public class VotosServices : IVotosServices
    {
        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VotoDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<VotoDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<VotoDtoCreateResult> Post(VotoDtoCreate voto)
        {
            throw new NotImplementedException();
        }

        public Task<VotoDtoUpdateResult> Put(VotoDtoUpdate voto)
        {
            throw new NotImplementedException();
        }

        public Task<DtoValidacao> Validation(VotoDtoValidation voto)
        {
            throw new NotImplementedException();
        }

        public Task<DtoValidacao> Validation(VotoDtoValidation voto, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
