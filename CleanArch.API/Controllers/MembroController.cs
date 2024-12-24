using CleanArch.Dominio.Abstracoes;
using CleanArch.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/v0/membros")]
    [ApiController]
    public class MembroController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public MembroController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> TodosMembros()
        {
            var membros = await _unitOfWork.MembroRepositorio.BuscarMembros();
            return Ok(membros);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMembro([FromBody] Membro membro)
        {
            var membros = await _unitOfWork.MembroRepositorio.AdicionarMembro(membro);
            return Ok(membros);
        }
    }
}
