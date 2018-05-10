using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Message
{
    public class MessageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Message";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Message_default",
                "Message/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}