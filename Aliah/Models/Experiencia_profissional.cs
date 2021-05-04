using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Experiencia_profissional
	{
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]


		public int ExperienciaId { get; set; }
		public int ProfissionalId { get; set; }

		public virtual Experiencia Experiencia { get; set; }
		public virtual Profissional Profissional { get; set; }
	}
}