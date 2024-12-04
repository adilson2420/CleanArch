using CleanArch.Dominio.Entidades;

namespace CleanArch.Dominio.Abstracoes
{
    public interface IMembroRepositorio
    {
        Task<IEnumerable<Membro>> BuscarTodos();
        Task<Membro> BuscarMembroPorId(int idMembro);
        Task<Membro> AdicionarMembro(Membro membro);
        Task<Membro> Atualizar(Membro membro);
        Task Eliminar(Membro membro);
    }
}
