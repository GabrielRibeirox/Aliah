using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Redes_sociais
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public int ProfissionalId { get; set; }

		public string Facebook { get; set; }
		public string Instagram { get; set; }
		public string Twitter { get; set; }
		public string Linkedin { get; set; }
		public virtual Profissional Profissional { get; set; }
	}
}