using api.data.Context;
using api.data.Repositories;
using api.domain.Entities;
using LanguageExt.UnitsOfMeasure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.data.test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact(DisplayName ="CRUD de Usuario")]
        [Trait("CRUD", "UsuarioEntity")]
        public async Task E_PossivelRealizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<VotosContext>())
            {
                UsuariosRepository usuariosRepository = new UsuariosRepository(context);
                UsuarioEntity entity = new UsuarioEntity()
                {
                    eMail = Faker.Internet.Email(),
                    Nome = Faker.Name.FullName(),
                    Senha = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10)
                };
                var newUsuario = await CriarUsuario(usuariosRepository, entity);
            
                entity.Id = newUsuario.Id;
                entity.Nome = Faker.Name.FullName();
                newUsuario = await E_PossivelRealizar_Insercao(usuariosRepository, entity);

                await E_Possivel_Procurar_Email(usuariosRepository, newUsuario);
                await Existe_Id(usuariosRepository, newUsuario);
                await Tem_Varios(usuariosRepository);

                await E_PossivelExcluir(usuariosRepository, newUsuario);                
            }
        }

        private async Task Tem_Varios(UsuariosRepository usuariosRepository)
        {
            var _registros = await usuariosRepository.SelectAsync();
            Assert.NotNull(_registros);
            Assert.True(_registros.Count() > 0);
        }

        private async Task Existe_Id(UsuariosRepository usuariosRepository, UsuarioEntity entity)
        {
            var _registro = await usuariosRepository.SelectAsync(entity.Id);
            Assert.NotNull(_registro);
            Assert.Equal(entity.eMail, _registro.eMail);
            Assert.Equal(entity.Senha, _registro.Senha);
            Assert.Equal(entity.Nome, _registro.Nome);
            Assert.False(entity.Id == Guid.Empty);
        }

        private async Task E_PossivelExcluir(UsuariosRepository usuariosRepository, UsuarioEntity newUsuario)
        {
            var sucesso = await usuariosRepository.DeleteAsync(newUsuario.Id);
            Assert.True(sucesso);
        }

        private async Task E_Possivel_Procurar_Email(UsuariosRepository usuariosRepository, UsuarioEntity entity)
        {
            var _registro = await usuariosRepository.getEmail(entity.eMail);
            Assert.NotNull(_registro);
            Assert.Equal(entity.eMail, _registro.eMail);
            Assert.Equal(entity.Senha, _registro.Senha);
            Assert.Equal(entity.Nome, _registro.Nome);
            Assert.False(entity.Id == Guid.Empty);
        }

        
        private async Task<UsuarioEntity> E_PossivelRealizar_Insercao(UsuariosRepository usuariosRepository, UsuarioEntity entity)
        {
            var _registroCriado = await usuariosRepository.UpdateAsync(entity);
            Assert.NotNull(_registroCriado);
            Assert.Equal(entity.eMail, _registroCriado.eMail);
            Assert.False(entity.Id == Guid.Empty);
            return _registroCriado;
        }
                

        private static async Task<UsuarioEntity> CriarUsuario(UsuariosRepository usuariosRepository, UsuarioEntity entity)
        {
            var _registro = await usuariosRepository.InsertAsync(entity);
            Assert.NotNull(_registro);
            Assert.Equal(entity.eMail, _registro.eMail);
            Assert.Equal(entity.Senha, _registro.Senha);
            Assert.False(entity.Id == Guid.Empty);
            return _registro;
        }
    }
}
