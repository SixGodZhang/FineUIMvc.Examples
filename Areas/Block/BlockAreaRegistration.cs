using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Block
{
    public class BlockAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Block";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Block_default",
                "Block/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}