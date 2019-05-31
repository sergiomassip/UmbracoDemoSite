using Umbraco.Core;

namespace UmbracoDemoSite.App_Start
{
    public class RegisterEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {           
           // MediaService.Deleted += MediaServiceDeleted;
        }

    }
}