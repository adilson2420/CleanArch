using CleanArch.Aplicacao.Membros.Comandos;
using CleanArch.Dominio.Abstracoes;
using CleanArch.Dominio.Entidades;
using MediatR;

namespace CleanArch.Aplicacao.Membros.Comandos
{
    public class CriarMembroComando : MembroComandoBase
    {
    }
}
public class CriarMembroComandoHandler : IRequestHandler<CriarMembroComando, Membro>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarMembroComandoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Membro> Handle(CriarMembroComando request, CancellationToken cancellationToken)
    {
        var novoMembro = new Membro(request.Nome, request.Email, request.Sexo, request.Activo);
        await _unitOfWork.MembroRepositorio.AdicionarMembro(novoMembro);
        await _unitOfWork.CommitAsync();

        return novoMembro;
    }
}

