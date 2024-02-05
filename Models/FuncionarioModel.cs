using CrudWebApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace CrudWebApi.Models
{
	public class FuncionarioModel
	{
		/*
		 
		Estrutura do projeto:
		Para o projeto final, deve ser desenvolvido uma aplicação em Angular e uma API em ASP.NET Core utilizando os conceitos vistos no treinamento.
		A aplicação deve gerenciar os departamentos de uma empresa com seus respectivos funcionários. Um departamento pode ter vários funcionários, mas um funcionário só pode pertencer a um único departamento.

		Entidades obrigatórias do sistema
		
		Departamento:
		Id,
		Nome,
		Sigla.

		Funcionário:
		Id,
		Nome,
		Foto,
		RG,
		DepartamentoId

		*/

		// A classe funcionário model contém todas as informações do funcionário.
		
		[Key] // [Key] diz que nosso Id é Primary Key no banco de dados.
		public int Id { get; set; }
		public int Rg {  get; set; }
		public string Nome { get; set; }
		public bool Foto {  get; set; }
		public bool Ativo { get; set; }
		public DepartamentoEnum Departamento { get; set; }
		public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
		public DateTime DataDeAlteracao { get;  set; }
	}
}
