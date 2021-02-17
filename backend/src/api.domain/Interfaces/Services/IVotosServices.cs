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
        Task<VotoDtoCreateResult> IncluirVoto(VotoDtoCreate voto);
        Task<IEnumerable<VotoDtoContagem>> ContarVotos();
        Task<bool> Delete(Guid id);
        Task<DtoValidacao> Validation(VotoDtoValidation voto);        
    }
}
