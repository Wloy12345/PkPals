using System.Web.Mvc;

namespace PumpkinPatchApp.Areas.SupplyCategoryItems
{
    public class SupplyCategoryItemsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SupplyCategoryItems";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SupplyCategoryItems_default",
                "SupplyCategoryItems/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}