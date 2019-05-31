using Umbraco.Core.Models;
using UmbracoDemoSite.Models.Umbraco;

namespace UmbracoDemoSite.Models
{
   
    public class BannerViewModel : Banner
    {
        public BannerViewModel(IPublishedContent content) : base(content)
        {
        }
    }
}