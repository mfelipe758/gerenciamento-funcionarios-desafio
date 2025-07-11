using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _15.Models;
using _15.Repositories;

namespace _15.Services
{
    public class FuncionarioService
    {
        private readonly FuncionarioRepository _repository;
        public FuncionarioService(FuncionarioRepository repository)
        {
            _repository = repository;
        }
        public void AdicionarFuncionario(string nome, double salario, string cargo)
        {
            _repository.AdicionarFuncionario(new Funcionario(nome, salario, cargo));
        }
        public List<Funcionario> ListarFuncionarios()
        {
            return _repository.ListarFuncionarios();
            
        }
        public List<Funcionario> ListarFuncionariosCargo(string cargo)
        {
            List<Funcionario> funcionariosEncontrados =
            _repository.ListarFuncionariosCargo(cargo.ToLower());

            return funcionariosEncontrados;
            
        }
        public void DeletarFuncionario(string nome)
        {
            Funcionario? funcionarioRemover = _repository.BuscarFuncionarioPorNome(nome.ToLower());

            if (funcionarioRemover is not null)
            {
                _repository.DeletarFuncionario(funcionarioRemover);
            }
            else
            {
                throw new Exception($"Nenhum funcionário encontrado com o nome {nome}.");
            }
        }
         public double AumentarSalario(string nome, double porcentagem)
        {
            Funcionario? funcionario = _repository.BuscarFuncionarioPorNome(nome.ToLower());
            if (funcionario is not null)
            {
                double valorAumento = funcionario.Salario * (porcentagem / 100.0);
                funcionario.Salario += valorAumento;
                return funcionario.Salario;
            }
            else
            {
                throw new Exception($"Nenhum funcionário encontrado com o nome {nome}.");
            }
        }
        public Funcionario BuscarFuncionarioPorNome(string nome)
        {
            Funcionario? funcionario = _repository.BuscarFuncionarioPorNome(nome.ToLower());

            if (funcionario is not null)
            {
                return funcionario;
            }
            else
            {
                throw new Exception($"Nenhum funcionário encontrado com o nome {nome}.");
            }

        }
       
        public double CalcularMediaSalarioCargo(string cargo)
        {
            List<Funcionario>? funcionarios = _repository.ListarFuncionariosCargo(cargo.ToLower());

            if (funcionarios.Any())
            {
                double somaSalarios = 0;
                foreach (Funcionario funcionario in funcionarios)
                {
                    somaSalarios += funcionario.Salario;
                }
                    return somaSalarios / funcionarios.Count;
            }
            else
            {
                throw new InvalidOperationException($"Nenhum funcionário cadastrado com o cargo {cargo}.");
            }
        }
      
    }
}