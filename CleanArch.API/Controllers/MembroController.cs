using CleanArch.Dominio.Abstracoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
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
    }
}
