using log4net;
using System;
using System.Reflection;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoDemoSite.Models;

namespace UmbracoDemoSite.Controllers
{
    public class BannerController:SurfaceController
    {
        private BannerViewModel viewModel;
        private static readonly new ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly UmbracoHelper umbracoHelper;

        public BannerController(UmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;
        }

        [OutputCache(Duration = 180)]
        public PartialViewResult Index(string nodeId)
        {
            try
            {              
                viewModel = new BannerViewModel(umbracoHelper.TypedContent(nodeId));
                return PartialView(viewModel);
            }
            catch (Exception ex)
            {
                Logger.Error("Error in  UmbracoDemoSite.Controllers.Banner.Controller", ex);
                return PartialView(null);
            }
        }
    }
}
