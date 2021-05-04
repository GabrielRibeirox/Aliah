using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaiCaralhoMVC.Models
{
	public class Vendas
	{
		public string Produto { get; set; }
		public string Categoria { get; set; }
		public DateTime Data { get; set; }
		public Double Valor { get; set; }
		public static List<Vendas> ListaVendas()
		{
			List<Vendas> lst = new List<Vendas>();
			lst.Add(new Vendas { Categoria = "Calçados", Data = DateTime.Parse("2020-05-21"), Produto = "Produto1", Valor = 100.00 });
			lst.Add(new Vendas { Categoria = "Vestuário", Data = DateTime.Parse("2020-05-21"), Produto = "Produto2", Valor = 125.36 });
			lst.Add(new Vendas { Categoria = "Vestuário", Data = DateTime.Parse("2020-04-21"), Produto = "Produto2", Valor = 130.45 });
			lst.Add(new Vendas { Categoria = "Calçados", Data = DateTime.Parse("2020-04-21"), Produto = "Produto1", Valor = 110.77 });
			lst.Add(new Vendas { Categoria = "Calçados", Data = DateTime.Parse("2020-04-21"), Produto = "Produto3", Valor = 100.21 });
			lst.Add(new Vendas { Categoria = "Vestuário", Data = DateTime.Parse("2020-03-21"), Produto = "Produto2", Valor = 140.33 });
			lst.Add(new Vendas { Categoria = "Calçados", Data = DateTime.Parse("2020-03-21"), Produto = "Produto1", Valor = 90.55 }); ;
			return lst;
		}
	}
}