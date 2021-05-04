using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Profissional_habilidade
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]

		public int HabilidadeId { get; set; }


		public int ProfissionalId { get; set; }


		public virtual Habilidade Habilidade { get; set; }
		public virtual Profissional Profissional { get; set; }
	}
}