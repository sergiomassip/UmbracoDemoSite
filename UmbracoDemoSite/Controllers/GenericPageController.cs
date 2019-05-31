using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoDemoSite.Models;

namespace UmbracoDemoSite.Controllers
{
    public class GenericPageController : RenderMvcController
    {

        private GenericPageViewModel viewModel;

        public GenericPageController(UmbracoContext umbracoContext, UmbracoHelper umbracoHelper) : base(umbracoContext, umbracoHelper)
        {
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Index(RenderModel model,string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                ViewBag.Parameter = parameter;
            }

            //viewModel = new GenericPageViewModel(model.Content);
            viewModel = new GenericPageViewModel(CurrentPage);
            return View(viewModel);
        }

    }
}