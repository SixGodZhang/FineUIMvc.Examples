using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridPaging
{
    public class GridPagingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GridPaging";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GridPaging_default",
                "GridPaging/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}