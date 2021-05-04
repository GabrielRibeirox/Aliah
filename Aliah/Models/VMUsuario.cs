using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Cadastrar
	{
		//[Required]
		//public string Tipo_cadastro { get; set; }

		[Required]
		[MaxLength(255)]
		public string Nome { get; set; }

		[Required]
		[MaxLength(255)]
		public string Cpf { get; set; }

		[Required]
		public string Data_nascimento { get; set; }

		[Required]
		public string Sexo { get; set; }

		public string Telefone { get; set; }

		public string Celular { get; set; }

		public string Cep { get; set; }
		public string Rua { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Numero { get; set; }

		//public string Status { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

        [Required]
		[DataType(DataType.Password)]
		[RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12})", ErrorMessage = "A senha deve conter aos menos uma letra maiúscula, minúscula e um número. Deve ser no mínimo 6 caracteres")]
		public string Senha { get; set; }
		[DataType(DataType.Password)]
		[Compare("Senha")]
		[Display(Name = "Confirma Senha")]

		public string ConfirmaSenha { get; set; }


		


	}
		public class Acesso
		{
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[DataType(DataType.Password)]
			[RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12})", ErrorMessage = "A senha deve conter aos menos uma letra maiúscula, minúscula e um número. Deve ser no mínimo 6 caracteres")]
			public string Senha { get; set; }
		}

		public class Mensagem
		{
			[EmailAddress]
			[Required]
			public string Email { get; set; }
			[Required]
			public string Assunto { get; set; }
			[DataType(DataType.MultilineText)]
			[Display(Name = "Mensagem")]
			public string CorpoMsg { get; set; }
		}
		public class EsqueceuSenha
		{
			[EmailAddress]
			[Required]
			public string Email { get; set; }
		}
		public class RedefinirSenha
		{
			public string Email { get; set; }
			public string Hash { get; set; }
			[DataType(DataType.Password)]
			[RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12})", ErrorMessage = "A senha deve conter aos menos uma letra maiúscula, minúscula e um número. Deve ser no mínimo 6 caracteres")]
			public string Senha { get; set; }
			[DataType(DataType.Password)]
			[Compare("Senha")]
			[Display(Name = "Confirma Senha")]
			public string ConfirmaSenha { get; set; }
		}
	public class PlanoMoeda
	{
		public ICollection<Tipo_plano> Planos { get; set; }
		public ICollection<Moeda> Moedas { get; set; }
	}

	public class UsuarioEndereco
	{
		public ICollection<Usuario> Usuarios { get; set; }
		public ICollection<Endereco> Enderecos { get; set; }
	}
    public class UsuarioPerfil
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TipoCadastroId { get; set; }
        public virtual Usuario Usuarios { get; set; }
        public virtual Tipo_cadastro TipoCadastro{ get; set; }
    }
    public static class CustomRoles
    {
        public const string Administrator = "Administrador";
        public const string Profissional = "Profissional";
        public const string User = "Cliente";
        public const string AdministratorOrUser = Administrator + "," + User + "," + Profissional;
    }



}
