using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _15.Models;
using _15.Services;
using _15.View;

namespace _15.Controllers
{
    public class FuncionarioController
    {
        private readonly FuncionarioService _service;
        private readonly FuncionarioView _view;

        public FuncionarioController(FuncionarioService funcionarioService, FuncionarioView view)
        {
            _service = funcionarioService;
            _view = view;
        }
        public void Iniciar()
        {
            bool sair = false;
            while (!sair)
            {
                _view.ExibirMenu();
                int op = _view.LerOpcao();

                switch (op)
                {
                    case 1:
                        string nome = _view.PedirNome();
                        double salario = _view.PedirSalario();
                        string cargo = _view.PedirCargo();
                        _service.AdicionarFuncionario(nome, salario, cargo);
                        _view.ExibirMsg($"Funcionário {nome} adicionado com sucesso.");
                        break;
                    case 2:
                        List<Funcionario> funcionarios = _service.ListarFuncionarios();
                        if (funcionarios.Any())
                        {
                            _view.ListarFuncionarios(funcionarios);
                        }
                        else
                        {
                            _view.ExibirMsg($"Nenhum funcionário cadastrado.");
                        }
                        break;
                    case 3:
                        cargo = _view.PedirCargo();
                        funcionarios = _service.ListarFuncionariosCargo(cargo);

                        if (funcionarios.Any())
                        {
                            _view.ListarFuncionarios(funcionarios);
                        }
                        else
                        {
                            _view.ExibirMsg($"Nenhum funcionário cadastrado com o cargo '{cargo}'.");
                        }
                        break;
                    case 4:
                        nome = _view.PedirNome();
                        
                        _service.DeletarFuncionario(nome);
                        _view.ExibirMsg($"Funcionário {nome} removido com sucesso!");
                        
                        break;
                    case 5:
                        nome = _view.PedirNome();
                        double porcentagem = _view.PedirPorcentagem();
                        double salarioAtualizado = _service.AumentarSalario(nome, porcentagem);
                        _view.ExibirMsg($"Novo salário: {salarioAtualizado} reais.");
                        break;
                    case 6:
                        cargo = _view.PedirCargo();
                        double mediaSalarioCargo = _service.CalcularMediaSalarioCargo(cargo);
                        _view.ExibirMsg($"A média salárial do cargo de {cargo} é: {mediaSalarioCargo} reais.");
                        break;
                    case 7:
                        _view.ExibirMsg("Saindo do programa...");
                        sair = true;
                        
                        break;
                    default:
                        _view.ExibirMsg("Opção inválida. Tente novamente.");
                        break;
                }

                if (!sair)
                {
                    _view.PausarELimparTela();
                }
            }
        }


        
    }
}