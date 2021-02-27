using api.data.Context;
using api.data.Repositories;
using api.domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.data.test
{
    public class RecursoCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public RecursoCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact(DisplayName = "CRUD de Recursos")]
        [Trait("CRUD", "RecursosEntity")]
        public async Task E_PossivelRealizar_CRUD()
        {
            using (var context = _serviceProvider.GetService<VotosContext>())
            {
                RecursosRepository repository = new RecursosRepository(context);
                RecursoEntity entity = new RecursoEntity()
                {
                    Tarefa = Faker.Lorem.Sentence(3)                    
                };
                var novoRegistro = await E_PossivelRealizar_Insercao(repository, entity);

                entity.Id = novoRegistro.Id;
                entity.Tarefa = Faker.Lorem.Sentence(3);
                novoRegistro = await E_PossivelRealizar_Atualizacao(repository, entity);
                                
                await Existe_Id(repository, novoRegistro);
                await Tem_Varios(repository);

                await E_PossivelExcluir(repository, novoRegistro);
            }
        }

        private async Task Tem_Varios(RecursosRepository usuariosRepository)
        {
            var _registros = await usuariosRepository.SelectAsync();
            Assert.NotNull(_registros);
            Assert.True(_registros.Count() > 0);
        }

        private async Task Existe_Id(RecursosRepository usuariosRepository, RecursoEntity entity)
        {
            var _registro = await usuariosRepository.SelectAsync(entity.Id);
            Assert.NotNull(_registro);
            Assert.Equal(entity.Tarefa, _registro.Tarefa);
            Assert.False(entity.Id == Guid.Empty);
        }

        private async Task E_PossivelExcluir(RecursosRepository repository, RecursoEntity entity)
        {
            var sucesso = await repository.DeleteAsync(entity.Id);
            Assert.True(sucesso);
        }

        private async Task<RecursoEntity> E_PossivelRealizar_Atualizacao(RecursosRepository repository, RecursoEntity entity)
        {
            var _registro = await repository.UpdateAsync(entity);
            Assert.NotNull(_registro);
            Assert.Equal(entity.Tarefa, _registro.Tarefa);
            Assert.False(entity.Id == Guid.Empty);
            return _registro;
        }

        private static async Task<RecursoEntity> E_PossivelRealizar_Insercao(RecursosRepository repository, RecursoEntity entity)
        {
            var _registro = await repository.InsertAsync(entity);
            Assert.NotNull(_registro);
            Assert.Equal(entity.Tarefa, _registro.Tarefa);            
            Assert.False(entity.Id == Guid.Empty);
            return _registro;
        }
    }
}
