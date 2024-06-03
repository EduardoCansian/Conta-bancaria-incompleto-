using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class Pessoa : Conta
    {
        private long cpf;

        private int telefone;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public long Cpf
        {
            get { return cpf; }
            set
            {
                if(value.ToString().Length == 11)
                {
                    cpf = value;
                }
                else
                {
                    throw new Exception("O CPF deve conter 11 dígitos.");
                }
            }
        }

        public int Telefone { get; set; }
        public string Email { get; set; }
        public DateOnly DataNascimento { get; set; }

        public Pessoa()
        {
            this.Saldo = 0;
        }

        public Pessoa(string nome, string sobrenome, long cpf, DateOnly data, int telefone, string email, int senha)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Cpf = cpf;
            this.DataNascimento = data;
            this.Telefone = telefone;
            this.Email = email;
            this.Senha = senha;
        }

        public string ObterDados()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("---------------------------");
            sb.Append($"\nNome completo: {this.Nome} {this.Sobrenome}");
            sb.Append($"\nCpf: {this.Cpf}");
            sb.Append($"\nData de nascimento: {this.DataNascimento}");
            sb.Append($"\nTelefone: (28) {this.Telefone}");
            sb.Append($"\nEmail: {this.Email}");
            sb.Append($"\nSenha: {this.Senha}");
            return sb.ToString();
        }

        public string Resumo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("--------------------");
            sb.Append($"\nNome: {this.Nome} {this.Sobrenome}");
            sb.Append($"\nSaldo: R$ {this.Saldo:F2}");
            sb.Append($"\nSenha: {this.Senha}");
            return sb.ToString();
        }

    }
}
