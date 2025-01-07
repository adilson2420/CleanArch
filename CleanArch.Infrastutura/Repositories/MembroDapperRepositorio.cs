using CleanArch.Dominio.Abstracoes;
using CleanArch.Dominio.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastutura.Repositories
{
    public class MembroDapperRepositorio : IMembroDapperRepositorio
    {
        private readonly IDbConnection _dbConnection;
        public MembroDapperRepositorio(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Membro> MembroPorId(int id)
        {
            string query = "SELECT * FROM Membros where Id=@id";
            var membro = await _dbConnection.QueryFirstOrDefaultAsync<Membro>(query, new { Id = id });
            return membro;
        }

        public async Task<IEnumerable<Membro>> Membros()
        {
            string query = "SELECT * FROM Membros";
            return await _dbConnection.QueryAsync<Membro>(query);
        }
    }
}
