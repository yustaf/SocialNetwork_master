using Microsoft.Owin;
using Owin;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Context;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(SocialNetwork.WebUI.App_Start.Startup))]


namespace SocialNetwork.WebUI.App_Start
{
    public class Startup
    {
            public void Configuration(IAppBuilder app)
            {
                // настраиваем контекст и менеджер
                app.CreatePerOwinContext<SocialNetworkContext>(SocialNetworkContext.Create);
                app.CreatePerOwinContext<SocialNetworkManager>(SocialNetworkManager.Create);
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                });
            }
        }
    }