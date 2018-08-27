using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? pPagina)
        {
            List<WebApi.Models.Produto> produtos = new List<WebApi.Models.Produto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/WebApi/Produto/");

                var resposta = client.GetAsync("RetornaListaProdutos");
                resposta.Wait();

                HttpResponseMessage resultado = resposta.Result;

                if (resultado.IsSuccessStatusCode)
                {
                    var rest = resultado.Content.ReadAsAsync<List<WebApi.Models.Produto>>();
                    rest.Wait();

                    if (rest.Result != null)
                    {
                        foreach (var item in rest.Result.OrderBy(o => o.Preco))
                        {
                            if (produtos.Where(w => w.MarcaID == item.MarcaID).Count() == 0)
                                produtos.Add(item);
                        }
                    }
                }
            }

            int numeroPaginas = (pPagina ?? 1);

            return View(produtos.ToPagedList(numeroPaginas, 10));
        }
    }
}