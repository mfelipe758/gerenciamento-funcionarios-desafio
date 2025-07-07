using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _15.Services;

namespace _15.Controllers
{
    public class FuncionarioController
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
        public void Iniciar()
        {
            bool sair = false;
            while (!sair)
            {
                ExibirMenu();
                int op = LerOpcao();

                switch (op)
                {
                    case 1:
                        _funcionarioService.AdicionarFuncionario();
                        break;
                    case 2:
                        _funcionarioService.ListarFuncionarios();
                        break;
                    case 3:
                        _funcionarioService.ListarFuncionariosCargo();
                        break;
                    case 4:
                        _funcionarioService.DeletarFuncionario();
                        break;
                    case 5:
                        _funcionarioService.AumentarSalario();
                        break;
                    case 6:
                        _funcionarioService.CalcularMediaSalarioCargo();
                        break;
                    case 7:
                        sair = true;
                        Console.WriteLine("Saindo do programa. Até mais!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void ExibirMenu()
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

        private int LerOpcao()
        {
            string? inputOp = Console.ReadLine();
            if (int.TryParse(inputOp, out int op))
            {
                return op;
            }
            Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            return -1;
        }
    }
}