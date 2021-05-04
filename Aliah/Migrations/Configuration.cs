
namespace VaiCaralhoMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VaiCaralhoMVC.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(VaiCaralhoMVC.Models.Contexto context)
        {
            context.Tipo_cadastro.AddOrUpdate(
                     p => p.Descricao,
                     new Models.Tipo_cadastro { Id = 1, Descricao = "Administrador" },
                     new Models.Tipo_cadastro { Id = 2, Descricao = "Cliente" },
                     new Models.Tipo_cadastro { Id = 3, Descricao = "Profissional" });
            context.Usuario.AddOrUpdate(
            p => p.Email,
            new Models.Usuario { Id = 1, Nome = "Usuario", Data_nascimento = "12-02-1999", Cpf = "30450817102", Sexo = "Masculino", Email = "usuario@aliah.com", Senha = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==", Celular = "", Telefone = "", Status = "1", Tipo_cadastroId = 2 },
            new Models.Usuario { Id = 2, Nome = "Profissional", Data_nascimento = "08-05-1997", Cpf = "7894613201", Sexo = "Masculino", Email = "profissional@aliah.com", Senha = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==", Celular = "", Telefone = "", Status = "1", Tipo_cadastroId = 3 },
            new Models.Usuario { Id = 3, Nome = "Admin", Data_nascimento = "01-02-1999", Cpf = "50827410854", Sexo = "Masculino", Email = "admin@aliah.com", Senha = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==", Celular = "", Telefone = "", Status = "1", Tipo_cadastroId = 1 });

            context.Tipo_endereco.AddOrUpdate(
            p => p.Descricao,
            new Models.Tipo_endereco { Id = 1, Descricao = "Comercial" },
            new Models.Tipo_endereco { Id = 2, Descricao = "Residencial" });
            context.Capacitacao.AddOrUpdate(
            p => p.Id,
            new Models.Capacitacao { Id = 1, Descricao = "Remedio" },
            new Models.Capacitacao { Id = 2, Descricao = "Alimentacao" },
            new Models.Capacitacao { Id = 3, Descricao = "Banho" });

            context.Habilidade.AddOrUpdate(
            p => p.Id,
            new Models.Habilidade { Id = 1, Descricao = "Sabe Cozinhar" },
            new Models.Habilidade { Id = 2, Descricao = "Fala Inglês" },
            new Models.Habilidade { Id = 3, Descricao = "Pode dirigir" });

           // context.Tipo_plano.AddOrUpdate(
           //p => p.Id,
           //new Models.Tipo_plano { Id = 1, Nome = "Grátis", Valor = "R$ 15,00", Descricao = "Quinze dias de acesso" },
           //new Models.Tipo_plano { Id = 2, Nome = "Mensal", Valor = "R$ 25,00", Descricao = "Você ganha mais visibilidade" },
           //new Models.Tipo_plano { Id = 3, Nome = "Anual", Valor = "R$ 260,00", Descricao = "Busca ilimitada" });

           // context.Moeda.AddOrUpdate(
           //           p => p.Id,
           //           new Models.Moeda { Id = 1, Quantidade = "10 moedas", Valor = "R$ 10,00", Validade = "Validade de 1 semana" },
           //           new Models.Moeda { Id = 2, Quantidade = "20 moedas", Valor = "R$ 15,00", Validade = "Validade de 15 dias" },
           //           new Models.Moeda { Id = 3, Quantidade = "30 moedas", Valor = "R$ 20,00", Validade = "Validade de 1 mês" });

        context.Faq.AddOrUpdate(
                      p => p.Id,
                      new Models.Faq { Id = 1, Pergunta = "Como eu posso me cadastrar como profissional?", Resposta = "Entre em nossa plataforma e cadastre seu perfil, escolha seu plano e encontre o que precisa." },
                      new Models.Faq { Id = 2, Pergunta = "O que é ALIAH?", Resposta = "Aliah é uma plataforma web que auxilia na busca de profissonais da área da saúde." },
                      new Models.Faq { Id = 3, Pergunta = "Esqueci a minha senha?", Resposta = "Ao fazer login, clique no botão 'esqueci minha senha' que enviarenos um email para que seja recuperada." });
        }

    }
}


