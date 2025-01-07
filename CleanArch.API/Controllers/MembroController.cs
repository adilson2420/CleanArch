using CleanArch.Aplicacao.Membros.Comandos;
using CleanArch.Aplicacao.Membros.Queries;
using CleanArch.Dominio.Abstracoes;
using CleanArch.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/v1/membros")]
    [ApiController]
    public class MembroController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MembroController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] // consulta
        public async Task<IActionResult> TodosMembros()
        {
            var query = new GetmembrosQuery();
            var membros = await _mediator.Send(query);
            return Ok(membros);
        }

        [HttpGet("idMembro")] // consulta
        public async Task<IActionResult> MembroPorId(int idMembro)
        {
            var query = new GetmembroPorIdQuery()
            {
                Id = idMembro
            };
            var membro = await _mediator.Send(query);
            return Ok(membro);
        }

        [HttpPost] // comando
        public async Task<IActionResult> AdicionarMembro(CriarMembroComando comando)
        {
            var criarMembro = await _mediator.Send(comando);
            return CreatedAtAction(nameof(MembroPorId), new { id = criarMembro.Id }, criarMembro);
        }
        [HttpPut] // comando
        public async Task<IActionResult> AtualizarMembro(AtualizarMembroComando comando)
        {
            var membro = await _mediator.Send(comando);
            return membro != null ? Ok(membro) : BadRequest("membro inválido");
        }
    }
}

// Realizar a implementação do update delete e consulta por ID, sem conexao com a internet. 