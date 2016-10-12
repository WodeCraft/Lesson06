using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace RouteExamples
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Q2
            routes.MapRoute(
                name: "IdRequired",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index" }
            );

            // Q3
            routes.MapRoute(
                name: "IdOptionalDefault",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = "100" }
            );

            // Q4
            routes.MapRoute(
                name: "IdOptionalInt",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = new IntRouteConstraint() }
                // constraints: new { id = @"\d+" }
            );

            // Q5
            routes.MapRoute(
                name: "IdOptionalRange",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = new RangeRouteConstraint(10, 100) }
            );

            // Q6
            routes.MapRoute(
                name: "CatchAll",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Q7
            routes.MapRoute(
                name: "StaticRoute",
                url: "shop/{controller}/{category}/{title}",
                defaults: new
                {
                    action = "index",
                    category = UrlParameter.Optional,
                    title = UrlParameter.Optional
                }
            );

            //routes.MapRoute(
            //    name: "StaticRoute",
            //    url: "shop/{product}/{category}/{title}",
            //    defaults: new { controller = "Product", action = "Search",
            //        product = "books", category = UrlParameter.Optional, title = UrlParameter.Optional }
            //);


            /**
             * Q8
             * Always have the most specific route first in the order
             * 
             */

            /**
             * Q9
             * This method is called from the Global.asax file from the Application_Start() method.
             * It is called at the begining of the application.
             */

            /**
             * Q10
             * 
             * Requires setup in this method: routes.MapMvcAttributeRoutes();
             * Then all actions can have annotations for the route configurations:
             * 
             * [Routes("{controller}/{action}/{id:int}")]
             * public ActionResult Index(int id) {...}
             * 
             */

            // Q11
            routes.MapRoute(
                name: "IdRequired",
                url: "{controller}/{id}",
                defaults: new { controller = "books", action = "Index" }
            );


            /**
             * Q12
             * Convention-based routing:
             *      Pros
             *      
             *      Cons
             * 
             * Attribute routing:
             *      Pros
             *      
             *      Cons
             *      
             */

            /**
             * Q1:
             * Match:
             *      root
             *      root/home
             *      root/home/index
             *      root/home/index/1
             * 
             * No Match: 
             *      root/index
             *      root/1
             *      root/index/home
             *      root/kurt/home
             *      root/home/index/1/kurt
             */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
