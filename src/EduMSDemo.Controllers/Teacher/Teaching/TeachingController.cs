using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Teacher
{
    [Area("Teacher")]
    public class TeachingController : ValidatedController<IStaffValidator, IStaffService>
    {
        public TeachingController(IStaffValidator validator, IStaffService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

    }
}
