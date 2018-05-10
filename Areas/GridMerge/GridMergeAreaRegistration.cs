using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridMerge
{
    public class GridMergeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GridMerge";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GridMerge_default",
                "GridMerge/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}