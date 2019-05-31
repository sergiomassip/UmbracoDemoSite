using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace UmbracoDemoSite.App_Start
{
    public class CustomWebBootManager : WebBootManager
    {
        public CustomWebBootManager(UmbracoApplicationBase umbracoApplication) : base(umbracoApplication)
        {
        }


        public override IBootManager Complete(Action<ApplicationContext> afterComplete)
        {
            RouteTable.Routes.MapRoute(
                "TestPAge",
                "Test/index",
                new { controller = "Test", action = "index" }
            );

            RouteTable.Routes.MapRoute(
               "TestController",
               "Test",
               new { controller = "Test", action = "index" }
           );
            
         
           RouteTable.Routes.MapUmbracoRoute(
            "GenericCustomRoute",
            "Information/Contact/{parameter}",
            new
            {
                controller = "GenericPage",
                action = "index",
                parameter = UrlParameter.Optional
            },
             new UmbracoVirtualNodeByIdRouteHandler(1139) //Testgeneric 
           );

            RouteTable.Routes.MapUmbracoRoute(
            "PromoRoute",
            "Vuelos-baratos-de-{origin}-a-{destination}",
            new
            {
                controller = "GenericGridPage",
                action = "index",
                origin = UrlParameter.Optional,
                destination= UrlParameter.Optional
            },
             new UmbracoVirtualNodeByIdRouteHandler(1154) //Testgeneric 
           );


            return base.Complete(afterComplete);
        }
    }
}





/*
RouteTable.Routes.MapUmbracoRoute(
   "GenericCustomRoute",
   "Information/Contact/{sku}",
   new
{
       controller = "GenericPage",
       action = "index",
       sku = UrlParameter.Optional
  },
  new UmbracoVirtualNodeByIdRouteHandler(1139) //Testgeneric 
);
*/



//RouteTable.Routes.MapHttpRoute(
//    name: "DefaultApi",
//    routeTemplate: "api/{controller}/{id}",
//    defaults: new { id = RouteParameter.Optional }
//);           