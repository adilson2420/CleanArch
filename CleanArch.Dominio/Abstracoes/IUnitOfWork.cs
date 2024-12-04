using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Dominio.Abstracoes
{
    public interface IUnitOfWork
    {
        IMembroRepositorio MembroRepositorio { get; }
        Task CommitAsync();
    }
}
