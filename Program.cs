using _15.Controllers;
using _15.Models;
using _15.Repositories;
using _15.Services;
using _15.View;

FuncionarioRepository repository = new FuncionarioRepository();

FuncionarioService service = new FuncionarioService(repository);

FuncionarioView view = new FuncionarioView();

FuncionarioController controller = new FuncionarioController(service, view);

controller.Iniciar();