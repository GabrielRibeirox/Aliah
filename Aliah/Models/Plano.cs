using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Plano
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
		public DateTime Data_inicio { get; set; }
		
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Data_termino { get; set; }
		[Required]

		public int Tipo_planoId { get; set; }
		public int ProfissionalId { get; set; }
		public virtual Tipo_plano Tipo_plano { get; set; }

		public virtual  Profissional Profissional { set; get; }
	}
}