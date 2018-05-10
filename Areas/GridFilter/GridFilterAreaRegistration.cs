using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridFilter
{
    public class GridFilterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GridFilter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GridFilter_default",
                "GridFilter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}