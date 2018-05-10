using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DataModel
{
    public class DataModelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DataModel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DataModel_default",
                "DataModel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}