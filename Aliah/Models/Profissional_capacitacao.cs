using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Profissional_capacitacao
	{

		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]

		public int ProfissionalId { get; set; }


		public int CapacitacaoId { get; set; }


		public virtual Capacitacao Capacitacao { get; set; }
		public virtual Profissional Profissional { get; set; }
	}
}