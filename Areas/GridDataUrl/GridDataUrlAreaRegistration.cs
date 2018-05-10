using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridDataUrl
{
    public class GridDataUrlAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GridDataUrl";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GridDataUrl_default",
                "GridDataUrl/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}