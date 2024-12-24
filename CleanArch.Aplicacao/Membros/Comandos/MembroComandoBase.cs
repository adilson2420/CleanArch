using CleanArch.Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Aplicacao.Membros.Comandos
{
    public abstract class MembroComandoBase:IRequest<Membro>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public char Sexo { get; set; }
        public bool Activo { get; set; }
    }
}
