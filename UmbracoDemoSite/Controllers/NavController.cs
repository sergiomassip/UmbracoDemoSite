using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoDemoSite.Models;

namespace UmbracoDemoSite.Controllers
{
    public class NavController : SurfaceController
    {
        NavMenuViewModel model;
        UmbracoHelper umbracoHelper;

        public NavController(UmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;
        }

        // GET: Nav
        public ActionResult NavMenu()
        {
            var nodeMenu = umbracoHelper.TypedContentAtRoot().DescendantsOrSelf("menu").FirstOrDefault();
            model = new NavMenuViewModel(nodeMenu);
            return View(model);
        }
    }
}