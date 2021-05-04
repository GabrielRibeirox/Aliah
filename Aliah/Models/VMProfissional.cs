using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class CadastrarProfissional
	{
		public List<CheckBoxListHabilidade> listaHabilidade { get; set; }
		public List<CheckBoxListCapacitacao> listaCapacitacao { get; set;}

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

		public string Profissao { get; set; }
		[Required]
		[MaxLength(255)]
		public string Disponibilidade { get; set; }
		[Required]
		[MaxLength(255)]

		public string Experiencia { get; set; }
		
		[MaxLength(255)]

		public string Foto_perfil { get; set; }

		//public int UsuarioId { get; set; }

		//public int EscolaridadeId { get; set; }

		//public int PlanoId { get; set; }


		public string Comprovante_residencia { get; set; }

		public string Antecedentes_criminais { get; set; }

		public string Curso { get; set; }

		public string Nivel { get; set; }

		public string Status { get; set; }

		public string Instituicao { get; set; }

		public string Data_inicio { get; set; }

		public string Data_termino { get; set; }

		public string Modalidade { get; set; }

		public string Certificado { get; set; }

		//public string Status { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12})", ErrorMessage = "A senha deve conter aos menos uma letra maiúscula, minúscula e um número. Deve ser no mínimo 6 caracteres")]
		public string Senha { get; set; }

		[DataType(DataType.Password)]
		[Compare("Senha")]
		[Display(Name = "Confirma Senha")]
		public string ConfirmaSenha { get; set; }



		public CadastrarProfissional()
		{
			listaCapacitacao = new List<CheckBoxListCapacitacao>();
			listaHabilidade = new List<CheckBoxListHabilidade>();
		}

	}

	public class CheckBoxListHabilidade
	{
		public int ID { get; set; }
		public string Display { get; set; }
		public bool IsChecked { get; set; }
	}

	public class CheckBoxListCapacitacao
	{
		public int ID { get; set; }
		public string Display { get; set; }
		public bool IsChecked { get; set; }
	}



	public class ContratarProfissional
	{
		
		public ICollection<Profissional> Profissionals { get; set; }
		public ICollection<Endereco> Enderecos { get; set; }
		
		
	}

}