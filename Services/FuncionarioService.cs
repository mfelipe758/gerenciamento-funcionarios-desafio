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
        public void AdicionarFuncionario()
        {
            string nome = PedirONome();
            double salario = PedirOSalario();
            string cargo = PedirOCargo();

            _repository.AdicionarFuncionario(new Funcionario(nome, salario, cargo));
            Console.WriteLine($"Funcionario {nome} adicionado com sucesso.");
        }
        public void ListarFuncionarios()
        {
            List<Funcionario> funcionariosEncontrados = _repository.ListarFuncionarios();
            if (funcionariosEncontrados.Any())
            {
                Console.WriteLine("\n--- Lista de Funcionários ---");
                foreach (Funcionario funcionario in funcionariosEncontrados)
                {
                    Console.WriteLine($"Funcionario: {funcionario.Nome} | Cargo: {funcionario.Cargo}");
                }
                Console.WriteLine("---------------------------\n");
            }
            else
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
            }
        }
        public void ListarFuncionariosCargo()
        {
            string cargo = PedirOCargo();
            List<Funcionario> funcionariosEncontrados =
            _repository.ListarFuncionariosCargo(cargo);

            Console.WriteLine($"\n--- Funcionários com Cargo: {cargo} ---");
            if (funcionariosEncontrados.Any())
            {
                foreach (Funcionario funcionario in funcionariosEncontrados)
                {
                    Console.WriteLine($"Funcionario: {funcionario.Nome} | Cargo: {funcionario.Cargo}");
                }
                Console.WriteLine("----------------------------------\n");
            }
            else
            {
                Console.WriteLine($"Nenhum funcionário encontrado com o cargo '{cargo}'.");
            }
        }
        public void DeletarFuncionario()
        {
            ListarFuncionarios();
            string nome = PedirONome();
            Funcionario? funcionarioRemover = _repository.BuscarFuncionarioPorNome(nome);
            if (funcionarioRemover is not null)
            {
                _repository.DeletarFuncionario(funcionarioRemover);
                Console.WriteLine($"Funcionario {funcionarioRemover.Nome} removido com sucesso!");
            }
            else
            {
                Console.WriteLine($"Funcionário '{nome}' não encontrado.");
            }
        }
        public void BuscarFuncionarioPorNome()
        {
            string nome = PedirONome();
            Funcionario? funcionario = _repository.BuscarFuncionarioPorNome(nome);
            if (funcionario is not null)
            {
                Console.WriteLine($"Funcionario: {funcionario.Nome} | Cargo: {funcionario.Cargo}");
            }
            else
            {
                Console.WriteLine($"Funcionário '{nome}' não encontrado.");
            }

        }
        public void AumentarSalario()
        {
            ListarFuncionarios();
            string nome = PedirONome();
            double porcentagem = PedirPorcentagem();
            Funcionario? funcionario = _repository.BuscarFuncionarioPorNome(nome);
            if (funcionario is not null)
            {
                double valorAumento = funcionario.Salario * (porcentagem / 100.0);
                funcionario.Salario += valorAumento;
                Console.WriteLine($"Novo salário: {funcionario.Salario} reais.");
            }
            else
            {
                Console.WriteLine($"Funcionário '{nome}' não encontrado.");
            }
        }
        public void CalcularMediaSalarioCargo()
        {
            string cargo = PedirOCargo();
            List<Funcionario>? funcionarios = _repository.ListarFuncionariosCargo(cargo);

            if (funcionarios.Any())
            {
                double somaSalarios = 0;
                foreach (Funcionario funcionario in funcionarios)
                {
                    somaSalarios += funcionario.Salario;
                }
                Console.WriteLine($"A média salárial do cargo de {cargo} é: {somaSalarios / funcionarios.Count} reais.");
            }
        }
        public string PedirONome()
        {
            string? nome;
            while (true)
            {
                Console.WriteLine("Informe o nome:");
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    return nome.ToLower();
                }
                else
                {
                    Console.WriteLine("O nome não pode ser vazio ou conter apenas espaços. Por favor, digite um nome válido.");
                }
            }

        }
        public string PedirOCargo()
        {
            string? cargo;
            while (true)
            {
                Console.WriteLine("Informe o cargo:");
                cargo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(cargo))
                {
                    return cargo.ToLower();
                }
                else
                {
                    Console.WriteLine("O cargo não pode ser vazio ou conter apenas espaços. Por favor, digite um nome válido.");
                }
            }
        }
        public double PedirOSalario()
        {
            while (true)
            {
                Console.WriteLine("Informe o salário:");
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double salario) && salario >= 0)
                {
                    return salario;
                }
                Console.WriteLine("Entrada inválida. Por favor, digite um valor numérico válido e não negativo.");
            }
        }
        public double PedirPorcentagem()
        {
            while (true)
            {
                Console.WriteLine("Informe a porcentagem de aumento:");
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double porcentagem) && porcentagem >= 0)
                {
                    return porcentagem;
                }
                Console.WriteLine("Entrada inválida. Por favor, digite um valor numérico válido e não negativo.");
            }
        }
    }
}