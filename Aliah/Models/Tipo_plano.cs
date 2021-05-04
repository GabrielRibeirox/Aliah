using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Tipo_plano
	{

		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Nome { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Descricao { get; set; }
        public int QuantidadeDias { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Valor { get; set; }
		//[Required]
		//[MaxLength(255)]

		public string status { get; set; }

		public virtual ICollection<Plano> Plano { get; set; }
	}
}