using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    public class ManageAreaRegistration : AreaRegistration
    {
        public override String AreaName
        {
            get
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context
                .MapRoute(
                    "ManageMultilingual",
                    "{language}/Manage/{controller}/{action}/{id}",
                    new { area = "Manage", action = "Index", id = UrlParameter.Optional },
                    new[] { "EduMSDemo.Controllers.Manage" });

            context
                .MapRoute(
                    "Manage",
                    "Manage/{controller}/{action}/{id}",
                    new { language = "en", area = "Manage", action = "Index", id = UrlParameter.Optional },
                    new { language = "en" },
                    new[] { "EduMSDemo.Controllers.Manage" });
        }
    }
}
