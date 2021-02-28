using api.domain.Dtos.Usuario;
using api.domain.Dtos.Voto;
using api.domain.Entities;
using api.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.services.test.AutoMapper
{
    public class VotoMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possivel mapper os modelos")]
        public void E_Possivel_Mapper_Os_Modelos()
        {
            // VotoDtoCreate to VotoEntity
            var votoCreate = new VotoDtoCreate()
            {
                RecursoId = Guid.NewGuid(),
                UsuarioId = Guid.NewGuid(),
                Comentario = Faker.Lorem.Sentence(5)
            };
            var votoEntity = mapper.Map<VotoEntity>(votoCreate);
            Assert.NotNull(votoEntity);
            Assert.Equal(votoEntity.RecursoId, votoCreate.RecursoId);
            Assert.Equal(votoEntity.UsuarioId, votoCreate.UsuarioId);
            Assert.Equal(votoEntity.Comentario, votoCreate.Comentario);
            votoEntity.Id = Guid.NewGuid();
            votoEntity.CriadoEm = Helpers.GetDateTimeBrasilian();
            votoEntity.AtualizadoEm = Helpers.GetDateTimeBrasilian();

            // VotoEntity to VotoDtoCreateResult
            var votoCreateResult = mapper.Map<VotoDtoCreateResult>(votoEntity);
            Assert.NotNull(votoCreateResult);
            Assert.Equal(votoEntity.RecursoId, votoCreateResult.RecursoId);
            Assert.Equal(votoEntity.UsuarioId, votoCreateResult.UsuarioId);
            Assert.Equal(votoEntity.Comentario, votoCreateResult.Comentario);
            Assert.Equal(votoEntity.Id, votoCreateResult.Id);
            Assert.Equal(votoEntity.CriadoEm, votoCreateResult.CriadoEm);

            // VotoEntity to VotoDto
            var votoDto = mapper.Map<VotoDto>(votoEntity);
            Assert.NotNull(votoDto);
            Assert.Equal(votoDto.RecursoId, votoEntity.RecursoId);
            Assert.Equal(votoDto.UsuarioId, votoEntity.UsuarioId);
            Assert.Equal(votoDto.Comentario, votoEntity.Comentario);
            Assert.Equal(votoDto.Id, votoEntity.Id);
            Assert.Equal(votoDto.CriadoEm, votoEntity.CriadoEm);
            Assert.Equal(votoDto.AtualizadoEm, votoEntity.AtualizadoEm);
        }
    }
}
