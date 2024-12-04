using CleanArch.Dominio.Abstracoes;
using CleanArch.Dominio.Entidades;
using CleanArch.Infrastutura.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastutura.Repositories
{
    internal class MembroRepositorio : IMembroRepositorio
    {
        protected readonly AppDbContext _db;

        public MembroRepositorio(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Membro> AdicionarMembro(Membro membro)
        {
            if (membro is null)
                throw new ArgumentNullException(nameof(membro));
            await _db.Membros.AddAsync(membro);
            return membro;
        }

        public void Atualizar(Membro membro)
        {
            if (membro is null)
                throw new ArgumentNullException(nameof(membro));
            _db.Membros.Update(membro);
        }

        public async Task<Membro> BuscarMembroPorId(int idMembro)
        {
            var membro = await _db.Membros.FindAsync(idMembro);
            if (membro is null)
                throw new InvalidOperationException("Membro não encontrado");
            return membro;
        }

        public async Task<IEnumerable<Membro>> BuscarMembros()
        {
            var membros = await _db.Membros.ToListAsync();
            return membros ?? Enumerable.Empty<Membro>();
        }

        public async Task<Membro> EliminarMembro(int idMembro)
        {
            var membro = await BuscarMembroPorId(idMembro);
            if (membro is null)
                throw new InvalidOperationException("membro não encontrado");

            _db.Membros.Remove(membro);
            return membro;
        }
    }
}
