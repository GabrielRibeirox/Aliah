using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Tipo_avaliacao
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Descricao { get; set; }
		//[Required]
		//[MaxLength(255)]

		public virtual ICollection<Avaliacao> Avaliacao { get; set; }
	}
}