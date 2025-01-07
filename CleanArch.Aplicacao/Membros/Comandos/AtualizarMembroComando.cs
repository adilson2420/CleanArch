using CleanArch.Aplicacao.Membros.Comandos;
using CleanArch.Dominio.Abstracoes;
using CleanArch.Dominio.Entidades;
using MediatR;

namespace CleanArch.Aplicacao.Membros.Comandos
{
    public class AtualizarMembroComando : MembroComandoBase
    {
        public int Id { get; set; }
        public class AtualizarMembroComandoHandler : IRequestHandler<AtualizarMembroComando, Membro>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMembroDapperRepositorio _membroDapper;

            public AtualizarMembroComandoHandler(IUnitOfWork unitOfWork, IMembroDapperRepositorio membroDapper)
            {
                _unitOfWork = unitOfWork;
                _membroDapper = membroDapper;
            }

            public async Task<Membro> Handle(AtualizarMembroComando request, CancellationToken cancellationToken)
            {
                var membroResponse = await _membroDapper.MembroPorId(request.Id);
                if (membroResponse == null)
                    throw new InvalidOperationException("Membro não existe");
                membroResponse.Atualizar(request.Nome, request.Email, request.Sexo, request.Activo);
                _unitOfWork.MembroRepositorio.Atualizar(membroResponse);
                await _unitOfWork.CommitAsync();

                return membroResponse;
            }
        }
    }
}


