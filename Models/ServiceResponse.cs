
namespace CrudWebApi.Models
{
	public class ServiceResponse<T> // O <T> significa que o programa vai receber dados genéricos.
	{
        // Serviço para retornar informações da aplicação
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; }

		/* 
		 public static implicit operator ServiceResponse<T>(ServiceResponse<List<FuncionarioModel>> v)
		{
			throw new NotImplementedException();
		}

		*/
	}
}
