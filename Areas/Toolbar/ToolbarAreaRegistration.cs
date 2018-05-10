using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Toolbar
{
    public class ToolbarAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Toolbar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Toolbar_default",
                "Toolbar/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}