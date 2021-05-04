namespace VaiCaralhoMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    { 
        public override void Up()
        {
            CreateTable(
                "dbo.ava_avaliacao",
                c => new
                    { 
                        ava_codigo = c.Int(nullable: false, identity: true),
                        tav_codigo = c.Int(nullable: false),
                        usu_codigo = c.Int(nullable: false),
                        pro_codigo = c.Int(nullable: false),
                        Descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ava_codigo)
                .ForeignKey("dbo.pro_profissional", t => t.pro_codigo, cascadeDelete: true)
                .ForeignKey("dbo.usu_usuario", t => t.usu_codigo, cascadeDelete: true)
                .ForeignKey("dbo.tav_tipo_avaliacao", t => t.tav_codigo, cascadeDelete: true)
                //.Index(t => t.pro_codigo)
                //.Index(t => t.usu_codigo)
                //.Index(t => t.tav_codigo)
                ;
            
            CreateTable(
                "dbo.pro_profissional",
                c => new
                    {
                        pro_codigo = c.Int(nullable: false, identity: true),
                        pro_profissao = c.String(unicode: false),
                        pro_disponibilidade = c.String(unicode: false),
                        pro_experiencia = c.String(unicode: false),
                        pro_foto_perfil = c.String(unicode: false),
                        usu_codigo = c.Int(nullable: false),
                        esc_codigo = c.Int(nullable: false),
                        pla_codigo = c.Int(nullable: false),
                        pro_comprovante_residencia = c.String(unicode: false),
                        pro_antecedentes_criminais = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.pro_codigo)
                .ForeignKey("dbo.esc_escolaridade", t => t.esc_codigo, cascadeDelete: true)
                .ForeignKey("dbo.pla_plano", t => t.pla_codigo, cascadeDelete: true)
                .ForeignKey("dbo.usu_usuario", t => t.usu_codigo, cascadeDelete: true)
                //.Index(t => t.esc_codigo)
               // .Index(t => t.pla_codigo)
                //.Index(t => t.usu_codigo)
                ;
            
            CreateTable(
                "dbo.esc_escolaridade",
                c => new
                    {
                        esc_codigo = c.Int(nullable: false, identity: true),
                        esc_curso = c.String(unicode: false),
                        esc_nivel = c.String(unicode: false),
                        esc_status = c.String(unicode: false),
                        esc_instituicao = c.String(unicode: false),
                        esc_data_inicio = c.String(unicode: false),
                        esc_data_termino = c.String(unicode: false),
                        esc_modalidade = c.String(unicode: false),
                        esc_certificado = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.esc_codigo);
            
            CreateTable(
                "dbo.epr_experiencia_profissional",
                c => new
                    {
                        epr_codigo = c.Int(nullable: false, identity: true),
                        exp_codigo = c.Int(nullable: false),
                        pro_codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.epr_codigo)
                .ForeignKey("dbo.exp_experiencia", t => t.exp_codigo, cascadeDelete: true)
                .ForeignKey("dbo.pro_profissional", t => t.pro_codigo, cascadeDelete: true)
                //.Index(t => t.exp_codigo)
               // .Index(t => t.pro_codigo)
               ;
            
            CreateTable(
                "dbo.exp_experiencia",
                c => new
                    {
                        exp_codigo = c.Int(nullable: false, identity: true),
                        exp_empresa = c.String(unicode: false),
                        exp_cargo = c.String(unicode: false),
                        exp_data_inicio = c.String(unicode: false),
                        exp_data_termino = c.String(unicode: false),
                        exp_atividades_realizadas = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.exp_codigo);
            
            CreateTable(
                "dbo.pla_plano",
                c => new
                    {
                        pla_codigo = c.Int(nullable: false, identity: true),
                        pla_data_inicio = c.String(unicode: false),
                        pla_data_termino = c.String(nullable: false, unicode: false),
                        tpl_codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pla_codigo)
                .ForeignKey("dbo.tpl_tipo_plano", t => t.tpl_codigo, cascadeDelete: true)
                //.Index(t => t.tpl_codigo)
                ;
            
            CreateTable(
                "dbo.tpl_tipo_plano",
                c => new
                    {
                        tpl_codigo = c.Int(nullable: false, identity: true),
                        tpl_nome = c.String(unicode: false),
                        tpl_descricao = c.String(unicode: false),
                        tpl_valor = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.tpl_codigo);
            
            CreateTable(
                "dbo.pca_profissional_capacitacao",
                c => new
                    {
                        pca_codigo = c.Int(nullable: false, identity: true),
                        pro_codigo = c.Int(nullable: false),
                        cap_codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pca_codigo)
                .ForeignKey("dbo.cap_capacitacao", t => t.cap_codigo, cascadeDelete: true)
                .ForeignKey("dbo.pro_profissional", t => t.pro_codigo, cascadeDelete: true)
                //.Index(t => t.cap_codigo)
                //.Index(t => t.pro_codigo)
                ;
            
            CreateTable(
                "dbo.cap_capacitacao",
                c => new
                    {
                        cap_codigo = c.Int(nullable: false, identity: true),
                        cap_descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.cap_codigo);
            
            CreateTable(
                "dbo.pha_profissional_habilidade",
                c => new
                    {
                        pha_codigo = c.Int(nullable: false, identity: true),
                        hab_codigo = c.Int(nullable: false),
                        pro_codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pha_codigo)
                .ForeignKey("dbo.hab_habilidade", t => t.hab_codigo, cascadeDelete: true)
                .ForeignKey("dbo.pro_profissional", t => t.pro_codigo, cascadeDelete: true)
                //.Index(t => t.hab_codigo)
                //.Index(t => t.pro_codigo)
                ;
            
            CreateTable(
                "dbo.hab_habilidade",
                c => new
                    {
                        hab_codigo = c.Int(nullable: false, identity: true),
                        hab_descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.hab_codigo);
            
            CreateTable(
                "dbo.rso_redes_sociais",
                c => new
                    {
                        rso_codigo = c.Int(nullable: false, identity: true),
                        pro_codigo = c.Int(nullable: false),
                        rso_facebook = c.String(unicode: false),
                        rso_instagram = c.String(unicode: false),
                        rso_twitter = c.String(unicode: false),
                        rso_linkedin = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.rso_codigo)
                .ForeignKey("dbo.pro_profissional", t => t.pro_codigo, cascadeDelete: true)
                //.Index(t => t.pro_codigo)
                ;
            
            CreateTable(
                "dbo.usu_usuario",
                c => new
                    {
                        usu_codigo = c.Int(nullable: false, identity: true),
                        usu_nome = c.String(unicode: false),
                        usu_cpf = c.String(unicode: false),
                        usu_data_nascimento = c.String(unicode: false),
                        usu_sexo = c.String(unicode: false),
                        usu_email = c.String(unicode: false),
                        usu_senha = c.String(unicode: false),
                        usu_celular = c.String(unicode: false),
                        usu_telefone = c.String(unicode: false),
                        usu_status = c.String(unicode: false),
                        tca_codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.usu_codigo)
                .ForeignKey("dbo.tca_tipo_cadastro", t => t.tca_codigo, cascadeDelete: true)
                //.Index(t => t.tca_codigo)
                ;
            
            CreateTable(
                "dbo.cmo_compra_moeda",
                c => new
                    {
                        cmo_codigo = c.Int(nullable: false, identity: true),
                        cmo_data = c.String(unicode: false),
                        cmo_quantidade = c.String(unicode: false),
                        cmo_valor = c.String(unicode: false),
                        usu_codigo = c.Int(nullable: false),
                        moe_codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cmo_codigo)
                .ForeignKey("dbo.moe_moeda", t => t.moe_codigo, cascadeDelete: true)
                .ForeignKey("dbo.usu_usuario", t => t.usu_codigo, cascadeDelete: true)
                //.Index(t => t.moe_codigo)
                //.Index(t => t.usu_codigo)
                ;
            
            CreateTable(
                "dbo.moe_moeda",
                c => new
                    {
                        moe_codigo = c.Int(nullable: false, identity: true),
                        moe_nome = c.String(unicode: false),
                        moe_quantidade = c.String(unicode: false),
                        moe_valor = c.String(unicode: false),
                        moe_validade = c.String(unicode: false),
                        moe_status = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.moe_codigo);
            
            CreateTable(
                "dbo.mov_movimentacao",
                c => new
                    {
                        mov_codigo = c.Int(nullable: false, identity: true),
                        cmo_codigo = c.Int(nullable: false),
                        mov_entrada = c.String(unicode: false),
                        mov_data = c.String(unicode: false),
                        mov_validade_entrada = c.String(unicode: false),
                        mov_descricao = c.String(unicode: false),
                        mov_saida = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.mov_codigo)
                .ForeignKey("dbo.cmo_compra_moeda", t => t.cmo_codigo, cascadeDelete: true)
               // .Index(t => t.cmo_codigo)
               ;
            
            CreateTable(
                "dbo.dep_depoimento",
                c => new
                    {
                        dep_codigo = c.Int(nullable: false, identity: true),
                        dep_descricao = c.String(unicode: false),
                        usu_codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dep_codigo)
                .ForeignKey("dbo.usu_usuario", t => t.usu_codigo, cascadeDelete: true)
                //.Index(t => t.usu_codigo)
                ;
            
            CreateTable(
                "dbo.end_endereco",
                c => new
                    {
                        end_codigo = c.Int(nullable: false, identity: true),
                        end_rua = c.String(unicode: false),
                        end_numero = c.String(unicode: false),
                        end_bairro = c.String(unicode: false),
                        end_cidade = c.String(unicode: false),
                        end_cep = c.String(unicode: false),
                        end_estado = c.String(unicode: false),
                        usu_codigo = c.Int(nullable: false),
                        ten_codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.end_codigo)
                .ForeignKey("dbo.ten_tipo_endereco", t => t.ten_codigo, cascadeDelete: true)
                .ForeignKey("dbo.usu_usuario", t => t.usu_codigo, cascadeDelete: true)
                //.Index(t => t.ten_codigo)
                //.Index(t => t.usu_codigo)
                ;
            
            CreateTable(
                "dbo.ten_tipo_endereco",
                c => new
                    {
                        ten_codigo = c.Int(nullable: false, identity: true),
                        ten_descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ten_codigo);
            
            CreateTable(
                "dbo.tca_tipo_cadastro",
                c => new
                    {
                        tca_codigo = c.Int(nullable: false, identity: true),
                        tca_descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.tca_codigo);
            
            CreateTable(
                "dbo.tav_tipo_avaliacao",
                c => new
                    {
                        tav_codigo = c.Int(nullable: false, identity: true),
                        tav_descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.tav_codigo);
            
            CreateTable(
                "dbo.faq_faq",
                c => new
                    {
                        faq_codigo = c.Int(nullable: false, identity: true),
                        faq_pergunta = c.String(unicode: false),
                        faq_resposta = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.faq_codigo);
            
            CreateTable(
                "dbo.fco_formulario_contato",
                c => new
                    {
                        fco_codigo = c.Int(nullable: false, identity: true),
                        fco_nome = c.String(unicode: false),
                        fco_email = c.String(unicode: false),
                        fco_telefone = c.String(unicode: false),
                        fco_assunto = c.String(unicode: false),
                        fco_descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.fco_codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ava_avaliacao", "tav_codigo", "dbo.tav_tipo_avaliacao");
            DropForeignKey("dbo.usu_usuario", "tca_codigo", "dbo.tca_tipo_cadastro");
            DropForeignKey("dbo.pro_profissional", "usu_codigo", "dbo.usu_usuario");
            DropForeignKey("dbo.end_endereco", "usu_codigo", "dbo.usu_usuario");
            DropForeignKey("dbo.end_endereco", "ten_codigo", "dbo.ten_tipo_endereco");
            DropForeignKey("dbo.dep_depoimento", "usu_codigo", "dbo.usu_usuario");
            DropForeignKey("dbo.cmo_compra_moeda", "usu_codigo", "dbo.usu_usuario");
            DropForeignKey("dbo.mov_movimentacao", "cmo_codigo", "dbo.cmo_compra_moeda");
            DropForeignKey("dbo.cmo_compra_moeda", "moe_codigo", "dbo.moe_moeda");
            DropForeignKey("dbo.ava_avaliacao", "usu_codigo", "dbo.usu_usuario");
            DropForeignKey("dbo.rso_redes_sociais", "pro_codigo", "dbo.pro_profissional");
            DropForeignKey("dbo.pha_profissional_habilidade", "pro_codigo", "dbo.pro_profissional");
            DropForeignKey("dbo.pha_profissional_habilidade", "hab_codigo", "dbo.hab_habilidade");
            DropForeignKey("dbo.pca_profissional_capacitacao", "pro_codigo", "dbo.pro_profissional");
            DropForeignKey("dbo.pca_profissional_capacitacao", "cap_codigo", "dbo.cap_capacitacao");
            DropForeignKey("dbo.pla_plano", "tpl_codigo", "dbo.tpl_tipo_plano");
            DropForeignKey("dbo.pro_profissional", "pla_codigo", "dbo.pla_plano");
            DropForeignKey("dbo.epr_experiencia_profissional", "pro_codigo", "dbo.pro_profissional");
            DropForeignKey("dbo.epr_experiencia_profissional", "exp_codigo", "dbo.exp_experiencia");
            DropForeignKey("dbo.pro_profissional", "esc_codigo", "dbo.esc_escolaridade");
            DropForeignKey("dbo.ava_avaliacao", "pro_codigo", "dbo.pro_profissional");
            DropIndex("dbo.ava_avaliacao", new[] { "tav_codigo" });
            DropIndex("dbo.usu_usuario", new[] { "tca_codigo" });
            DropIndex("dbo.pro_profissional", new[] { "usu_codigo" });
            DropIndex("dbo.end_endereco", new[] { "usu_codigo" });
            DropIndex("dbo.end_endereco", new[] { "ten_codigo" });
            DropIndex("dbo.dep_depoimento", new[] { "usu_codigo" });
            DropIndex("dbo.cmo_compra_moeda", new[] { "usu_codigo" });
            DropIndex("dbo.mov_movimentacao", new[] { "cmo_codigo" });
            DropIndex("dbo.cmo_compra_moeda", new[] { "moe_codigo" });
            DropIndex("dbo.ava_avaliacao", new[] { "usu_codigo" });
            DropIndex("dbo.rso_redes_sociais", new[] { "pro_codigo" });
            DropIndex("dbo.pha_profissional_habilidade", new[] { "pro_codigo" });
            DropIndex("dbo.pha_profissional_habilidade", new[] { "hab_codigo" });
            DropIndex("dbo.pca_profissional_capacitacao", new[] { "pro_codigo" });
            DropIndex("dbo.pca_profissional_capacitacao", new[] { "cap_codigo" });
            DropIndex("dbo.pla_plano", new[] { "tpl_codigo" });
            DropIndex("dbo.pro_profissional", new[] { "pla_codigo" });
            DropIndex("dbo.epr_experiencia_profissional", new[] { "pro_codigo" });
            DropIndex("dbo.epr_experiencia_profissional", new[] { "exp_codigo" });
            DropIndex("dbo.pro_profissional", new[] { "esc_codigo" });
            DropIndex("dbo.ava_avaliacao", new[] { "pro_codigo" });
            DropTable("dbo.fco_formulario_contato");
            DropTable("dbo.faq_faq");
            DropTable("dbo.tav_tipo_avaliacao");
            DropTable("dbo.tca_tipo_cadastro");
            DropTable("dbo.ten_tipo_endereco");
            DropTable("dbo.end_endereco");
            DropTable("dbo.dep_depoimento");
            DropTable("dbo.mov_movimentacao");
            DropTable("dbo.moe_moeda");
            DropTable("dbo.cmo_compra_moeda");
            DropTable("dbo.usu_usuario");
            DropTable("dbo.rso_redes_sociais");
            DropTable("dbo.hab_habilidade");
            DropTable("dbo.pha_profissional_habilidade");
            DropTable("dbo.cap_capacitacao");
            DropTable("dbo.pca_profissional_capacitacao");
            DropTable("dbo.tpl_tipo_plano");
            DropTable("dbo.pla_plano");
            DropTable("dbo.exp_experiencia");
            DropTable("dbo.epr_experiencia_profissional");
            DropTable("dbo.esc_escolaridade");
            DropTable("dbo.pro_profissional");
            DropTable("dbo.ava_avaliacao");
        }
    }
}
