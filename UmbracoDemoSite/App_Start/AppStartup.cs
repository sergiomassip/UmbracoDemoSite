using Autofac;
using Microsoft.Owin;
using Owin;
using Umbraco.Core.Security;
using Umbraco.Web;
using Umbraco.Web.Security.Identity;
using UmbracoDemoSite.App_Start;
using Umbraco.Core;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Reflection;
using Umbraco.Core.Models.Identity;
using System.Web.Mvc;
using System.Web.Http;

[assembly: OwinStartup(typeof(AppStartup))]
namespace UmbracoDemoSite.App_Start
{
    public class AppStartup : UmbracoDefaultOwinStartup
    {

        public override void Configuration(IAppBuilder app)
        {

            //ensure the default options are configured
            base.Configuration(app);

            // *** EXPERT: There are several overloads of this method that allow you to specify a custom UserStore or even a custom UserManager!            
            app.ConfigureUserManagerForUmbracoBackOffice(
                ApplicationContext.Current,
                //The Umbraco membership provider needs to be specified in order to maintain backwards compatibility with the 
                // user password formats. The membership provider is not used for authentication, if you require custom logic
                // to validate the username/password against an external data source you can create create a custom UserManager
                // and override CheckPasswordAsync
                MembershipProviderExtensions.GetUsersMembershipProvider().AsUmbracoMembershipProvider());

            //Ensure owin is configured for Umbraco back office authentication
            app
                .UseUmbracoBackOfficeCookieAuthentication(ApplicationContext.Current)
                .UseUmbracoBackOfficeExternalCookieAuthentication(ApplicationContext.Current);


            var builder = new ContainerBuilder();


            // add custom class to the container as Transient instance
            builder.Register(c => UmbracoContext.Current).AsSelf();
            builder.Register(c => new UmbracoHelper(UmbracoContext.Current));

            //register all controllers found in your assembly
            builder.RegisterControllers(Assembly.GetExecutingAssembly()); //Register MVC Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            //register umbraco MVC + webapi controllers used by the admin site
            builder.RegisterControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            //Register any other components required by your code....
            RegisterDependencies(builder);

            var container = builder.Build();

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GetConfiguration().DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
                        
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            //Custom Password Checker
            var applicationContext = ApplicationContext.Current;
            app.ConfigureUserManagerForUmbracoBackOffice<BackOfficeUserManager, BackOfficeIdentityUser>(
            applicationContext,
            (options, context) =>
            {
                var membershipProvider = MembershipProviderExtensions.GetUsersMembershipProvider().AsUmbracoMembershipProvider();
                var settingContent = Umbraco.Core.Configuration.UmbracoConfig.For.UmbracoSettings().Content;
                var userManager = BackOfficeUserManager.Create(options,
                    applicationContext.Services.UserService,
                    applicationContext.Services.EntityService,
                    applicationContext.Services.ExternalLoginService,
                    membershipProvider,
                settingContent);
                // Set your own custom IBackOfficeUserPasswordChecker   
                userManager.BackOfficeUserPasswordChecker = new CustomPasswordChecker();
                return userManager;
            });


        }

        private static System.Web.Http.HttpConfiguration GetConfiguration()
        {
            return System.Web.Http.GlobalConfiguration.Configuration;
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {

        }
    }
}