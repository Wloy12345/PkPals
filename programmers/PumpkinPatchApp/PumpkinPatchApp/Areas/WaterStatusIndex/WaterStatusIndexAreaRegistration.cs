using System.Web.Mvc;

namespace PumpkinPatchApp.Areas.WaterStatusIndex
{
    public class WaterStatusIndexAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WaterStatusIndex";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WaterStatusIndex_default",
                "WaterStatusIndex/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}