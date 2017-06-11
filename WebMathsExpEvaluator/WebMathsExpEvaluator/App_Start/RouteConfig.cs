using System.Web.Mvc;

namespace WebMathsExpEvaluator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            string[] array = new string[1];
            array[0] = "WebMathsExpEvaluator";
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces :array);
        }
    }
}
