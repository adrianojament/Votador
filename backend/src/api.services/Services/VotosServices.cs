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
        private readonly IUsuariosServices _usuariosService;
        private readonly IRecursosServices _recursosService;

        public VotosServices(IVotosRepository repository, IMapper mapper, IUsuariosServices usuariosService, IRecursosServices recursosService)
        {
            _repository = repository;
            _mapper = mapper;
            _usuariosService = usuariosService;
            _recursosService = recursosService;
        }

        public async Task<IEnumerable<VotoDtoContagem>> ContarVotos()
        {
            var votos = await Get();
            var contagem = new List<VotoDtoContagem>(); 

            foreach (VotoDto item in votos)
            {
                var result = contagem.Where(v => v.IdRecurso.Equals(item.RecursoId)).FirstOrDefault();

                if (result == null)
                {
                    contagem.Add(new VotoDtoContagem()
                    {
                        IdRecurso = item.RecursoId,
                        Tarefa = item.Recurso.Tarefa,
                        Qtd = 1
                    }); 
                }
                else
                {
                    result.Qtd++;
                }
            }
            contagem.OrderByDescending(x => x.Qtd);

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
        
        public async Task<DtoValidacao> ValidationInsert(VotoDtoRecepcao voto)
        {
            var validacao = new DtoValidacao();
            validacao.Sucesso = true;

            if (string.IsNullOrEmpty(voto.Comentario))
            {
                validacao.Sucesso = false;
                validacao.Mensagem = "Não foi realizado o comentário";
                return validacao;
            }

            var entityRecurso = await _recursosService.Get(voto.IdRecurso);
            if (entityRecurso == null)
            {
                validacao.Sucesso = false;
                validacao.Mensagem = "Recurso não foi encontrado";
                return validacao;
            }

            var validacaoUser = await _usuariosService.ValidateEmailPassword(voto.eMail, voto.Senha);
            if (!validacaoUser.Sucesso)
            {
                validacao.Sucesso = false;
                validacao.Mensagem = validacaoUser.Mensagem;
                return validacao;
            }

            var entityUsuario = await _usuariosService.GetUserEmail(voto.eMail);

            var result = await _repository.SelectAsync(v => v.UsuarioId.Equals(entityUsuario.Id) && v.RecursoId.Equals(entityRecurso.Id));
            if (result.Count() > 0)
            {
                validacao.Sucesso = false;
                validacao.Mensagem = "Usuario já votou nesse recurso";
                return validacao;
            }

            var votoCreate = new VotoDtoCreate();
            votoCreate.Comentario = voto.Comentario;
            votoCreate.UsuarioId = entityUsuario.Id;
            votoCreate.RecursoId = entityRecurso.Id;

            try
            {
                await IncluirVoto(votoCreate);
            }
            catch (Exception ex)
            {
                validacao.Sucesso = false;
                validacao.Mensagem = ex.Message;
            }
            
            return validacao;
        }
    }
}
