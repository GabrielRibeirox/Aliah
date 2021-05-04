using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Avaliacao
	{
		//[Key]
		public int Id { get; set; }

		public int Tipo_avaliacaoId { get; set; }

		public int UsuarioId { get; set; }

		public int ProfissionalId { get; set; }

		public string Descricao { get; set; }
		public virtual Tipo_avaliacao Tipo_avaliacao { get; set; }
		public virtual Usuario Usuario { get; set; }
		public virtual Profissional Profissional { get; set; }
	}
}