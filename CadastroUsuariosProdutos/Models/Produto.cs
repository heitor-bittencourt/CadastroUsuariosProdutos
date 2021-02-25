using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuariosProdutos.Models
{
    public class Produto
    {        
        public int ProdutoId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false)]
        public decimal Valor { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Tipo { get; set; }       
        
        //public ApplicationUser User { get; set; }
    }

    
}