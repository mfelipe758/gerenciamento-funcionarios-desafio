using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using _15.Models;

namespace _15.View
{
    public class FuncionarioView
    {
        public void ExibirMenu()
        {
            Console.WriteLine("\n--- Menu do Banco ---");
            Console.WriteLine("[1] - Adicionar Funcionário");
            Console.WriteLine("[2] - Listar Funcionários");
            Console.WriteLine("[3] - Listar Funcionários por Cargo");
            Console.WriteLine("[4] - Deletar Funcionário");
            Console.WriteLine("[5] - Aumentar Salário (por nome)");
            Console.WriteLine("[6] - Calcular Média Salarial por Cargo");
            Console.WriteLine("[7] - Sair");
            Console.Write("Escolha uma opção: ");
        }
        public int LerOpcao()
        {
            string? inputOp = Console.ReadLine();
            if (int.TryParse(inputOp, out int op))
            {
                return op;
            }
            Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            return -1;
        }
        public string PedirNome()
        {
            string? nome;
            while (true)
            {
                Console.WriteLine("Informe o nome:");
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    return nome;
                }
                else
                {
                    Console.WriteLine("O nome não pode ser vazio ou conter apenas espaços. Por favor, digite um nome válido.");
                }
            }

        }
        public string PedirCargo()
        {
            string? cargo;
            while (true)
            {
                Console.WriteLine("Informe o cargo:");
                cargo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(cargo))
                {
                    return cargo;
                }
                else
                {
                    Console.WriteLine("O cargo não pode ser vazio ou conter apenas espaços. Por favor, digite um nome válido.");
                }
            }
        }
        public double PedirSalario()
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
        public void PausarELimparTela()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public void ExibirMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        
        public void ListarFuncionarios(List<Funcionario> funcionarios)
        {
            Console.WriteLine("\n--- Lista de Funcionários ---");
            foreach (Funcionario funcionario in funcionarios)
            {
                Console.WriteLine($"Funcionário: {funcionario.Nome} | Cargo: {funcionario.Cargo}");
            }
            Console.WriteLine("----------------------------------\n");
        }
    }
}