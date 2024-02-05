using CrudWebApi.Models;

namespace CrudWebApi.Service.FuncionarioService
{
	public interface IFuncionarioInterface
	{
		// Métodos do Controller.
		Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios(); // Um Service Response que retorna uma lista de funcionários dentro.
		Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
		Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
		Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editandoFuncionario);
		Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
		Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id); // Opção caso deseja inativar um usuário no sistema!

	}
}
