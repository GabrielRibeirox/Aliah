using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Formulario_contato
	{
		//codigo 
		//	nome 
		//	email 
		//	telefone 
		//	assunto 
		//	descricao

		//[Key]
		public int Id { get; set; }
        //[Required]
        //[MaxLength(255)]

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }
		[Required]
		[EmailAddress]
        public string Email { get; set; }
		public string Telefone { get; set; }
        [Required]
        public string Assunto { get; set; }
        [Required]
        public string Descricao { get; set; }
	}
}