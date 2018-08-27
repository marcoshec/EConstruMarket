using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Produto
    {
        private int _produtoID { get; set; }
        private int _marcaID { get; set; }
        private string _nomeMarca { get; set; }
        private string _nomeProduto { get; set; }
        private float _preco { get; set; }

        public virtual int ProdutoID
        {
            get { return _produtoID; }
            set { _produtoID = value; }
        }

        public virtual int MarcaID
        {
            get { return _marcaID; }
            set { _marcaID = value; }
        }

        public virtual string NomeMarca
        {
            get { return _nomeMarca; }
            set { _nomeMarca = value; }
        }

        public virtual string NomeProduto
        {
            get { return _nomeProduto; }
            set { _nomeProduto = value; }
        }

        public virtual float Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }
    }
}