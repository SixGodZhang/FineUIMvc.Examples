using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Button
{
    public class ButtonAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Button";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Button_default",
                "Button/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}