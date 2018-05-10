using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.FormTable
{
    public class FormTableAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FormTable";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FormTable_default",
                "FormTable/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}