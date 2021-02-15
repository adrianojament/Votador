using api.domain.Dtos.Recurso;
using api.domain.Dtos.Usuario;
using api.domain.Dtos.Voto;
using api.domain.Entities;
using AutoMapper;

namespace api.crossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            _mappingUsuarios();
            _mappingRecursos();
            _mappingVotos();
        }

        private void _mappingVotos()
        {
            CreateMap<VotoDto, VotoEntity>().ReverseMap();
            CreateMap<VotoDtoCreateResult, VotoEntity>().ReverseMap();
            CreateMap<VotoDtoUpdateResult, VotoEntity>().ReverseMap();
        }

        private void _mappingRecursos()
        {
            CreateMap<RecursoDto, RecursoEntity>().ReverseMap();
            CreateMap<RecursoDtoVoto, RecursoEntity>().ReverseMap();
            CreateMap<RecursoDtoCreateResult, RecursoEntity>().ReverseMap();
            CreateMap<RecursoDtoUpdateResult, RecursoEntity>().ReverseMap();
        }

        private void _mappingUsuarios()
        {
            CreateMap<UsuarioDto, UsuarioEntity>().ReverseMap();
            CreateMap<UsuarioDtoVoto, UsuarioEntity>().ReverseMap();
            CreateMap<UsuarioDtoCreateResult, UsuarioEntity>().ReverseMap();
            CreateMap<UsuarioDtoUpdateResult, UsuarioEntity>().ReverseMap();
        }
    }
}
