using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Profissional
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Profissao { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Disponibilidade { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Experiencia { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Foto_perfil { get; set; }

		public int UsuarioId { get; set; }

		public int EscolaridadeId { get; set; }

		public int PlanoId { get; set; }


		public string Comprovante_residencia { get; set; }
		public string Antecedentes_criminais { get; set; }
		public virtual Usuario Usuario { get; set; }
		public virtual Escolaridade Escolaridade { get; set; }
		public virtual ICollection<Plano> Planos { get; set; }
		public virtual ICollection<Movimentacao> Movimentacaos { get; set; }
		public virtual ICollection<Experiencia_profissional> Experiencia_Profissional { set; get; }
		public virtual ICollection<Profissional_habilidade> Profissional_habilidade { set; get; }
		public virtual ICollection<Profissional_capacitacao> Profissional_Capacitacao { set; get; }
		public virtual ICollection<Avaliacao> Avaliacao { set; get; }
		public virtual ICollection<Redes_sociais> Redes_sociais { set; get; }
		//public virtual ICollection<Experiencia_profissional> Experiencia_profissional { set; get; }
	}
}
