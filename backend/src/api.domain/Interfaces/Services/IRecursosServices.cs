using api.domain.Dtos.Recurso;
using api.domain.Dtos.Recurso.Standard;
using api.domain.Dtos.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.domain.Interfaces.Services
{
    public interface IRecursosServices
    {
        Task<IEnumerable<RecursoDto>> Get();
        Task<RecursoDto> Get(Guid id);
        Task<RecursoDtoCreateResult> Post(RecursoDtoCreate recurso);
        Task<RecursoDtoUpdateResult> Put(RecursoDtoUpdate recurso);
        Task<bool> Delete(Guid id);
        Task<DtoValidacao> Validation(RecursoDtoValidation recurso);
        Task<DtoValidacao> Validation(RecursoDtoValidation recurso, Guid Id);
    }
}
