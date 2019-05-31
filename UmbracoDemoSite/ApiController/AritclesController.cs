using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using UmbracoDemoSite.DTO;
using UmbracoDemoSite.Mapper;
using UmbracoDemoSite.Models.Umbraco;

namespace UmbracoDemoSite.ApiController
{
    public class AritclesApiController : UmbracoApiController
    {
        private readonly UmbracoHelper umbracoHelper;
       
        public AritclesApiController(UmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;           
        }

        //http://localhost:6643/Umbraco/Api/AritclesApi/Get

        public HttpResponseMessage Get(string tagFilter=null)
        {
            try {

                IEnumerable<Article> articles = umbracoHelper.TypedContentAtRoot()
                 .DescendantsOrSelf("Article")
                 .Select(x => new Article(x))
                 .Where(x => x.IsVisible() && x.Categories.Contains(tagFilter));
                 

             
                var results = articles
                    //.Where(x => x.IsVisible())
                    .OrderBy(x => x.UpdateDate)
                    .Select(x => new {
                        Summary = x.Summary.ToString() == null ? null : x.Summary.ToString(),
                        Image = x.Image.Url.ToString() == null ? null : x.Image.Url.ToString(),
                        Body = x.BodyText.ToString() == null ? null : x.BodyText.ToString()
                    });              
                
                //var results = new {
                //    Summary = articles.FirstOrDefault().Summary.ToString()==null ? null : articles.FirstOrDefault().Summary.ToString(),
                //    Image =  articles.FirstOrDefault().Image.Url.ToString() == null ? null : articles.FirstOrDefault().Image.Url.ToString(),
                //    Body = articles.FirstOrDefault().BodyText.ToString()==null ? null : articles.FirstOrDefault().BodyText.ToString()                    
                //};

                return results == null ? Request.CreateErrorResponse(HttpStatusCode.NoContent,"Not articles found") 
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
