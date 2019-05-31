using Umbraco.Core.Models;
using UmbracoDemoSite.Models.Umbraco;

namespace UmbracoDemoSite.Models
{
    public partial class NavMenuViewModel : Menu
    {
        public string Prop1 { get; set; }

        public NavMenuViewModel(IPublishedContent content) : base(content)
        {
            Prop1="Hello World";
        }
    }
}