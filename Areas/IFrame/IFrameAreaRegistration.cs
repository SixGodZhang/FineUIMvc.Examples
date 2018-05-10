using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.IFrame
{
    public class IFrameAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IFrame";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IFrame_default",
                "IFrame/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}