using api.domain.Dtos.Validation;
using api.domain.Dtos.Voto;
using api.domain.Dtos.Voto.Standard;
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
    public class VotosServices : IVotosServices
    {
        private readonly IVotosRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IRecursosRepository _recursosRepository;
        
        public VotosServices(IVotosRepository repository, IMapper mapper, IUsuariosRepository usuariosRepository, IRecursosRepository recursosRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _usuariosRepository = usuariosRepository;
            _recursosRepository = recursosRepository;
        }

        public async Task<IEnumerable<VotoDtoContagem>> ContarVotos()
        {
            var votos = await Get();
            var contagem = new List<VotoDtoContagem>(); 

            foreach (VotoDto item in votos)
            {
                var result = contagem.Where(v => v.Id.Equals(item.RecursoId)).FirstOrDefault();

                if (result == null)
                {
                    contagem.Add(new VotoDtoContagem()
                    {
                        Id = item.Id,
                        Tarefa = item.Recurso.Tarefa,
                        Qtd = 1
                    }); 
                }
                else
                {
                    result.Qtd++;
                }
            }

            return contagem;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<VotoDto>> Get()
        {
            return _mapper.Map<IEnumerable<VotoDto>>(await _repository.SelectAsync());
        }

        public async Task<VotoDto> Get(Guid id)
        {
            return _mapper.Map<VotoDto>(await _repository.SelectAsync(id));
        }

        public async Task<VotoDtoCreateResult> IncluirVoto(VotoDtoCreate voto)
        {
            var entity = _mapper.Map<VotoEntity>(voto);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<VotoDtoCreateResult>(result);
        }

        

        public async Task<DtoValidacao> Validation(VotoDtoValidation voto)
        {
            StringBuilder erros = new StringBuilder();
            if (!await _recursosRepository.ExistAsync(voto.RecursoId))
                erros.AppendLine("Recurso não foi encontrado");

            if (!await _usuariosRepository.ExistAsync(voto.UsuarioId))
                erros.AppendLine("Usuario não foi encontrado");
            else
            {
                var result = await _repository.SelectAsync(v => v.UsuarioId.Equals(voto.UsuarioId) && v.RecursoId.Equals(voto.RecursoId));
                if (result.Count() > 0)
                {
                    erros.AppendLine("Usuario já votou nesse recurso.");
                }
            }

            var validacao = new DtoValidacao()
            {
                Mensagem = erros.ToString(),
                Sucesso = string.IsNullOrEmpty(erros.ToString())
            } ;
            return validacao;
        }
    }
}
