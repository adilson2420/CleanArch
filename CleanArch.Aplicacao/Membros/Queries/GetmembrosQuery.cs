using CleanArch.Dominio.Abstracoes;
using CleanArch.Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplicacao.Membros.Queries
{
    public class GetmembrosQuery : IRequest<IEnumerable<Membro>>
    {
        public class GetmembrosQueryhandler : IRequestHandler<GetmembrosQuery, IEnumerable<Membro>>
        {
            private readonly IMembroDapperRepositorio _membroDapperRepositorio;

            public GetmembrosQueryhandler(IMembroDapperRepositorio membroDapperRepositorio)
            {
                _membroDapperRepositorio = membroDapperRepositorio;
            }

            public async Task<IEnumerable<Membro>> Handle(GetmembrosQuery request, CancellationToken cancellationToken)
            {
                var membros = await _membroDapperRepositorio.Membros();
                return membros;
            }
        }
    }
}
