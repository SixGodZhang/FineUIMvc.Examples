using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridInput
{
    public class GridInputAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GridInput";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GridInput_default",
                "GridInput/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}