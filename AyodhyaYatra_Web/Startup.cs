using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Owin;

[assembly: OwinStartupAttribute(typeof(AyodhyaYatra_Web.Startup))]
namespace AyodhyaYatra_Web
{
    public partial class Startup
    {
        public void Configuration(AppBuilder app)
        {
        }
    }
}
