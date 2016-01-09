using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppForArmDemo.Startup))]
namespace WebAppForArmDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
