using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace VaiCaralhoMVC.Models
{
	public class Funcoes
	{
		/// <summary>
		/// Gera Hash SHA1, SHA256, SHA512
		/// </summary>
		/// <param name="texto"></param>
		/// <param name="nomeHash"></param>
		/// <returns></returns>
		public static string HashTexto(string texto, string nomeHash)
		{
			HashAlgorithm algoritmo = HashAlgorithm.Create(nomeHash);
			if (algoritmo == null)
			{
				throw new ArgumentException("Nome de hash incorreto", "nomeHash");
			}
			byte[] hash = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(texto));
			return Convert.ToBase64String(hash);
		}

		public static string GerarGraficoPizza(string titulo, string dados)
		{
			//dados: ['Work', 11],['Eat', 2],['Commute', 2],['Watch TV', 2],['Sleep', 7]
			string graf = @"<script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>
           <script type='text/javascript'>
           google.charts.load('current', {packages:['corechart']});
           google.charts.setOnLoadCallback(drawChart);
           function drawChart() {
           var data = google.visualization.arrayToDataTable([
           ['', ''],
           " + dados + @"
           ]);
           var options = {
           title: '" + titulo + @"',
           is3D: true,
           };
           var chart = new google.visualization.PieChart(document.getElementById('piechart_" + titulo.Replace(" ", "") + @"'));
           chart.draw(data, options);
           }
           </script>
           <div id='piechart_" + titulo.Replace(" ", "") + @"' style='min-height: 500px;'></div>";
			return graf;
		}

		
		public static string GerarGraficoPizza2(string tituloo, string dadoos)
		{
			//dados: ['Work', 11],['Eat', 2],['Commute', 2],['Watch TV', 2],['Sleep', 7]
			string graf = @"
            <script type='text/javascript'>
             google.charts.load('current', {packages:['corechart']});
             google.charts.setOnLoadCallback(drawChart);
             function drawChart() {
             var data = google.visualization.arrayToDataTable([
              ['', ''],
              " + dadoos + @"
               ]);
              var options = {
              title: '" + tituloo + @"',
              is3D: true,
               };
               var chart = new google.visualization.PieChart(document.getElementById('piechart_" + tituloo.Replace(" ", "") + @"'));
               chart.draw(data, options);
                }
               </script>
              <div id='piechart_" + tituloo.Replace(" ", "") + @"' style='min-height: 500px;'></div>";
			return graf;
		}

		public static string GerarGraficoBarraColuna(string titulo, string subtitulo, string dados, bool barra)
		{
			/* Dados
			['Year', 'Sales', 'Expenses', 'Profit'],
			['2014', 1000, 400, 200],
			['2015', 1170, 460, 250],
			['2016', 660, 1120, 300],
			['2017', 1030, 540, 350]
			*/
			string tipo = "";
			if (barra)
				tipo = "bars: 'horizontal'";
			string graf = @"<script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>
            <script type='text/javascript'>
            google.charts.load('current', {'packages':['bar']});
            google.charts.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = google.visualization.arrayToDataTable([
            " + dados + @"
             ]);
            var options = {
            chart: {
            title: '" + titulo + @"',
            subtitle: '" + subtitulo + @"',
            },
            " + tipo + @"
              };
            var chart = new google.charts.Bar(document.getElementById('barchart_" + titulo.Replace(" ", "") + @"'));
           chart.draw(data, google.charts.Bar.convertOptions(options));
           } 
           </script>
          <div id='barchart_" + titulo.Replace(" ", "") + @"' style='min-height: 500px;'></div>";
			return graf;
		}


		public static string EnviarEmail(string emailDestinatario, string assunto, string corpomsg)
		{
			try
			{
				//Cria o endereço de email do remetente
				MailAddress de = new MailAddress("Fatec ADS <recuperar.senha.mvc@gmail.com>");
				//Cria o endereço de email do destinatário -->
				MailAddress para = new MailAddress(emailDestinatario);
				MailMessage mensagem = new MailMessage(de, para);
				mensagem.IsBodyHtml = true;
				//Assunto do email
				mensagem.Subject = assunto;
				//Conteúdo do email
				mensagem.Body = corpomsg;
				//Prioridade E-mail
				mensagem.Priority = MailPriority.Normal;
				//Cria o objeto que envia o e-mail
				SmtpClient cliente = new SmtpClient();
				//Envia o email
				cliente.Send(mensagem);
				return "success|E-mail enviado com sucesso";
			}
			catch { return "error|Erro ao enviar e-mail"; }
		}

		public static string Codifica(string texto)
		{
			byte[] stringBase64 = new byte[texto.Length];
			stringBase64 = Encoding.UTF8.GetBytes(texto);
			string codifica = Convert.ToBase64String(stringBase64);
			return codifica;
		}
		public static string Decodifica(string texto)
		{
			var encode = new UTF8Encoding();
			var utf8Decode = encode.GetDecoder();
			byte[] stringValor = Convert.FromBase64String(texto);
			int contador = utf8Decode.GetCharCount(stringValor, 0, stringValor.Length);
			char[] decodeChar = new char[contador];
			utf8Decode.GetChars(stringValor, 0, stringValor.Length, decodeChar, 0);
			string resultado = new String(decodeChar);
			return resultado;
		}

		
			public static bool CriarDiretorio()
			{
				string dir = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\";
				if (!Directory.Exists(dir))
				{
					//Caso não exista devermos criar
					Directory.CreateDirectory(dir);
					return true;
				}
				else
					return false;
			}
			public static bool ExcluirArquivo(string arq)
			{
				if (File.Exists(arq))
				{
					File.Delete(arq);
					return true;
				}
				else
					return false;
			}
			public static string UploadArquivo(HttpPostedFileBase flpUpload, string nome)
			{
				try
				{
					double permitido = 900;
					if (flpUpload != null)
					{
						string arq = Path.GetFileName(flpUpload.FileName);
						double tamanho = Convert.ToDouble(flpUpload.ContentLength) / 1024;
						string extensao = Path.GetExtension(flpUpload.FileName).ToLower();
						string diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome;
						if (tamanho > permitido)
							return "Tamanho Máximo permitido é de " + permitido + " kb!";
						else if ((extensao != ".png" && extensao != ".jpg"))
							return "Extensão inválida, só são permitidas .png e .jpg!";
						else
						{
							if (!File.Exists(diretorio))
							{
								flpUpload.SaveAs(diretorio);
								return "sucesso";
							}
							else
								return "Já existe um arquivo com esse nome!";
						}
					}
					else
						return "Erro no Upload!";
				}
				catch { return "Erro no Upload"; }

			
		}
	}
}