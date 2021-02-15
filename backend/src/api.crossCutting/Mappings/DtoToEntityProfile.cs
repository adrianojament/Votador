using api.domain.Dtos.Recurso;
using api.domain.Dtos.Usuario;
using api.domain.Dtos.Voto;
using api.domain.Entities;
using AutoMapper;

namespace api.crossCutting.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            _mappingUsuarios();
            _mappingRecursos();
            _mappingVotos();
        }

        private void _mappingVotos()
        {
            CreateMap<VotoEntity, VotoDto>().ReverseMap();
            CreateMap<VotoEntity, VotoDtoCreate>().ReverseMap();
            CreateMap<VotoEntity, VotoDtoUpdate>().ReverseMap();
        }

        private void _mappingRecursos()
        {
            CreateMap<RecursoEntity, RecursoDto>().ReverseMap();
            CreateMap<RecursoEntity, RecursoDtoCreate>().ReverseMap();
            CreateMap<RecursoEntity, RecursoDtoUpdate>().ReverseMap();
        }

        private void _mappingUsuarios()
        {
            CreateMap<UsuarioEntity, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioDtoCreate>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioDtoUpdate>().ReverseMap();
        }
    }
}
