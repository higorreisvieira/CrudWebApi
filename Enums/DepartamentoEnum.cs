
using System.Text.Json.Serialization;

namespace CrudWebApi.Enums

{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	// O "enum" DepartamentoEnum lista os diferentes departamentos possíveis.
	public enum DepartamentoEnum
	{
		RH,	
		Financeiro,
		Compras,
		Atendimento,
		Zeladoria

	}
}
