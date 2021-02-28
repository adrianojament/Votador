using api.domain.Dtos.Usuario;
using api.domain.Dtos.Usuario.Standard;
using api.domain.Dtos.Validation;
using api.shared.Helpers;
using System;
using System.Collections.Generic;

namespace api.services.test.Usuario
{
    public class UsuarioTestes
    {
        public static Guid IdUsuario { get; set; }
        public static string NomeUsuario { get; set; }
        public static string SenhaUsuario { get; set; }
        public static string eMailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string SenhaUsuarioAlterado { get; set; }

        public List<UsuarioDto> listaUsuariosDto = new List<UsuarioDto>();
        public UsuarioDto usuarioDto;
        public UsuarioDtoCreate usuarioDtoCreate;
        public UsuarioDtoCreateResult usuarioDtoCreateResult;
        public UsuarioDtoUpdate usuarioDtoUpdate;
        public UsuarioDtoUpdateResult usuarioDtoUpdateResult;
        public UsuarioDtoVoto usuarioDtoVoto;
        public DtoValidacao validacaoPositivo;
        public DtoValidacao validacaoNegativo;

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            SenhaUsuario = Helpers.generatePassword();
            eMailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            SenhaUsuarioAlterado = Helpers.generatePassword();

            for (int i = 0; i < 10; i++)
            {
                listaUsuariosDto.Add(new UsuarioDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Senha = Helpers.generatePassword(),
                    eMail = Faker.Internet.Email(),
                    CriadoEm = Helpers.GetDateTimeBrasilian(),
                    AtualizadoEm = Helpers.GetDateTimeBrasilian()
                });
            }

            usuarioDto = new UsuarioDto()
            {
                Id = IdUsuario,
                Nome = NomeUsuario,
                Senha = SenhaUsuario,
                eMail = eMailUsuario
            };
            
            usuarioDtoCreate = new UsuarioDtoCreate()
            {              
                Nome = NomeUsuario,
                Senha = SenhaUsuario,
                eMail = eMailUsuario
            };

            usuarioDtoCreateResult = new UsuarioDtoCreateResult()
            {
                Id = IdUsuario,
                Nome = NomeUsuario,
                Senha = SenhaUsuario,
                eMail = eMailUsuario,
                CriadoEm = Helpers.GetDateTimeBrasilian(),
            };

            usuarioDtoUpdate = new UsuarioDtoUpdate()
            {
                Id = IdUsuario,
                Nome = NomeUsuarioAlterado,
                Senha = SenhaUsuarioAlterado,
                eMail = eMailUsuario
            };

            usuarioDtoUpdateResult = new UsuarioDtoUpdateResult()
            {
                Id = IdUsuario,
                Nome = NomeUsuarioAlterado,
                Senha = SenhaUsuarioAlterado,
                eMail = eMailUsuario,
                AtualizadoEm = Helpers.GetDateTimeBrasilian(),
            };

            usuarioDtoVoto = new UsuarioDtoVoto()
            {
                Id = IdUsuario,
                Nome = NomeUsuario,
                eMail = eMailUsuario
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
