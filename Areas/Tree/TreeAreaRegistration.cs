using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Tree
{
    public class TreeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Tree";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Tree_default",
                "Tree/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}