using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Usuario
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		//[MaxLength(255)]
		public string Nome { get; set; }
		//[Required]
		public string Cpf { get; set; }
		//[Required]
		[DisplayName("Data de nascimento")]
		public string Data_nascimento { get; set; }
		//[Required]
		public string Sexo { get; set; }
		//[Required]
		public string Email { get; set; }
		//[Required]
		public string Senha { get; set; }
		//[Required]
		public string Celular { get; set; }
		public string Telefone { get; set; }
		public string Status { get; set; }
		public string Hash { get; set; }
		//[Required]

		public int Tipo_cadastroId { get; set; }

		public virtual Tipo_cadastro Tipo_cadastro { get; set; }
		public virtual ICollection<Compra_moeda> Compra_moeda { get; set; }
		public virtual ICollection<Movimentacao> Movimentacaos { get; set; }
		public virtual ICollection<Depoimento> Depoimento { get; set; }
		public virtual ICollection<Endereco> Endereco { get; set; }
		public virtual ICollection<Profissional> Profissional { get; set; }
		public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfil { get; set; }


        public static List<Usuario> ListaUsuario()
		{
			List<Usuario> lst = new List<Usuario>();
			
			return lst;
		}


	}
}