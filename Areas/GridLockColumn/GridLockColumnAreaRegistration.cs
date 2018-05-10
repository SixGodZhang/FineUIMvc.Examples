using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridLockColumn
{
    public class GridLockColumnAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GridLockColumn";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GridLockColumn_default",
                "GridLockColumn/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}