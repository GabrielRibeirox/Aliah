using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Compra_moeda
	{
		public int Id { get; set; }
		
		public string Data { get; set; }
		public string Quantidade { get; set; }
		public string Valor { get; set; }

		public int UsuarioId { get; set; }
		public int MoedaId { get; set; }

		public virtual Usuario Usuario { get; set; }
		public virtual Moeda Moeda { get; set; }

		
	}
}