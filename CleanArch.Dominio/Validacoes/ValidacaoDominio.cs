using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Dominio.Validacoes
{
    public class ValidacaoDominio : Exception
    {
        public ValidacaoDominio(string erro) :base(erro) { }

        public static void Quando(bool hasErro, string erro)
        {
            if (hasErro) 
                throw new ValidacaoDominio(erro);
        }
    }
}
