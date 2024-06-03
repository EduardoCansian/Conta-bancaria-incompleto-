using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class Conta
    {
        private int senha;

        public int Senha
        {
            get { return senha; }
            set
            {
                if (value.ToString().Length == 4)
                {
                    senha = value;
                }
                else
                {
                    throw new Exception("A senha deve conter 4 dígitos");
                }
            }
        }

        private double saldo;

        public double Saldo { get; set; }

        public bool VerificarSenha(int senha)
        {
            return Senha == senha;
        }

    }
}
