using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroUsuariosProdutos.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}