using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Student
{
    [Area("Student")]
    public class SubjectRegisterController : ValidatedController<IStaffValidator, IStaffService>
    {
        public SubjectRegisterController(IStaffValidator validator, IStaffService service)
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
