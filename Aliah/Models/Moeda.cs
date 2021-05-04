using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Moeda
	{
		//	[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Nome { get; set; }
		//[Required]
		public string Quantidade { get; set; }
		//[Required]
		public string Valor { get; set; }
		//[Required]
		public string Validade { get; set; }
		//[Required]
		public string Status { get; set; }
		//[Required]

		public virtual ICollection<Compra_moeda> Compra_moeda { get; set; }
	}
}