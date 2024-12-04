using CleanArch.Dominio.Entidades;

namespace CleanArch.Dominio.Abstracoes
{
    public interface IMembroRepositorio
    {
        Task<IEnumerable<Membro>> BuscarMembros();
        Task<Membro> BuscarMembroPorId(int idMembro);
        Task<Membro> AdicionarMembro(Membro membro);
        void Atualizar(Membro membro);
        Task<Membro> EliminarMembro(int idMembro);
    }
}


