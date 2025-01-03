using CleanArch.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Dominio.Abstracoes
{
    public interface IMembroDapperRepositorio
    {
        Task<IEnumerable<Membro>> Membros();
        Task<Membro> MembroPorId(int id);
    }
}
