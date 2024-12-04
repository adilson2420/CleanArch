using CleanArch.Dominio.Abstracoes;
using CleanArch.Infrastutura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastutura.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IMembroRepositorio? _membroRepo;
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public IMembroRepositorio MembroRepositorio { get { return _membroRepo = _membroRepo ?? new MembroRepositorio(_db); } }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
