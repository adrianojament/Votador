using api.domain.Dtos.Validation;
using api.domain.Dtos.Voto;
using api.domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api.apllication.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly IVotosServices _service;

        public VotoController(IVotosServices service)
        {
            _service = service;
        }

        [HttpGet("ListarVotos")]
        [ProducesResponseType(typeof(VotoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("ContarVotos")]
        [ProducesResponseType(typeof(VotoDtoContagem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ContarVotos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.ContarVotos());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("VotarItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Votar([FromBody] VotoDtoRecepcao votoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.ValidationInsert(votoDto);
                if (!result.Sucesso)
                {
                    return BadRequest(result);
                }
                
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                var validacao = new DtoValidacao();
                validacao.Sucesso = false;
                validacao.Mensagem = e.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, validacao);
            }

        }
    }
}
