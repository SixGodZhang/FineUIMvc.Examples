using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.TabStrip
{
    public class TabStripAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TabStrip";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TabStrip_default",
                "TabStrip/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}