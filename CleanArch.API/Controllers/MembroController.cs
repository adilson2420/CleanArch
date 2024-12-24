using CleanArch.Dominio.Abstracoes;
using CleanArch.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/v1/membros")]
    [ApiController]
    public class MembroController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public MembroController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet] // consulta
        public async Task<IActionResult> TodosMembros()
        {
            var membros = await _unitOfWork.MembroRepositorio.BuscarMembros();
            return Ok(membros);
        }

        [HttpGet("idMembro")] // consulta
        public async Task<IActionResult> TodosMembros(int idMembro)
        {
            var membro = await _unitOfWork.MembroRepositorio.BuscarMembroPorId(idMembro);
            return Ok(membro);
        }

        [HttpPost] // comando
        public async Task<IActionResult> AdicionarMembro([FromBody] Membro membro)
        {
            var resposta = await _unitOfWork.MembroRepositorio.AdicionarMembro(membro);
            return Ok(resposta);
        }
    }
}
