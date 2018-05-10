using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Commond
{
    public class CommondAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Commond";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Commond_default",
                "Commond/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}