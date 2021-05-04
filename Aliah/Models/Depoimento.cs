using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Depoimento
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Descricao { get; set; }
		//[Required]
		//[MaxLength(255)]

		public int UsuarioId { get; set; }

		public virtual Usuario Usuario { get; set; }
	}
}