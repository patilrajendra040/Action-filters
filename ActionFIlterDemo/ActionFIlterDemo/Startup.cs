using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ActionFIlterDemo.Startup))]
namespace ActionFIlterDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
