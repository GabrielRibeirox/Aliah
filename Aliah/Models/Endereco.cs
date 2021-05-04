using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Endereco
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Rua { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Cep { get; set; }
		public string Estado { get; set; }

		public int UsuarioId { get; set; }
		public int Tipo_enderecoId { get; set; }

		public virtual Tipo_endereco Tipo_endereco { get; set; }
		public virtual Usuario Usuario { get; set; }
	}
}