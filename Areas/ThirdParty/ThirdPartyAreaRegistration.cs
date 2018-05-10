using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.ThirdParty
{
    public class ThirdPartyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ThirdParty";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ThirdParty_default",
                "ThirdParty/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}