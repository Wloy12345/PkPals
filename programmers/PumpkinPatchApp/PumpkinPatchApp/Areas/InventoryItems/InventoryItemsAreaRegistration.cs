using System.Web.Mvc;

namespace PumpkinPatchApp.Areas.InventoryItems
{
    public class InventoryItemsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InventoryItems";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InventoryItems_default",
                "InventoryItems/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}