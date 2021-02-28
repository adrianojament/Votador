using api.data.Context;
using api.data.Repositories;
using api.domain.Entities;
using api.shared.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.data.test
{
    public class VotoCRUDCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public VotoCRUDCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "VotoEntity")]
        public async Task E_PossivelRealizar_CRUD_Votos()
        {
            using (var context = _serviceProvider.GetService<VotosContext>())
            {
                RecursosRepository recursosRepository  = new RecursosRepository(context);
                RecursoEntity recursoEntity = new RecursoEntity()
                {
                    Tarefa = Faker.Lorem.Sentence(3)
                };
                recursoEntity = await recursosRepository.InsertAsync(recursoEntity);

                UsuariosRepository usuariosRepository = new UsuariosRepository(context);
                UsuarioEntity usuarioEntity = new UsuarioEntity()
                {
                    eMail = Faker.Internet.Email(),
                    Nome = Faker.Name.FullName(),
                    Senha = Helpers.generatePassword()
                };
                usuarioEntity = await usuariosRepository.InsertAsync(usuarioEntity);

                var comentario = Faker.Lorem.Sentence(4);
                VotosRepository votosRepository = new VotosRepository(context);
                VotoEntity votoEntity = new VotoEntity() {
                    RecursoId = recursoEntity.Id,
                    UsuarioId = usuarioEntity.Id,
                    Comentario = comentario
                };
                var newVoto = await votosRepository.InsertAsync(votoEntity);
                Assert.NotNull(newVoto);
                Assert.Equal(newVoto.RecursoId, votoEntity.RecursoId);
                Assert.Equal(newVoto.UsuarioId, votoEntity.UsuarioId);
                Assert.Equal(newVoto.Comentario, votoEntity.Comentario);
                Assert.False(newVoto.Id == Guid.Empty);
            }
        }
    }
}
