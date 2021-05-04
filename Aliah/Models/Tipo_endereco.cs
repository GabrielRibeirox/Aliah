using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Tipo_endereco
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Descricao { get; set; }

		public virtual ICollection<Endereco> Endereco { get; set; }
	}
}