using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownBox
{
    public class DropDownBoxAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DropDownBox";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DropDownBox_default",
                "DropDownBox/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}