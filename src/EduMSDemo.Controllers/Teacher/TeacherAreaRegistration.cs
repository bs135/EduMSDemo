using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Teacher
{
    public class TeacherAreaRegistration : AreaRegistration
    {
        public override String AreaName
        {
            get
            {
                return "Teacher";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context
                .MapRoute(
                    "TeacherMultilingual",
                    "{language}/Teacher/{controller}/{action}/{id}",
                    new { area = "Teacher", action = "Index", id = UrlParameter.Optional },
                    new[] { "EduMSDemo.Controllers.Teacher" });

            context
                .MapRoute(
                    "Teacher",
                    "Teacher/{controller}/{action}/{id}",
                    new { language = "en", area = "Teacher", action = "Index", id = UrlParameter.Optional },
                    new { language = "en" },
                    new[] { "EduMSDemo.Controllers.Teacher" });
        }
    }
}
