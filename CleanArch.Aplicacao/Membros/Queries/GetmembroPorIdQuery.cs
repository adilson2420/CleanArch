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
    public class GetmembroPorIdQuery : IRequest<Membro>
    {
        public int Id { get; set; }
        public class GetmembroPorIdQueryhandler : IRequestHandler<GetmembroPorIdQuery, Membro>
        {
            private readonly IMembroDapperRepositorio _membroDapperRepositorio;

            public GetmembroPorIdQueryhandler(IMembroDapperRepositorio membroDapperRepositorio)
            {
                _membroDapperRepositorio = membroDapperRepositorio;
            }

            public async Task<Membro> Handle(GetmembroPorIdQuery request, CancellationToken cancellationToken)
            {
                var membro = await _membroDapperRepositorio.MembroPorId(request.Id);
                return membro;
            }
        }
    }
}
