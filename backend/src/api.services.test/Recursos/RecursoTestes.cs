using api.domain.Dtos.Recurso;
using api.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.services.test.Recursos
{
    public class RecursoTestes        
    {
        public static Guid IdRecurso = Guid.NewGuid();
        public static string Tarefa = Faker.Lorem.Sentence(2);
        public static DateTime CriadoEm = Helpers.GetDateTimeBrasilian();
        public static DateTime AtualizadoEm = Helpers.GetDateTimeBrasilian();
        public static string TarefaAlterado = Faker.Lorem.Sentence(2);

        public List<RecursoDto> listRecursosDto = new List<RecursoDto>();
        public RecursoDto recursoDto;
        public RecursoDtoCreate recursoDtoCreate;
        public RecursoDtoCreateResult recursoDtoCreateResult;
        public RecursoDtoUpdate recursoDtoUpdate;
        public RecursoDtoUpdateResult recursoDtoUpdateResult;

        public RecursoTestes()
        {
            for (int i = 0; i < 10; i++)
            {
                listRecursosDto.Add(new RecursoDto() { 
                    Id = Guid.NewGuid(),
                    Tarefa = Faker.Lorem.Sentence(2),
                    CriadoEm = Helpers.GetDateTimeBrasilian(),
                    AtualizadoEm = Helpers.GetDateTimeBrasilian()
                });
            }

            recursoDto = new RecursoDto()
            {
                Id = IdRecurso,
                Tarefa = Tarefa,
                CriadoEm = CriadoEm,
                AtualizadoEm = AtualizadoEm
            };

            recursoDtoCreate = new RecursoDtoCreate()
            {
                Tarefa = Tarefa,
            };

            recursoDtoCreateResult = new RecursoDtoCreateResult()
            {
                Id = IdRecurso,
                Tarefa = Tarefa,
                CriadoEm = CriadoEm              
            };

            recursoDtoUpdate = new RecursoDtoUpdate()
            {
                Id = IdRecurso,
                Tarefa = TarefaAlterado
            };

            recursoDtoUpdateResult = new RecursoDtoUpdateResult()
            {
                Id = IdRecurso,
                Tarefa = TarefaAlterado,                
                AtualizadoEm = AtualizadoEm
            };
        }
    }
}
