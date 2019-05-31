using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using UmbracoDemoSite.Models.Umbraco;

namespace UmbracoDemoSite.Models
{
    public class GenericPageViewModel : GenericPage
    {
        public GenericPageViewModel(IPublishedContent content) : base(content)
        {
        }      
    }
}