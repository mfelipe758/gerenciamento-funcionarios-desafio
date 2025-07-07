using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15.Models
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public double Salario { get; set; }
        public string Cargo { get; set; }

        public Funcionario(){}
        public Funcionario(string nome, double salario, string cargo)
        {
            Nome = nome;
            Salario = salario;
            Cargo = cargo;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Funcionario outroFuncionario))
            {
                return false;
            }
            bool nomeIgual = StringComparer.OrdinalIgnoreCase.Equals(Nome, outroFuncionario.Nome);
            bool cargoIgual = StringComparer.OrdinalIgnoreCase.Equals(Cargo, outroFuncionario.Cargo);

            return nomeIgual && cargoIgual;
        }
        public override int GetHashCode()
        {        
            unchecked 
            {
                int hash = 17; 
                hash = hash * 23 + (Nome != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Nome) : 0);
                hash = hash * 23 + (Cargo != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Cargo) : 0);
                return hash;
            }
           
        }
    }
}