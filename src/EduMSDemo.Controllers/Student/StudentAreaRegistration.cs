using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Student
{
    public class StudentAreaRegistration : AreaRegistration
    {
        public override String AreaName
        {
            get
            {
                return "Student";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context
                .MapRoute(
                    "StudentMultilingual",
                    "{language}/Student/{controller}/{action}/{id}",
                    new { area = "Student", action = "Index", id = UrlParameter.Optional },
                    new[] { "EduMSDemo.Controllers.Student" });

            context
                .MapRoute(
                    "Student",
                    "Student/{controller}/{action}/{id}",
                    new { language = "en", area = "Student", action = "Index", id = UrlParameter.Optional },
                    new { language = "en" },
                    new[] { "EduMSDemo.Controllers.Student" });
        }
    }
}
