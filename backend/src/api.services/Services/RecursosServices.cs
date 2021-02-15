using api.domain.Dtos.Recurso;
using api.domain.Dtos.Recurso.Standard;
using api.domain.Dtos.Validation;
using api.domain.Entities;
using api.domain.Interfaces.Repositories;
using api.domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.services.Services
{
    public class RecursosServices : IRecursosServices
    {
        private readonly IRecursosRepository _repository;
        private readonly IMapper _mapper;

        public RecursosServices(IRecursosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecursoDto>> Get()
        {
            return _mapper.Map<IEnumerable<RecursoDto>>(await _repository.SelectAsync());
        }

        public async Task<RecursoDto> Get(Guid id)
        {
            return _mapper.Map<RecursoDto>(await _repository.SelectAsync(id));
        }

        public async Task<RecursoDtoCreateResult> Post(RecursoDtoCreate recurso)
        {
            var entity = _mapper.Map<RecursoEntity>(recurso);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<RecursoDtoCreateResult>(result);
        }

        public async Task<RecursoDtoUpdateResult> Put(RecursoDtoUpdate recurso)
        {
            var entity = _mapper.Map<RecursoEntity>(recurso);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<RecursoDtoUpdateResult>(result);
        }
    }
}
