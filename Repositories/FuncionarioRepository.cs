using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _15.Models;

namespace _15.Repositories
{
    public class FuncionarioRepository
    {
        private readonly List<Funcionario> funcionarios = new List<Funcionario>();

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
        }
        public List<Funcionario> ListarFuncionarios()
        {
            return funcionarios;
        }
        public List<Funcionario> ListarFuncionariosCargo(string cargo)
        {
            return funcionarios.Where(f => f.Cargo.ToLower() == cargo).ToList();
        }
        public void DeletarFuncionario(Funcionario funcionario)
        {
            funcionarios.Remove(funcionario);
        }
        public Funcionario? BuscarFuncionarioPorNome(string nome)
        {
            return funcionarios.Find(f => f.Nome.ToLower() == nome);
        }
    }
}