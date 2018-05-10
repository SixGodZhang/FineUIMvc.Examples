using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridEditor
{
    public class GridEditorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GridEditor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GridEditor_default",
                "GridEditor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}