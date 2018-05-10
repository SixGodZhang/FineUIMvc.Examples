using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Window
{
    public class WindowAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Window";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Window_default",
                "Window/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}