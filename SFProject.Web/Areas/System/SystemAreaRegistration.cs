using System.Web.Mvc;

namespace SFProject.Web.Areas.Amap
{
    public class SystemAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "System";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "System_default",
                "System/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}