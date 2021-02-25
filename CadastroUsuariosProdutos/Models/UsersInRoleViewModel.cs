using System.Collections.Generic;
using System.Web.Mvc;

namespace CadastroUsuariosProdutos.Models
{
    public class UsersInRoleViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
      
    }
}