using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Contexto : DbContext
	{
		public Contexto() : base(nameOrConnectionString: "StringConexao") { }
		public DbSet<Avaliacao> Avaliacao { get; set; }
		public DbSet<Capacitacao> Capacitacao { get; set; }
		public DbSet<Compra_moeda> Compra_moeda { get; set; }
		public DbSet<Depoimento> Depoimento { get; set; }
		public DbSet<Endereco> Endereco { get; set; }
		public DbSet<Escolaridade> Escolaridade { get; set; }
		public DbSet<Experiencia> Experiencia { get; set; }
		public DbSet<Experiencia_profissional> Experiencia_profissional { get; set; }
		public DbSet<Faq> Faq { get; set; }
		public DbSet<Formulario_contato> Formulario_contato { get; set; }
		public DbSet<Habilidade> Habilidade { get; set; }
		public DbSet<Moeda> Moeda { get; set; }
		public DbSet<Movimentacao> Movimentacao { get; set; }
		public DbSet<Plano> Plano { get; set; }
		public DbSet<Profissional> Profissional { get; set; }
		public DbSet<Profissional_capacitacao> Profissional_capacitacao { get; set; }
		public DbSet<Profissional_habilidade> Profissional_habilidade { get; set; }
		public DbSet<Redes_sociais> Redes_socias { get; set; }
		public DbSet<Tipo_avaliacao> Tipo_avaliacao { get; set; }
		public DbSet<Tipo_cadastro> Tipo_cadastro { get; set; }
		public DbSet<Tipo_endereco> Tipo_endereco { get; set; }
		public DbSet<Tipo_plano> Tipo_plano { get; set; }
		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }


		protected override void OnModelCreating(DbModelBuilder mb)
		{


			var cap = mb.Entity<Capacitacao>();
			cap.ToTable("cap_capacitacao");
			cap.Property(x => x.Id).HasColumnName("cap_codigo");
			cap.Property(x => x.Descricao).HasColumnName("cap_descricao");

			var hab = mb.Entity<Habilidade>();
			hab.ToTable("hab_habilidade");
			hab.Property(x => x.Id).HasColumnName("hab_codigo");
			hab.Property(x => x.Descricao).HasColumnName("hab_descricao");

			var tav = mb.Entity<Tipo_avaliacao>();
			tav.ToTable("tav_tipo_avaliacao");
			tav.Property(x => x.Id).HasColumnName("tav_codigo");
			tav.Property(x => x.Descricao).HasColumnName("tav_descricao");

			var tca = mb.Entity<Tipo_cadastro>();
			tca.ToTable("tca_tipo_cadastro");
			tca.Property(x => x.Id).HasColumnName("tca_codigo");
			tca.Property(x => x.Descricao).HasColumnName("tca_descricao");

			var ten = mb.Entity<Tipo_endereco>();
			ten.ToTable("ten_tipo_endereco");
			ten.Property(x => x.Id).HasColumnName("ten_codigo");
			ten.Property(x => x.Descricao).HasColumnName("ten_descricao");

			var tpl = mb.Entity<Tipo_plano>();
			tpl.ToTable("tpl_tipo_plano");
			tpl.Property(x => x.Id).HasColumnName("tpl_codigo");
			tpl.Property(x => x.Descricao).HasColumnName("tpl_descricao");
			tpl.Property(x => x.Nome).HasColumnName("tpl_nome");
			tpl.Property(x => x.Valor).HasColumnName("tpl_valor");

			var moe = mb.Entity<Moeda>();
			moe.ToTable("moe_moeda");
			moe.Property(x => x.Id).HasColumnName("moe_codigo");
			moe.Property(x => x.Nome).HasColumnName("moe_nome");
			moe.Property(x => x.Quantidade).HasColumnName("moe_quantidade");
			moe.Property(x => x.Valor).HasColumnName("moe_valor");
			moe.Property(x => x.Validade).HasColumnName("moe_validade");
			moe.Property(x => x.Status).HasColumnName("moe_status");

			var faq = mb.Entity<Faq>();
			faq.ToTable("faq_faq");
			faq.Property(x => x.Id).HasColumnName("faq_codigo");
			faq.Property(x => x.Pergunta).HasColumnName("faq_pergunta");
			faq.Property(x => x.Resposta).HasColumnName("faq_resposta");

			var exp = mb.Entity<Experiencia>();
			exp.ToTable("exp_experiencia");
			exp.Property(x => x.Id).HasColumnName("exp_codigo");
			exp.Property(x => x.Cargo).HasColumnName("exp_cargo");
			exp.Property(x => x.Data_inicio).HasColumnName("exp_data_inicio");
			exp.Property(x => x.Data_termino).HasColumnName("exp_data_termino");
			exp.Property(x => x.Empresa).HasColumnName("exp_empresa");
			exp.Property(x => x.Atividades_realizadas).HasColumnName("exp_atividades_realizadas");

			var fco = mb.Entity<Formulario_contato>();
			fco.ToTable("fco_formulario_contato");
			fco.Property(x => x.Id).HasColumnName("fco_codigo");
			fco.Property(x => x.Assunto).HasColumnName("fco_assunto");
			fco.Property(x => x.Descricao).HasColumnName("fco_descricao");
			fco.Property(x => x.Email).HasColumnName("fco_email");
			fco.Property(x => x.Nome).HasColumnName("fco_nome");
			fco.Property(x => x.Telefone).HasColumnName("fco_telefone");

			var usu = mb.Entity<Usuario>();
			usu.ToTable("usu_usuario");
			usu.Property(x => x.Id).HasColumnName("usu_codigo");
			usu.Property(x => x.Celular).HasColumnName("usu_celular");
			usu.Property(x => x.Cpf).HasColumnName("usu_cpf");
			usu.Property(x => x.Data_nascimento).HasColumnName("usu_data_nascimento");
			usu.Property(x => x.Email).HasColumnName("usu_email");
			usu.Property(x => x.Nome).HasColumnName("usu_nome");
			usu.Property(x => x.Senha).HasColumnName("usu_senha");
			usu.Property(x => x.Sexo).HasColumnName("usu_sexo");
			usu.Property(x => x.Status).HasColumnName("usu_status");
			usu.Property(x => x.Telefone).HasColumnName("usu_telefone");
			usu.Property(x => x.Hash).HasColumnName("usu_hash");
			usu.Property(x => x.Tipo_cadastroId).HasColumnName("tca_codigo");

			var cmo = mb.Entity<Compra_moeda>();
			cmo.ToTable("cmo_compra_moeda");
			cmo.Property(x => x.Id).HasColumnName("cmo_codigo");
			cmo.Property(x => x.Data).HasColumnName("cmo_data");
			cmo.Property(x => x.Quantidade).HasColumnName("cmo_quantidade");
			cmo.Property(x => x.Valor).HasColumnName("cmo_valor");
			cmo.Property(x => x.MoedaId).HasColumnName("moe_codigo");
			cmo.Property(x => x.UsuarioId).HasColumnName("usu_codigo");
			

			var mov = mb.Entity<Movimentacao>();
			mov.ToTable("mov_movimentacao");
			mov.Property(x => x.Id).HasColumnName("mov_codigo");
			mov.Property(x => x.Data).HasColumnName("mov_data");
			mov.Property(x => x.Descricao).HasColumnName("mov_descricao");
			mov.Property(x => x.Quantidade).HasColumnName("mov_quantidade");
							
			mov.Property(x => x.UsuarioId).HasColumnName("usu_codigo");
			mov.Property(x => x.ProfissionalId).HasColumnName("pro_codigo");

			var dep = mb.Entity<Depoimento>();
			dep.ToTable("dep_depoimento");
			dep.Property(x => x.Id).HasColumnName("dep_codigo");
			dep.Property(x => x.Descricao).HasColumnName("dep_descricao");
			dep.Property(x => x.UsuarioId).HasColumnName("usu_codigo");

			var esc = mb.Entity<Escolaridade>();
			esc.ToTable("esc_escolaridade");
			esc.Property(x => x.Id).HasColumnName("esc_codigo");
			esc.Property(x => x.Certificado).HasColumnName("esc_certificado");
			esc.Property(x => x.Curso).HasColumnName("esc_curso");
			esc.Property(x => x.Data_inicio).HasColumnName("esc_data_inicio");
			esc.Property(x => x.Data_termino).HasColumnName("esc_data_termino");
			esc.Property(x => x.Instituicao).HasColumnName("esc_instituicao");
			esc.Property(x => x.Modalidade).HasColumnName("esc_modalidade");
			esc.Property(x => x.Nivel).HasColumnName("esc_nivel");
			esc.Property(x => x.Status).HasColumnName("esc_status");

			var pla = mb.Entity<Plano>();
			pla.ToTable("pla_plano");
			pla.Property(x => x.Id).HasColumnName("pla_codigo");
			pla.Property(x => x.Data_inicio).HasColumnName("pla_data_inicio");
			pla.Property(x => x.Data_termino).HasColumnName("pla_data_termino");
			pla.Property(x => x.Tipo_planoId).HasColumnName("tpl_codigo");

			var end = mb.Entity<Endereco>();
			end.ToTable("end_endereco");
			end.Property(x => x.Id).HasColumnName("end_codigo");
			end.Property(x => x.Bairro).HasColumnName("end_bairro");
			end.Property(x => x.Cep).HasColumnName("end_cep");
			end.Property(x => x.Cidade).HasColumnName("end_cidade");
			end.Property(x => x.Estado).HasColumnName("end_estado");
			end.Property(x => x.Numero).HasColumnName("end_numero");
			end.Property(x => x.Rua).HasColumnName("end_rua");
			end.Property(x => x.Tipo_enderecoId).HasColumnName("ten_codigo");
			end.Property(x => x.UsuarioId).HasColumnName("usu_codigo");

			var pro = mb.Entity<Profissional>();
			pro.ToTable("pro_profissional");
			pro.Property(x => x.Id).HasColumnName("pro_codigo");
			pro.Property(x => x.Antecedentes_criminais).HasColumnName("pro_antecedentes_criminais");
			pro.Property(x => x.Comprovante_residencia).HasColumnName("pro_comprovante_residencia");
			pro.Property(x => x.Disponibilidade).HasColumnName("pro_disponibilidade");
			pro.Property(x => x.Experiencia).HasColumnName("pro_experiencia");
			pro.Property(x => x.Foto_perfil).HasColumnName("pro_foto_perfil");
			pro.Property(x => x.Profissao).HasColumnName("pro_profissao");
			pro.Property(x => x.EscolaridadeId).HasColumnName("esc_codigo");
			pro.Property(x => x.PlanoId).HasColumnName("pla_codigo");
			pro.Property(x => x.UsuarioId).HasColumnName("usu_codigo");

			var pca = mb.Entity<Profissional_capacitacao>();
			pca.ToTable("pca_profissional_capacitacao");
			pca.Property(x => x.Id).HasColumnName("pca_codigo");
			pca.Property(x => x.CapacitacaoId).HasColumnName("cap_codigo");
			pca.Property(x => x.ProfissionalId).HasColumnName("pro_codigo");

			var ava = mb.Entity<Avaliacao>();
			ava.ToTable("ava_avaliacao");
			ava.Property(x => x.Id).HasColumnName("ava_codigo");
			ava.Property(x => x.ProfissionalId).HasColumnName("pro_codigo");
			ava.Property(x => x.Tipo_avaliacaoId).HasColumnName("tav_codigo");
			ava.Property(x => x.UsuarioId).HasColumnName("usu_codigo");

			var rso = mb.Entity<Redes_sociais>();
			rso.ToTable("rso_redes_sociais");
			rso.Property(x => x.Id).HasColumnName("rso_codigo");
			rso.Property(x => x.Facebook).HasColumnName("rso_facebook");
			rso.Property(x => x.Instagram).HasColumnName("rso_instagram");
			rso.Property(x => x.Linkedin).HasColumnName("rso_linkedin");
			rso.Property(x => x.Twitter).HasColumnName("rso_twitter");
			rso.Property(x => x.ProfissionalId).HasColumnName("pro_codigo");

			var pha = mb.Entity<Profissional_habilidade>();
			pha.ToTable("pha_profissional_habilidade");
			pha.Property(x => x.Id).HasColumnName("pha_codigo");
			pha.Property(x => x.HabilidadeId).HasColumnName("hab_codigo");
			pha.Property(x => x.ProfissionalId).HasColumnName("pro_codigo");

			var epr = mb.Entity<Experiencia_profissional>();
			epr.ToTable("epr_experiencia_profissional");
			epr.Property(x => x.Id).HasColumnName("epr_codigo");
			epr.Property(x => x.ExperienciaId).HasColumnName("exp_codigo");
			epr.Property(x => x.ProfissionalId).HasColumnName("pro_codigo");

			var usup = mb.Entity<UsuarioPerfil>();
			usup.ToTable("usup_usuarioperfil");
			usup.Property(x => x.Id).HasColumnName("usup_codigo");
			usup.Property(x => x.TipoCadastroId).HasColumnName("tca_codigo");
			usup.Property(x => x.UsuarioId).HasColumnName("usu_codigo");

		}
	}
}