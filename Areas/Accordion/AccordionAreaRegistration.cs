using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Accordion
{
    public class AccordionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Accordion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Accordion_default",
                "Accordion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}