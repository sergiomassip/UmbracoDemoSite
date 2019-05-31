using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoDemoSite.Models;

namespace UmbracoDemoSite.Controllers
{
    public class GenericGridPageController : RenderMvcController
    {

        private GenericGridPageViewModel viewModel;

        public GenericGridPageController(UmbracoContext umbracoContext, UmbracoHelper umbracoHelper) : base(umbracoContext, umbracoHelper)
        {
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Index(RenderModel model,string origin,string destination)
        {

            if (!string.IsNullOrEmpty(origin))
            {
                ViewBag.Origin = origin;
            }

            if (!string.IsNullOrEmpty(destination))
            {
                ViewBag.Destination = destination;
            }
                       
            viewModel = new GenericGridPageViewModel(CurrentPage);
            //viewModel = new GenericPageViewModel(model.Content);
            return View(viewModel);
        }

    }
}