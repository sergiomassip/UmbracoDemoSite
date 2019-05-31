using Umbraco.Core.Models;
using UmbracoDemoSite.Models.Umbraco;

namespace UmbracoDemoSite.Models
{
    public class HomeViewModel : Home
    {
        public HomeViewModel(IPublishedContent content) : base(content)
        {
        }
    }
}