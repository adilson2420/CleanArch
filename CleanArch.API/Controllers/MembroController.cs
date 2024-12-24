using CleanArch.Aplicacao.Membros.Comandos;
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

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public MembroController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet] // consulta
        public async Task<IActionResult> TodosMembros()
        {
            var membros = await _unitOfWork.MembroRepositorio.BuscarMembros();
            return Ok(membros);
        }

        [HttpGet("idMembro")] // consulta
        public async Task<IActionResult> MembroPorId(int idMembro)
        {
            var membro = await _unitOfWork.MembroRepositorio.BuscarMembroPorId(idMembro);
            return Ok(membro);
        }

        [HttpPost] // comando
        public async Task<IActionResult> AdicionarMembro(CriarMembroComando comando)
        {
            var criarMembro = await _mediator.Send(comando);
            return CreatedAtAction(nameof(MembroPorId), new { id = criarMembro.Id }, criarMembro);
        }
    }
}
