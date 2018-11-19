using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiçosExternos.Startup))]
namespace ServiçosExternos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
