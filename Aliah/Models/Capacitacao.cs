using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Capacitacao
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Descricao { get; set; }
		//[Required]
		//[MaxLength(255)]

		public virtual ICollection<Profissional_capacitacao> Profissional_Capacitacao { get; set; }
	}
}