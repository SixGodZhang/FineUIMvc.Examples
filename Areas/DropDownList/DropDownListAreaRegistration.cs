using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList
{
    public class DropDownListAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DropDownList";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DropDownList_default",
                "DropDownList/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}