using Umbraco.Core;
using Umbraco.Web;

namespace UmbracoDemoSite.App_Start
{
    public class CustomUmbracoApplication : UmbracoApplication
    {
        protected override IBootManager GetBootManager()
        {
            return new CustomWebBootManager(this);
        }

    }
}