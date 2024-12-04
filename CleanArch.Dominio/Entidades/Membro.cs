using CleanArch.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanArch.Dominio.Entidades
{
    public sealed class Membro : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public char Sexo { get; private set; }
        public bool Activo { get; private set; }
        public Membro()
        {
        }
        public Membro(string nome, string email, char sexo, bool activo) => ValidacaoMembro(nome, email, sexo, activo);

        [JsonConstructor]
        public Membro(int id, string nome, string email, char sexo, bool activo)
        {
            ValidacaoDominio.Quando(id < 0, "id inválido");
            Id = id;
            ValidacaoMembro(nome, email, sexo, activo);
        }



        private void Atualizar(string nome, string email, char sexo, bool activo)
        {
            ValidacaoMembro(nome, email, sexo, activo);
        }

        private void ValidacaoMembro(string nome, string email, char sexo, bool activo)
        {
            ValidacaoDominio.Quando(string.IsNullOrEmpty(nome), "Nome inválido, o Nome é obrigatório!");
            ValidacaoDominio.Quando(nome.Length < 3, "Nome inválido, O nome deve ter no mínimo 3 caracters!");
            ValidacaoDominio.Quando(email.Length > 250, "Email inválido, máximo 250 caracters!");

            Nome = nome;
            Email = email;
            Sexo = sexo;
            Activo = activo;
        }
    }
}
