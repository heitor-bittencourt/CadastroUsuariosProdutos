using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CadastroUsuariosProdutos.Startup))]
namespace CadastroUsuariosProdutos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
