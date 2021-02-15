using api.domain.Dtos.Validation;
using api.domain.Dtos.Voto;
using api.domain.Dtos.Voto.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.domain.Interfaces.Services
{
    public interface IVotosServices
    {
        Task<IEnumerable<VotoDto>> Get();
        Task<VotoDto> Get(Guid id);
        Task<VotoDtoCreateResult> Post(VotoDtoCreate voto);
        Task<VotoDtoUpdateResult> Put(VotoDtoUpdate voto);
        Task<bool> Delete(Guid id);
        Task<DtoValidacao> Validation(VotoDtoValidation voto);
        Task<DtoValidacao> Validation(VotoDtoValidation voto, Guid Id);
    }
}
