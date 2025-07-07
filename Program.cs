using _15.Controllers;
using _15.Models;
using _15.Repositories;
using _15.Services;

FuncionarioRepository repository = new FuncionarioRepository();
FuncionarioService service = new FuncionarioService(repository);
FuncionarioController controller = new FuncionarioController(service);

controller.Iniciar();