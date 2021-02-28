using api.domain.Dtos.Validation;
using api.domain.Dtos.Voto;
using api.shared.Helpers;
using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.services.test.Voto
{
    public class VotosTeste
    {
        public List<VotoDtoContagem> contagemVotos = new List<VotoDtoContagem>();
        public VotoDtoCreate votoCreate;
        public VotoDtoCreateResult votoCreateResult;
        public VotoDtoRecepcao votoRecepcao;
        public DtoValidacao validacaoPositivo;
        public DtoValidacao validacaoNegativo;

        public VotosTeste()
        {
            for (int i = 0; i < 10; i++)
            {
                contagemVotos.Add(new VotoDtoContagem()
                {
                    IdRecurso = Guid.NewGuid(),
                    Qtd = RandomNumber.Next(1, 3),
                    Tarefa = Faker.Lorem.Sentence(2)
                });
            }

            votoRecepcao = new VotoDtoRecepcao()
            {
                eMail = Faker.Internet.Email(),
                Senha = Helpers.generatePassword(),
                IdRecurso = Guid.NewGuid(),               
                Comentario = Faker.Lorem.Sentence(5)
            };


            votoCreate = new VotoDtoCreate()
            {
                RecursoId = votoRecepcao.IdRecurso,
                UsuarioId = Guid.NewGuid(),
                Comentario = Faker.Lorem.Sentence(5)
            };

            votoCreateResult = new VotoDtoCreateResult()
            {
                Id = Guid.NewGuid(),
                RecursoId = votoRecepcao.IdRecurso,
                UsuarioId = votoCreate.UsuarioId,
                Comentario = votoCreate.Comentario
            };

            validacaoPositivo = new DtoValidacao()
            {
                Sucesso = true,
            };

            validacaoNegativo = new DtoValidacao()
            {
                Sucesso = false,
                Mensagem = Faker.Lorem.Sentence(5)
            };


        }
    }
}
