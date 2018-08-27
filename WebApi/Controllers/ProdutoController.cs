using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProdutoController : ApiController
    {
        private List<Produto> LerJson()
        {
            try
            {
                List<Produto> retorno;

                using (System.IO.StreamReader st = new System.IO.StreamReader(@"D:\VisualStudio\WebApi\WebApi\DataBase\Produtos.Json"))
                {
                    string DataBase = st.ReadToEnd();

                    retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Produto>>(DataBase);
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public List<Produto> RetornaListaPorNome([FromUri]string pNomeProduto)
        {
            List<Produto> listaProdutos = LerJson();

            if (listaProdutos != null)
            {
                if (pNomeProduto != null || pNomeProduto != "")
                    return listaProdutos.Where(w => w.NomeProduto.StartsWith(pNomeProduto, StringComparison.OrdinalIgnoreCase)).ToList();
                else
                    return listaProdutos;
            }
            else
                return null;
        }

        [HttpGet]
        public List<Produto> RetornaListaProdutos()
        {
            List<Produto> listaProdutos = LerJson();

            return listaProdutos;
        }
    }
}
