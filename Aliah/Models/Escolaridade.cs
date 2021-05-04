using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Escolaridade
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Curso { get; set; }
		public string Nivel { get; set; }
		public string Status { get; set; }
		public string Instituicao { get; set; }
		public string Data_inicio { get; set; }
		public string Data_termino { get; set; }
		public string Modalidade { get; set; }
		public string Certificado { get; set; }

		public virtual ICollection<Profissional> Profissional { get; set; }
	}
}