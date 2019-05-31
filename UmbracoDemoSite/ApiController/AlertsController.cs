using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using UmbracoDemoSite.Models.Umbraco;

namespace UmbracoDemoSite.ApiController
{
    public class AlertsApiController : UmbracoApiController
    {
        private readonly UmbracoHelper umbracoHelper;
     
        public AlertsApiController(UmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;          
        }

       // http://localhost:6643/Umbraco/Api/AlertsApi/Get

        public HttpResponseMessage Get()
        {
            try
            {

                IEnumerable<Alert> alerts = umbracoHelper.TypedContentAtRoot()
                 .DescendantsOrSelf("alert")
                 .Where(x => x.IsVisible())
                 .Select(x => new Alert(x));

                var results = alerts
                    .Where(x => x.IsVisible())
                    .OrderBy(x => x.UpdateDate)
                    .Select(x => new {
                        AlertType =  x.AlertType.ToString()== null ? null : x.AlertType.ToString(),            
                        AlertContent = x.AlertContent.ToString() == null ? null : x.AlertContent.ToString().ToString(),                     
                    });
               
                return results == null ? Request.CreateErrorResponse(HttpStatusCode.NoContent, "Not Alert found")
                    : Request.CreateResponse(results);
            }
            catch (Exception ex)
            {
                HttpError error = new HttpError();
                error.Message = ex.Message;
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
            }

        }




    }
}
