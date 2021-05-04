using VaiCaralhoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Net;


namespace AliahMVC.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index()
		{

			return View();
		}

		public ActionResult Pagamento(int id)
		{

			Tipo_plano tp = db.Tipo_plano.Find(id);
			
			return View(tp);

		}



		[HttpPost]

        public ActionResult AssinarPlano(string PlanoId)
        {
            Usuario usu;
            int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
            usu = db.Usuario.Find(id);
            if (usu.Tipo_cadastroId == 3)
            {
                var pro = usu.Profissional.FirstOrDefault();
                var plano = pro.Planos.OrderBy(x => x.Data_termino).LastOrDefault();
                var date = plano.Data_termino;
                Plano pla = new Plano();
                var planoid = Convert.ToInt32(PlanoId);

                Tipo_plano tpl = db.Tipo_plano.Find(planoid);
                pla.Profissional = pro;
                pla.Tipo_plano = tpl;
                
               
                if (date < DateTime.Now)
                {
                    pla.Data_termino = DateTime.Now.AddDays(tpl.QuantidadeDias);
                    pla.Data_inicio = DateTime.Now;

                }

                else
                {
                    pla.Data_inicio = date.AddDays(1);
                    pla.Data_termino = date.AddDays(tpl.QuantidadeDias + 1);

                }
                db.Plano.Add(pla);
                db.SaveChanges();
                TempData["MSG"] = "success| plano adquirido!";
            }
            else
                TempData["MSG"] = "warning| Faça seu cadastro de profissional!";


            return RedirectToAction("Tipo_plano", "Home");
        }


		[HttpPost]
		public ActionResult ComprarVisualizacao(string ProId)
		{
			Usuario usu;
			int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
			usu = db.Usuario.Find(id);
			var movimentacao = new Movimentacao();
			movimentacao.UsuarioId = usu.Id;
			movimentacao.ProfissionalId = Convert.ToInt32(ProId);
			movimentacao.Descricao = "Compra Visualização";
			movimentacao.Quantidade = 1;
			movimentacao.Data = DateTime.Now;

			double cmo = db.Compra_moeda.Where(y => y.UsuarioId == id).ToList().Sum(x => Convert.ToDouble(x.Quantidade));
			double cm = db.Movimentacao.Where(y => y.UsuarioId == id).ToList().Sum(x => Convert.ToDouble(x.Quantidade));
			if((cmo - cm ) >= 1)
			{
				db.Movimentacao.Add(movimentacao);
				db.SaveChanges();
				TempData["MSG"] = "success| Perfil liberado com sucesso";
				return RedirectToAction("DetalheProfissional/" + ProId, "Home");
			}
			else
			{
				TempData["MSG"] = "warning| Saldo insuficiente, Adquira moedas!";
                return RedirectToAction("Tipo_plano", "Home");
            }
						
			return RedirectToAction("Profissional", "Home");
		}


		[HttpPost]
        public ActionResult ComprarMoeda(string MoedaId)
        {
            Usuario usu;
            int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
            usu = db.Usuario.Find(id);
            if (usu.Tipo_cadastroId == 3 || usu.Tipo_cadastroId == 2)
            {
                var compra_moedaid = Convert.ToInt32(MoedaId);
                Moeda moe = db.Moeda.Find(compra_moedaid);
                Compra_moeda cmo = new Compra_moeda();
                cmo.MoedaId = Convert.ToInt32(MoedaId);
                cmo.Quantidade = moe.Quantidade;
                cmo.Data = DateTime.Now.ToString("dd/MM/yyyy");
                cmo.Usuario = usu;
                cmo.Valor = moe.Valor;
                db.Compra_moeda.Add(cmo);
                db.SaveChanges();
                TempData["MSG"] = "success| moeda adquirida!";
            }
            else
                TempData["MSG"] = "warning| Faça seu cadastro de profissiona!";


            return RedirectToAction("Tipo_plano", "Home");
        }



        public ActionResult PartialProfissional()
        {

            return View();
        }

        public ActionResult PartialCliente()
        {

            return View();
        }

        public ActionResult UsuarioInfo()
        {

            int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
            var pro = db.Usuario.Where(x => x.Id == id).ToList().FirstOrDefault();
            return View(pro);
        }


        public ActionResult ProfissionalInfo()
        {


            int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
            var pro = db.Usuario.Where(x => x.Id == id).ToList().FirstOrDefault();
            return View(pro);

        }

        public ActionResult MeusPlanos()
        {


            int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
            var pro = db.Usuario.Where(x => x.Id == id).ToList().FirstOrDefault();
            return View(pro);

        }

		public ActionResult MinhasMoedas()
		{


			int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
			var pro = db.Usuario.Where(x => x.Id == id).ToList().FirstOrDefault();

			var qntmoedas = db.Compra_moeda.Where(y => y.UsuarioId  == id).ToList().Sum(x => Convert.ToDouble(x.Quantidade));
			var qntmov =    db.Movimentacao.Where(y => y.UsuarioId == id).ToList().Sum(x => Convert.ToDouble(x.Quantidade));
			ViewBag.moeda = ("Quantidade de moedas: " + (qntmoedas - qntmov).ToString());


			return View(pro);

		}

		public ActionResult Historico()
		{


			int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
			var pro = db.Usuario.Where(x => x.Id == id).ToList().FirstOrDefault();
			return View(pro);

		}


		public ActionResult MeuPerfil()
        {


            int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
            var pro = db.Usuario.Where(x => x.Id == id).ToList().FirstOrDefault();
            return View(pro);

        }

        public ActionResult MeuPerfilUsuario()
        {


            int id = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
            var pro = db.Usuario.Where(x => x.Id == id).ToList().FirstOrDefault();
            return View(pro);

        }



        public ActionResult Tipo_plano()
        {

            PlanoMoeda pm = new PlanoMoeda();
            pm.Planos = db.Tipo_plano.Where(x => x.status != "2").ToList();
            pm.Moedas = db.Moeda.ToList();
            return View(pm);
        }




        public ActionResult Grafico()
        {

            //		var resultado1 = Vendas.ListaVendas().GroupBy(x => x.Produto).Select(g => new { g.Key, TotalVendas = g.Sum(x => x.Valor) });
            //		string dados = "";
            //	dados: ['Work', 11],['Eat', 2],['Commute', 2],['Watch TV', 2],['Sleep', 7]
            //		foreach (var item in resultado1)
            //		{
            //			dados += "['" + item.Key + "'," + item.TotalVendas.ToString().Replace(",", ".") + "],";
            //		}
            //dados = dados.Substring(0, dados.Length - 1);
            //		ViewBag.GraficoPizza = Funcoes.GerarGraficoPizza("Total de Vendas por Produto", dados);

            var resultado4 = db.Usuario.ToList().GroupBy(x => x.Tipo_cadastro.Descricao).Select(g => new { g.Key, TotalUsuario = g.Count() });
            string dadoos = "";
            // dados: ['Work', 11],['Eat', 2],['Commute', 2],['Watch TV', 2],['Sleep', 7]
            foreach (var item in resultado4)
            {
                dadoos += "['" + item.Key + "'," + item.TotalUsuario.ToString().Replace(",", ".") + "],";
            }
            dadoos = dadoos.Substring(0, dadoos.Length - 1);
            ViewBag.GraficoPizza = Funcoes.GerarGraficoPizza("Total de Usuários por tipo de cadastro", dadoos);



            //-- Para os próximos gráficos (barra e coluna) vamos carregar os dados no formato abaixo --
            /* Dados
			['Year', 'Sales', 'Expenses', 'Profit'],
			['2014', 1000, 400, 200],
			['2015', 1170, 460, 250],
			['2016', 660, 1120, 300],
			['2017', 1030, 540, 350]
			*/
            var resultado2 = Vendas.ListaVendas().GroupBy(x => x.Categoria).Select(g => new { g.Key, TotalVendas = g.Sum(x => x.Valor) });
            string dadostopo2 = "[''";
            string dadoscorpo2 = "['Categorias'";
            foreach (var item in resultado2)
            {
                dadostopo2 += ",'" + item.Key + "'";
                dadoscorpo2 += "," + item.TotalVendas.ToString().Replace(",", ".");
            }
            dadostopo2 += "],";
            dadoscorpo2 += "]";
            ViewBag.GraficoColuna = Funcoes.GerarGraficoBarraColuna("Total de Vendas por Categoria", "", dadostopo2 + dadoscorpo2, false);
            //------------------------------------------------------------------
            var resultado3 = Vendas.ListaVendas().GroupBy(x => new { x.Data.Month, x.Categoria }).Select(g => new { g.Key.Month, g.Key.Categoria, TotalVendas = g.Sum(x => x.Valor) }).OrderBy(x => x.Month).ThenBy(x => x.Categoria);
            var categorias = resultado3.OrderBy(x => x.Categoria).Select(x => x.Categoria).Distinct().ToList();
            var meses = resultado3.OrderBy(x => x.Month).Select(x => x.Month).Distinct().ToList();
            string dadostopo3 = "['Mês','" + string.Join("','", categorias.ToArray()) + "'],";
            string dadoscorpo3 = "";
            foreach (var m in meses)
            {
                dadoscorpo3 += "['" + DateTimeFormatInfo.CurrentInfo.GetMonthName(m) + "',";
                foreach (var item in resultado3.Where(x => x.Month == m).ToList())
                {
                    dadoscorpo3 += item.TotalVendas.ToString().Replace(",", ".") + ",";
                }
                dadoscorpo3 = dadoscorpo3.Substring(0, dadoscorpo3.Length - 1);
                dadoscorpo3 += "],";
            }
            dadoscorpo3 = dadoscorpo3.Substring(0, dadoscorpo3.Length - 1);
            ViewBag.GraficoBarra = Funcoes.GerarGraficoBarraColuna("Total de Vendas", "Vendas por período", dadostopo3 + dadoscorpo3, true);
            return View(); ;
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contato()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contato(Formulario_contato fc)
        {
            if (ModelState.IsValid)
            {
                db.Formulario_contato.Add(fc);
                db.SaveChanges();
                TempData["MSG"] = "success|Enviado com sucesso! Em breve entraremos em contato";
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Cadastro()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// 
        /// 
        /// Video aula 
        /// 
        /// 
        public ActionResult Cadastrar()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private Contexto db = new Contexto();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Cadastrar cad)
        {
            if (ModelState.IsValid)
            {
                if (db.Usuario.Where(x => x.Email == cad.Email).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "E-mail já utilizado!");
                    return View(cad);
                }
                Usuario upe = new Usuario();
                Endereco end = new Endereco();

                upe.Nome = cad.Nome;
                upe.Status = "1";
                upe.Sexo = cad.Sexo;
                upe.Telefone = cad.Telefone;
                upe.Celular = cad.Celular;
                upe.Cpf = cad.Cpf;
                upe.Data_nascimento = cad.Data_nascimento;
                upe.Email = cad.Email;
                upe.Senha = Funcoes.HashTexto(cad.Senha, "SHA512");
                upe.Tipo_cadastro = db.Tipo_cadastro.Find(2);
                if (upe.Tipo_cadastro == null)
                {
                    ModelState.AddModelError("", "Não existe o perfil para cadastro");
                    return View(cad);
                }
                end.Usuario = upe;
                end.Numero = cad.Numero;
                end.Rua = cad.Rua;
                end.Cep = cad.Cep;
                end.Cidade = cad.Cidade;
                end.Estado = cad.Estado;
                end.Bairro = cad.Bairro;
                end.Tipo_endereco = db.Tipo_endereco.Where(x => x.Descricao == "Residencial").ToList().FirstOrDefault();
                if (end.Tipo_endereco == null)
                {
                    end.Tipo_endereco = new Tipo_endereco();
                    end.Tipo_endereco.Descricao = "Residencial";
                }
                UsuarioPerfil usup = new UsuarioPerfil();
                usup.Usuarios = upe;
                usup.TipoCadastro = db.Tipo_cadastro.Find(2);
                db.Endereco.Add(end);
                db.UsuarioPerfil.Add(usup);
                //db.Usuario.Add(upe);
                db.SaveChanges();
                TempData["MSG"] = "success|Cadastro efetuado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(cad);
        }


        public ActionResult CadastroProfissional()
        {

            CadastrarProfissional cp = new CadastrarProfissional();
            cp.listaHabilidade = new List<CheckBoxListHabilidade>();
            cp.listaCapacitacao = new List<CheckBoxListCapacitacao>();

            foreach (var item in db.Habilidade.ToList())
            {
                CheckBoxListHabilidade check = new CheckBoxListHabilidade();
                check.ID = item.Id;
                check.Display = item.Descricao;
                cp.listaHabilidade.Add(check);

            }

            foreach (var item in db.Capacitacao.ToList())
            {
                CheckBoxListCapacitacao check = new CheckBoxListCapacitacao();
                check.ID = item.Id;
                check.Display = item.Descricao;
                cp.listaCapacitacao.Add(check);

            }


            return View(cp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroProfissional(CadastrarProfissional cad, HttpPostedFileBase Foto, HttpPostedFileBase Comprovante, HttpPostedFileBase Antecedentes)
        {
            if (ModelState.IsValid)
            {
                if (db.Usuario.Where(x => x.Email == cad.Email).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "E-mail já utilizado!");
                    return View(cad);
                }
                Usuario upe = new Usuario();
                Endereco end = new Endereco();

                upe.Nome = cad.Nome;
                upe.Status = "2";
                upe.Sexo = cad.Sexo;
                upe.Telefone = cad.Telefone;
                upe.Celular = cad.Celular;
                upe.Cpf = cad.Cpf;
                upe.Data_nascimento = cad.Data_nascimento;
                upe.Email = cad.Email;
                upe.Senha = Funcoes.HashTexto(cad.Senha, "SHA512");
                upe.Tipo_cadastro = db.Tipo_cadastro.Find(3);
                if (upe.Tipo_cadastro == null)
                {
                    ModelState.AddModelError("", "Não existe o perfil para cadastro");
                    return View(cad);
                }
                end.Usuario = upe;
                end.Numero = cad.Numero;
                end.Rua = cad.Rua;
                end.Cep = cad.Cep;
                end.Cidade = cad.Cidade;
                end.Estado = cad.Estado;
                end.Bairro = cad.Bairro;
                end.Tipo_endereco = db.Tipo_endereco.Where(x => x.Descricao == "Residencial").ToList().FirstOrDefault();
                if (end.Tipo_endereco == null)
                {
                    end.Tipo_endereco = new Tipo_endereco();
                    end.Tipo_endereco.Descricao = "Residencial";
                }
                Profissional pro = new Profissional();
                pro.Usuario = upe;
                pro.Antecedentes_criminais = cad.Antecedentes_criminais;
                pro.Comprovante_residencia = cad.Comprovante_residencia;
                pro.Disponibilidade = cad.Disponibilidade;
                pro.Experiencia = cad.Experiencia;
                pro.Foto_perfil = cad.Foto_perfil;
                pro.Profissao = cad.Profissao;
                pro.Escolaridade = new Escolaridade();
                pro.Escolaridade.Certificado = cad.Certificado;
                pro.Escolaridade.Curso = cad.Curso;
                pro.Escolaridade.Data_inicio = cad.Data_inicio;
                pro.Escolaridade.Data_termino = cad.Data_termino;
                pro.Escolaridade.Instituicao = cad.Instituicao;
                pro.Escolaridade.Modalidade = cad.Modalidade;
                pro.Escolaridade.Nivel = cad.Nivel;
                pro.Escolaridade.Status = cad.Status;
                Plano pla = new Plano();
                var tipoPlano = db.Tipo_plano.Find(4);
                pla.Tipo_planoId = 4;
                pla.Data_inicio = DateTime.Now;
                pla.Data_termino = DateTime.Now.AddDays(tipoPlano.QuantidadeDias);
                pla.Profissional = pro;
                pro.Profissional_Capacitacao = new List<Profissional_capacitacao>();
                pro.Profissional_habilidade = new List<Profissional_habilidade>();
                foreach (var item in cad.listaCapacitacao)
                {
                    if (item.IsChecked)
                    {
                        Profissional_capacitacao pc = new Profissional_capacitacao();
                        pc.CapacitacaoId = item.ID;
                        pc.Profissional = pro;
                        pro.Profissional_Capacitacao.Add(pc);
                    }

                }

                foreach (var item in cad.listaHabilidade)
                {
                    if (item.IsChecked)
                    {
                        Profissional_habilidade ph = new Profissional_habilidade();
                        ph.HabilidadeId = item.ID;
                        ph.Profissional = pro;
                        pro.Profissional_habilidade.Add(ph);
                    }

                }



                try
                {
                    Funcoes.CriarDiretorio();
                    string foto = "Foto" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(Foto.FileName).ToLower();
                    string comprovante = "Comprovante" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(Comprovante.FileName).ToLower();
                    string antecedentes = "Antecedentes" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(Antecedentes.FileName).ToLower();
                    //string certificad = "Certificad" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(Certificad.FileName).ToLower();

                    if (Funcoes.UploadArquivo(Foto, foto) == "sucesso" && Funcoes.UploadArquivo(Comprovante, comprovante) == "sucesso" && Funcoes.UploadArquivo(Antecedentes, antecedentes) == "sucesso" /*&& Funcoes.UploadArquivo(Certificad, certificad) == "sucesso"*/)
                    {
                        pro.Foto_perfil = foto;
                        pro.Comprovante_residencia = comprovante;
                        pro.Antecedentes_criminais = antecedentes;
                        //pro.Escolaridade.Certificado = certificad;
                    }
                    else
                    {
                        throw new Exception();
                    }



                }

                catch
                {
                    cad.listaHabilidade = new List<CheckBoxListHabilidade>();
                    cad.listaCapacitacao = new List<CheckBoxListCapacitacao>();

                    foreach (var item in db.Habilidade.ToList())
                    {
                        CheckBoxListHabilidade check = new CheckBoxListHabilidade();
                        check.ID = item.Id;
                        check.Display = item.Descricao;
                        cad.listaHabilidade.Add(check);

                    }

                    foreach (var item in db.Capacitacao.ToList())
                    {
                        CheckBoxListCapacitacao check = new CheckBoxListCapacitacao();
                        check.ID = item.Id;
                        check.Display = item.Descricao;
                        cad.listaCapacitacao.Add(check);

                    }

                    TempData["MSG"] = "error|Erro ao cadastrar foto!";

                    return View(cad);

                }
                UsuarioPerfil usup = new UsuarioPerfil();
                usup.Usuarios = upe;
                usup.TipoCadastro = db.Tipo_cadastro.Find(3);
                db.UsuarioPerfil.Add(usup);
                db.Endereco.Add(end);
                db.Profissional.Add(pro);
                db.Plano.Add(pla);
                //db.Usuario.Add(upe);
                db.SaveChanges();
                TempData["MSG"] = "success|Cadastro efetuado com sucesso!";
                return RedirectToAction("Index");
            }
            cad.listaHabilidade = new List<CheckBoxListHabilidade>();
            cad.listaCapacitacao = new List<CheckBoxListCapacitacao>();

            foreach (var item in db.Habilidade.ToList())
            {
                CheckBoxListHabilidade check = new CheckBoxListHabilidade();
                check.ID = item.Id;
                check.Display = item.Descricao;
                cad.listaHabilidade.Add(check);

            }

            foreach (var item in db.Capacitacao.ToList())
            {
                CheckBoxListCapacitacao check = new CheckBoxListCapacitacao();
                check.ID = item.Id;
                check.Display = item.Descricao;
                cad.listaCapacitacao.Add(check);

            }


            return View(cad);
        }




        public ActionResult Acesso()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Acesso(Acesso ace, string ReturnUrl)
        {
            string senhacrip = Funcoes.HashTexto(ace.Senha, "SHA512");
            Usuario usu = db.Usuario.Where(t => t.Email == ace.Email && t.Senha == senhacrip).ToList().FirstOrDefault();
            if (usu != null)
            {
                if (usu.Tipo_cadastroId == 2 || usu.Tipo_cadastroId == 3)
                {
                    ////FormsAuthentication.SetAuthCookie(usu.Nome + "|" +usu.Id, false);
                    //return RedirectToAction("Index", "Home");
                    string permissoes = "";
                    foreach (UsuarioPerfil p in usu.UsuarioPerfil) permissoes += p.TipoCadastro.Descricao + ",";
                    permissoes = permissoes.Substring(0, permissoes.Length - 1);
                    FormsAuthentication.SetAuthCookie(usu.Nome + "|" + usu.Id + "|" + usu.Tipo_cadastroId + "|" + usu.Tipo_cadastro.Descricao, false);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usu.Nome + "|" + usu.Id + "|" + usu.Tipo_cadastroId + "|" + usu.Tipo_cadastro.Descricao, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                    string hash = FormsAuthentication.Encrypt(ticket);


                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    if (ticket.IsPersistent) cookie.Expires = ticket.Expiration; Response.Cookies.Add(cookie);


                    if (String.IsNullOrEmpty(ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    else
                    {
                        var decodedUrl = Server.UrlDecode(ReturnUrl);
                        if (Url.IsLocalUrl(decodedUrl)) return Redirect(decodedUrl);
                        else return RedirectToAction("Index", "Home");
                    }
                }
                if (usu.Tipo_cadastroId == 1)
                {
                    ////FormsAuthentication.SetAuthCookie(usu.Nome + "|" +usu.Id, false);
                    //return RedirectToAction("Index", "Home");
                    string permissoes = "";
                    foreach (UsuarioPerfil p in usu.UsuarioPerfil) permissoes += p.TipoCadastro.Descricao + ",";
                    permissoes = permissoes.Substring(0, permissoes.Length - 1);
                    FormsAuthentication.SetAuthCookie(usu.Nome + "|" + usu.Id + "|" + usu.Tipo_cadastroId + "|" + usu.Tipo_cadastro.Descricao, false);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usu.Nome + "|" + usu.Id + "|" + usu.Tipo_cadastroId + "|" + usu.Tipo_cadastro.Descricao, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                    string hash = FormsAuthentication.Encrypt(ticket);


                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    if (ticket.IsPersistent) cookie.Expires = ticket.Expiration; Response.Cookies.Add(cookie);


                    if (String.IsNullOrEmpty(ReturnUrl))
                        return RedirectToAction("Index", "Administrador");
                    else
                    {
                        var decodedUrl = Server.UrlDecode(ReturnUrl);
                        if (Url.IsLocalUrl(decodedUrl)) return Redirect(decodedUrl);
                        else return RedirectToAction("Index", "Administrador");
                    }


                }
                else
                {
					
					return View();
                }
            }
            else { 
            ModelState.AddModelError("", "Usuário/Senha inválidos");
            return View();
            }
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Email()
        {
            return View();
        }
        // GET: Usuarios/Edit/5
        public ActionResult EditContato(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_cadastroId = new SelectList(db.Tipo_cadastro, "Id", "Descricao", usuario.Tipo_cadastroId);
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContato([Bind(Include = "Id,Nome,Cpf,Data_nascimento,Sexo,Email,Senha,Celular,Telefone,Status,Hash,Tipo_cadastroId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                TempData["MSG"] = "success|Perfil atualizado com sucesso!";
                return RedirectToAction("MeuPerfilUsuario");
            }
            ViewBag.Tipo_cadastroId = new SelectList(db.Tipo_cadastro, "Id", "Descricao", usuario.Tipo_cadastroId);
            return View(usuario);
        }

        public ActionResult EditEnd(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_enderecoId = new SelectList(db.Tipo_endereco, "Id", "Descricao", endereco.Tipo_enderecoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", endereco.UsuarioId);
            return View(endereco);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEnd([Bind(Include = "Id,Rua,Numero,Bairro,Cidade,Cep,Estado,UsuarioId,Tipo_enderecoId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_enderecoId = new SelectList(db.Tipo_endereco, "Id", "Descricao", endereco.Tipo_enderecoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", endereco.UsuarioId);
            return View(endereco);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Email(Mensagem msg)
        {
            if (ModelState.IsValid)
            {
				
				TempData["MSG"] = Funcoes.EnviarEmail(msg.Email, msg.Assunto, msg.CorpoMsg);
                return RedirectToAction("Email");
            }
            TempData["MSG"] = "warning|Preencha todos os campos";
            return View();
        }

        public ActionResult EsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EsqueceuSenha(EsqueceuSenha esq)
        {
            if (ModelState.IsValid)
            {
                Contexto db = new Contexto();
                var usu = db.Usuario.Where(x => x.Email == esq.Email).ToList().FirstOrDefault();
                if (usu != null)
                {
                    usu.Hash = Funcoes.Codifica(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss.ffff"));
                    db.Entry(usu).State = EntityState.Modified;
                    db.SaveChanges();
                    string msg = "<h3>Sistema</h3>";
                    msg += "Para alterar sua senha <a href='http://localhost:56622/Home/Redefinir/" + usu.Hash + "' target='_blank'>clique aqui</a>";
                    Funcoes.EnviarEmail(usu.Email, "Redefinição de senha", msg);
                    TempData["MSG"] = "success|Redefinição enviada no email!";
                    return RedirectToAction("Index");
                }
                TempData["MSG"] = "error|E-mail não encontrado";
                return View();
            }
            TempData["MSG"] = "warning|Preencha todos os campos";
            return View();
        }

        public ActionResult Redefinir(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                Contexto db = new Contexto();
                var usu = db.Usuario.Where(x => x.Hash == id).ToList().FirstOrDefault();
                if (usu != null)
                {
                    try
                    {
                        DateTime dt = Convert.ToDateTime(Funcoes.Decodifica(usu.Hash));
                        if (dt > DateTime.Now)
                        {
                            RedefinirSenha red = new RedefinirSenha();
                            red.Hash = usu.Hash;
                            red.Email = usu.Email;
                            return View(red);
                        }
                        TempData["MSG"] = "warning|Esse link já expirou!";
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        TempData["MSG"] = "error|Hash inválida!";
                        return RedirectToAction("Index");
                    }
                }
                TempData["MSG"] = "error|Hash inválida!";
                return RedirectToAction("Index");
            }
            TempData["MSG"] = "error|Acesso inválido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Redefinir(RedefinirSenha red)
        {
            if (ModelState.IsValid)
            {
                Contexto db = new Contexto();
                var usu = db.Usuario.Where(x => x.Hash == red.Hash).ToList().FirstOrDefault();
                if (usu != null)
                {
                    usu.Hash = null;
                    usu.Senha = Funcoes.HashTexto(red.Senha, "SHA512");
                    db.Entry(usu).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["MSG"] = "success|Senha redefinida com sucesso!";
                    return RedirectToAction("Index");
                }
                TempData["MSG"] = "error|E-mail não encontrado";
                return View(red);
            }
            TempData["MSG"] = "warning|Preencha todos os campos";
            return View(red);
        }

        /// 
        /// 
        /// Fim video aula
        /// 
        /// 

        public ActionResult Contratar()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Profissional()
        {
            List<Profissional> cp = new List<Profissional>();

            cp = db.Profissional.Where(x => x.Usuario.Status == "3" && x.Planos.Where(y=> y.Data_inicio <= DateTime.Now && y.Data_termino >= DateTime.Now).ToList().Count>0).ToList();
            //var p = db.Plano.Where(y => y.Data_inicio <= DateTime.Now && y.Data_termino >= DateTime.Now).ToList(); 
          
            return View(cp);
        }

        [Authorize(Roles = CustomRoles.AdministratorOrUser)]
        public ActionResult DetalheProfissional(int? id)
        {

			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissional profissional = db.Profissional.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
			if (User.Identity.IsAuthenticated)
			{
				
				int usuid = Convert.ToInt32(User.Identity.Name.Split('|')[1]);
				var user = db.Usuario.Find(usuid);
				if (db.Movimentacao.Where(x => x.ProfissionalId == id && x.UsuarioId == usuid).ToList().Count > 0)
					return View(profissional);
				else
					return RedirectToAction("Tipo_plano", "Home");

			}
			return RedirectToAction("Index", "Home");


		}

        public ActionResult Faq()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Planos()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AtivarPerfil(int? Id)
        {
            if (Id != null)
            {
                Usuario usu = db.Usuario.Find(Id);
                if (usu != null)
                {
                    usu.Status = "2";
                    db.Entry(usu).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            TempData["MSG"] = "success|Solicitação enviada com sucesso!";
            return RedirectToAction("ProfissionalInfo");
        }
        public ActionResult DesativarPerfil(int? Id)
        {
            if (Id != null)
            {
                Usuario usu = db.Usuario.Find(Id);
                if (usu != null)
                {
                    usu.Status = "4";
                    db.Entry(usu).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
			TempData["MSG"] = "warning| Perfil desativado!";
			return RedirectToAction("ProfissionalInfo");
        }




    }

    public class AdministradorController : Controller
    {
        Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]

        public ActionResult AprovarProfissional()
        {
            var lista = db.Profissional.Where(x => x.Usuario.Status == "2").ToList();

            return View(lista);
        }
        public ActionResult DetalheAprovacao(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Profissional profissional = db.Profissional.Find(id);

            if (profissional == null)
            {
                return HttpNotFound();
            }
            return View(profissional);
        }


        [Authorize(Roles = "Administrador")]

        public ActionResult Aprovar(int? Id)
        {
            if (Id != null)
            {
                Profissional pro = db.Profissional.Find(Id);
                if (pro != null)
                {
                    pro.Usuario.Status = "3";
                    db.Entry(pro.Usuario).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("AprovarProfissional");
        }
        [Authorize(Roles = "Administrador")]

        public ActionResult Reprovar(int? Id)
        {
            if (Id != null)
            {
                Profissional pro = db.Profissional.Find(Id);
                if (pro != null)
                {
                    pro.Usuario.Status = "4";
                    db.Entry(pro.Usuario).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("AprovarProfissional");
        }

        [Authorize(Roles = "Administrador")]

        public ActionResult Email()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
			var usuario = db.Usuario.ToList().Count();
			ViewBag.usuario =  usuario;

			var profissional = db.Profissional.ToList().Count();
			ViewBag.profissional = profissional;

			var plano = db.Plano.ToList().Sum(x=>Convert.ToDouble( x.Tipo_plano.Valor));
			ViewBag.plano = plano;

			var moeda = db.Compra_moeda.ToList().Sum(x => Convert.ToDouble(x.Valor));
			ViewBag.moeda = moeda;

			var resultado4 = db.Usuario.ToList().GroupBy(x => x.Tipo_cadastro.Descricao).Select(g => new { g.Key, TotalUsuario = g.Count() });
            string dadoos = "";
            foreach (var item in resultado4)
            {
                dadoos += "['" + item.Key + "'," + item.TotalUsuario.ToString().Replace(",", ".") + "],";
            }
            dadoos = dadoos.Substring(0, dadoos.Length - 1);
            ViewBag.GraficoPizza = Funcoes.GerarGraficoPizza("Total de Usuários por tipo de cadastro", dadoos);




            var resultado2 = db.Plano.ToList().GroupBy(x => x.Tipo_plano.Nome).Select(g => new { g.Key, TotalVendas = g.Sum(x => Convert.ToDouble(x.Tipo_plano.Valor)) });
            string dadostopo2 = "[''";
            string dadoscorpo2 = "['Categorias'";
            foreach (var item in resultado2)
            {
                dadostopo2 += ",'" + item.Key + "'";
                dadoscorpo2 += "," + item.TotalVendas.ToString().Replace(",", ".");
            }
            dadostopo2 += "],";
            dadoscorpo2 += "]";
            ViewBag.GraficoColuna = Funcoes.GerarGraficoBarraColuna("Total de Vendas por Categoria", "", dadostopo2 + dadoscorpo2, false);
            //------------------------------------------------------------------//
            var resultado3 = Vendas.ListaVendas().GroupBy(x => new { x.Data.Month, x.Categoria }).Select(g => new { g.Key.Month, g.Key.Categoria, TotalVendas = g.Sum(x => x.Valor) }).OrderBy(x => x.Month).ThenBy(x => x.Categoria);
            var categorias = resultado3.OrderBy(x => x.Categoria).Select(x => x.Categoria).Distinct().ToList();
            var meses = resultado3.OrderBy(x => x.Month).Select(x => x.Month).Distinct().ToList();
            string dadostopo3 = "['Mês','" + string.Join("','", categorias.ToArray()) + "'],";
            string dadoscorpo3 = "";
            foreach (var m in meses)
            {
                dadoscorpo3 += "['" + DateTimeFormatInfo.CurrentInfo.GetMonthName(m) + "',";
                foreach (var item in resultado3.Where(x => x.Month == m).ToList())
                {
                    dadoscorpo3 += item.TotalVendas.ToString().Replace(",", ".") + ",";
                }
                dadoscorpo3 = dadoscorpo3.Substring(0, dadoscorpo3.Length - 1);
                dadoscorpo3 += "],";
            }
            dadoscorpo3 = dadoscorpo3.Substring(0, dadoscorpo3.Length - 1);
            ViewBag.GraficoBarra = Funcoes.GerarGraficoBarraColuna("Total de Vendas", "Vendas por período", dadostopo3 + dadoscorpo3, true);




            return View(); ;
        }
    }
}