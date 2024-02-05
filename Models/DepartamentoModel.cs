using System.ComponentModel.DataAnnotations;

namespace CrudWebApi.Models
{
	// Este código está definindo um "modelo" para representar um departamento no sistema.

	// O [Key] indica que a propriedade 'Id' é a chave primária deste modelo, ou seja, a chave primária no banco de dados.
	public class DepartamentoModel
	{ 
		[Key]
		public int Id { get; set; } // A propriedade 'Id' armazena um número inteiro único que identifica cada departamento.
		public string Nome { get; set; } // A propriedade 'Nome' armazena o nome do departamento, como "Recursos Humanos".
		public string Sigla { get; set; } // A propriedade 'Sigla' armazena uma abreviação ou sigla para o departamento, como "RH".
	}
}
