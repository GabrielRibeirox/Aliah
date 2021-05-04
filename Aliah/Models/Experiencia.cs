using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Experiencia
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		////[MaxLength(255)]
		public string Empresa { get; set; }

		public string Cargo { get; set; }

		public string Data_inicio { get; set; }

		public string Data_termino { get; set; }



		public string Atividades_realizadas { get; set; }

		public virtual ICollection<Experiencia_profissional> Experiencia_Profissional { get; set; }


	}
}