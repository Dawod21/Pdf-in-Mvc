using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PDFMvc.Startup))]
namespace PDFMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
