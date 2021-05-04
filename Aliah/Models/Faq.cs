using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Faq
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Pergunta { get; set; }

		public string Resposta { get; set; }

	}
}