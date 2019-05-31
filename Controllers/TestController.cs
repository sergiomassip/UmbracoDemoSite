using System.Web.Mvc;

namespace UmbracoDemoSite.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [OutputCache(Duration = 10)]
        public string Index()
        {
            //var rootNode = umbracoContext.ContentCache.GetById(1052);
            return "Hello World";
        }
    }
}