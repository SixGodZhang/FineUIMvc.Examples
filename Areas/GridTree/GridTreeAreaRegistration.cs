using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridTree
{
    public class GridTreeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GridTree";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GridTree_default",
                "GridTree/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}