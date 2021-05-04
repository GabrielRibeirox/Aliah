using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Movimentacao
	{
		
		public int Id { get; set; }
		

		public int UsuarioId { get; set; }
		public int ProfissionalId { get; set; }
		
		public DateTime Data { get; set; }
		
		public string Descricao { get; set; }
		
		public int Quantidade { get; set; }

		public virtual Usuario Usuarios { get; set; }
		public virtual Profissional Profissional { get; set; }
	}
}