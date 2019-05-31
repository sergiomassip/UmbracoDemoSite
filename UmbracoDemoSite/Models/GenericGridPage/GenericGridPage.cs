
using Umbraco.Core.Models;
using UmbracoDemoSite.Models.Umbraco;

namespace UmbracoDemoSite.Models
{
    public class GenericGridPageViewModel : GenericGridPage
    {
        public GenericGridPageViewModel(IPublishedContent content) : base(content)
        {
        }
    }
}