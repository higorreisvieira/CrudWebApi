using CrudWebApi.Models;
using CrudWebApi.Service.FuncionarioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebApi.Controllers
{
	// Esta é a parte do código que lida com pedidos relacionados a funcionários na web
	[Route("api/[controller]")]
	[ApiController]
	public class FuncionarioController : ControllerBase
	{
		// Aqui declaramos um jeito de falar com os dados dos funcionários
		private readonly IFuncionarioInterface _funcionarioInterface;

		// Ao iniciar o controlador, damos a ele uma maneira de falar com os dados dos funcionários
		public FuncionarioController(IFuncionarioInterface funcionarioInterface)
		{
			// Atribui a interface recebida ao campo privado para eu usar posteriormente
			_funcionarioInterface = funcionarioInterface;
		}

		// Quando alguém tentar criar um novo funcionário, é só fazer isso:
		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
		{
			// Respondemos à pessoa com a lista de funcionários atualizada
			return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
		}

		// Para dar um update nas informações do usuário.
		[HttpPut]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editandoFuncionario)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editandoFuncionario);

			return Ok(serviceResponse);
		}


		// Quando alguém pede para ver todos os funcionários, tenho que fazer isso:
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
		{
			// Pedimos ao serviço para nos dar a lista de funcionários
			var funcionarios = await _funcionarioInterface.GetFuncionarios();

			// Respondemos à pessoa com a lista que conseguimos
			return Ok(funcionarios);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
		{
			ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);
			return Ok(serviceResponse);
		}

		[HttpPut("inativaFuncionario")]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativaFuncionario(id);

			return Ok(serviceResponse);
		}

		[HttpDelete]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);

			return Ok(serviceResponse);
		}

	}
}
