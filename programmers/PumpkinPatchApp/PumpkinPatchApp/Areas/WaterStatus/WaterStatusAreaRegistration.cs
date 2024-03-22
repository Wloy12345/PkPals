using System.Web.Mvc;

namespace PumpkinPatchApp.Areas.WaterStatus
{
    public class WaterStatusAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WaterStatus";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WaterStatus_default",
                "WaterStatus/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}