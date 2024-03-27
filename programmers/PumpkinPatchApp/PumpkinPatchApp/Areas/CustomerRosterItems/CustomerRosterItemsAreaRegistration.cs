using System.Web.Mvc;

namespace PumpkinPatchApp.Areas.CustomerRosterItems
{
    public class CustomerRosterItemsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CustomerRosterItems";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CustomerRosterItems_default",
                "CustomerRosterItems/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}