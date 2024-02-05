using CrudWebApi.DataContext;
using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Service.FuncionarioService
{
	public class FuncionarioService : IFuncionarioInterface
	{
		private readonly ApplicationDbContext _context;
		public FuncionarioService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			try
			{
				if(novoFuncionario == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Informar dados!";
					serviceResponse.Sucesso = false;

					return serviceResponse;

				}

				_context.Add(novoFuncionario);
				await  _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Funcionarios.ToList();

			} catch (Exception ex)

			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			try
			{
				FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

				if (funcionario == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não localizado!";
					serviceResponse.Sucesso = false;

					return serviceResponse;
				}


				_context.Funcionarios.Remove(funcionario);
				await _context.SaveChangesAsync();


				serviceResponse.Dados = _context.Funcionarios.ToList();

			}
			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
		{
			ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

			try
			{
				// Criar uma variável do tipo funcionário e fazer um SELECT dentro do banco
				// Pega o _context, acessa o banco de dbo.Funcionarios, e dentro do banco pegar o primeiro ou o default
				FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);


				if (funcionario == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não localizado!";
					serviceResponse.Sucesso = false;
				}
				serviceResponse.Dados = funcionario;
			}

			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
		{
			/*
			 
			Como foi colocado Task, é necessário lembrar que o método precisa ser async. Agora, com este método preciso retornar uma lista de funcionários model dentro de um Service Response, ou seja, é preciso criar um elemento desse mesmo tipo.

			*/

			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			// Tratamento de erros

			try
			{
				serviceResponse.Dados = _context.Funcionarios.ToList();

				if (serviceResponse.Dados.Count == 0)
				{
					serviceResponse.Mensagem = "Nenhum dado foi encontrado!";

				}

			} catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			try
			{
				FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

				if (funcionario == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não localizado!";
					serviceResponse.Sucesso = false;
				}

				funcionario.Ativo = false;
				funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

				_context.Funcionarios.Update(funcionario);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Funcionarios.ToList();


			}
			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editandoFuncionario)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			try
			{
				FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editandoFuncionario.Id);
				
				if (funcionario == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não localizado!";
					serviceResponse.Sucesso = false;
				}

				// funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

				_context.Funcionarios.Update(editandoFuncionario);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Funcionarios.ToList();

			} catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}
	}
}
