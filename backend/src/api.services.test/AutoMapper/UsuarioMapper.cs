using api.domain.Dtos.Usuario;
using api.domain.Entities;
using api.shared.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.services.test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possivel mapper os modelos")]
        public void E_Possivel_Mapper_Os_Modelos()
        {
            var usuarioDto = new UsuarioDto()
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Name.FullName(),
                Senha = Helpers.generatePassword(),
                eMail = Faker.Internet.Email(),
                CriadoEm = Helpers.GetDateTimeBrasilian(),
                AtualizadoEm = Helpers.GetDateTimeBrasilian()
            };

            List<UsuarioEntity> listaEntity = new List<UsuarioEntity>();
            for (int i = 0; i < 10; i++)
            {
                listaEntity.Add(new UsuarioEntity()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Senha = Helpers.generatePassword(),
                    eMail = Faker.Internet.Email(),
                    CriadoEm = Helpers.GetDateTimeBrasilian(),
                    AtualizadoEm = Helpers.GetDateTimeBrasilian()
                });
            }

            // -> Dto to Entity
            var dtoToEntity = mapper.Map<UsuarioEntity>(usuarioDto);
            Assert.Equal(dtoToEntity.Id, usuarioDto.Id);
            Assert.Equal(dtoToEntity.Nome, usuarioDto.Nome);
            Assert.Equal(dtoToEntity.eMail, usuarioDto.eMail);
            Assert.Equal(dtoToEntity.Senha, usuarioDto.Senha);
            Assert.Equal(dtoToEntity.CriadoEm, usuarioDto.CriadoEm);
            Assert.Equal(dtoToEntity.AtualizadoEm, usuarioDto.AtualizadoEm);

            // -> Entity to Dto
            var usuarioDtoMapper = mapper.Map<UsuarioDto>(dtoToEntity);
            Assert.Equal(dtoToEntity.Id, usuarioDtoMapper.Id);
            Assert.Equal(dtoToEntity.Nome, usuarioDtoMapper.Nome);
            Assert.Equal(dtoToEntity.eMail, usuarioDtoMapper.eMail);
            Assert.Equal(dtoToEntity.Senha, usuarioDtoMapper.Senha);
            Assert.Equal(dtoToEntity.CriadoEm, usuarioDtoMapper.CriadoEm);
            Assert.Equal(dtoToEntity.AtualizadoEm, usuarioDtoMapper.AtualizadoEm);

            // -> List Entity to List Dto
            var listaDto = mapper.Map<List<UsuarioDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].eMail, listaEntity[i].eMail);
                Assert.Equal(listaDto[i].Senha, listaEntity[i].Senha);
                Assert.Equal(listaDto[i].CriadoEm, listaEntity[i].CriadoEm);
                Assert.Equal(listaDto[i].AtualizadoEm, listaEntity[i].AtualizadoEm);
            }

            // UsuarioDtoCreate para UsuarioEntity
            var usuarioDtoCreate = new UsuarioDtoCreate() {
                Nome = Faker.Name.FullName(),
                Senha = Helpers.generatePassword(),
                eMail = Faker.Internet.Email(),
            };
            var usuarioEntity = mapper.Map<UsuarioEntity>(usuarioDtoCreate);
            Assert.Equal(usuarioEntity.Nome, usuarioDtoCreate.Nome);
            Assert.Equal(usuarioEntity.eMail, usuarioDtoCreate.eMail);
            Assert.Equal(usuarioEntity.Senha, usuarioDtoCreate.Senha);

            // UsuarioEntity para UsuarioDtoCreateResult
            var usuarioDtoCreateResult = mapper.Map<UsuarioEntity>(usuarioEntity);
            Assert.Equal(usuarioEntity.Nome, usuarioDtoCreateResult.Nome);
            Assert.Equal(usuarioEntity.eMail, usuarioDtoCreateResult.eMail);
            Assert.Equal(usuarioEntity.Senha, usuarioDtoCreateResult.Senha);


            // UsuarioDtoUpdate para UsuarioEntity
            var usuarioDtoUpdate = new UsuarioDtoUpdate()
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Name.FullName(),
                Senha = Helpers.generatePassword(),
                eMail = Faker.Internet.Email(),
            };
            var usuarioUpdateEntity = mapper.Map<UsuarioEntity>(usuarioDtoUpdate);
            Assert.Equal(usuarioUpdateEntity.Id, usuarioDtoUpdate.Id);
            Assert.Equal(usuarioUpdateEntity.Nome, usuarioDtoUpdate.Nome);
            Assert.Equal(usuarioUpdateEntity.eMail, usuarioDtoUpdate.eMail);
            Assert.Equal(usuarioUpdateEntity.Senha, usuarioDtoUpdate.Senha);

            //UsuarioEntity para UsuarioDtoUpdateResult
            var usuarioUpdateResult = mapper.Map<UsuarioDtoUpdateResult>(usuarioUpdateEntity);
            Assert.Equal(usuarioUpdateEntity.Id, usuarioUpdateResult.Id);
            Assert.Equal(usuarioUpdateEntity.Nome, usuarioUpdateResult.Nome);
            Assert.Equal(usuarioUpdateEntity.eMail, usuarioUpdateResult.eMail);
            Assert.Equal(usuarioUpdateEntity.Senha, usuarioUpdateResult.Senha);

        }
    }
}
