using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.FormLayout
{
    public class FormLayoutAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FormLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FormLayout_default",
                "FormLayout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}