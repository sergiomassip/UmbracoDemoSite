using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoDemoSite.Models;

namespace UmbracoDemoSite.Controllers
{
    public class ContactFormController : SurfaceController
    {
        // GET: ContactForm
        public ActionResult Form()
        {
            return View(); 
            //return PartialView("~/Views/ContactForm/Index.cshtml", new ContactFormViewModel());
        }

        [HttpPost]
        public ActionResult HandleContactForm (ContactFormViewModel contact)
        {
            if (ModelState.IsValid)
            {
                // TODO: Email response to the party organizer
                return View("~/Views/ContactForm/Thank.cshtml", contact);
            }
            else
            {
                // there is a validation error
                //return PartialView("~/Views/ContactForm/Form.cshtml", contact);
                return CurrentUmbracoPage();
                //return RedirectToCurrentUmbracoPage();
            }
        }

    }
}