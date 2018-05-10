using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Panel
{
    public class PanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Panel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Panel_default",
                "Panel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}