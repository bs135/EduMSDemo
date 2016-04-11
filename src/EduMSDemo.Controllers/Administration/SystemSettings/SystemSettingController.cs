using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Administration
{
    [Area("Administration")]
    public class SystemSettingsController : ValidatedController<ISystemSettingValidator, ISystemSettingService>
    {
        public SystemSettingsController(ISystemSettingValidator validator, ISystemSettingService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(Service.GetViews());
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] SystemSettingView systemSetting)
        {
            if (!Validator.CanCreate(systemSetting))
                return View(systemSetting);

            Service.Create(systemSetting);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<SystemSettingView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<SystemSettingView>(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SystemSettingView systemSetting)
        {
            if (!Validator.CanEdit(systemSetting))
                return View(systemSetting);

            Service.Edit(systemSetting);

            return RedirectIfAuthorized("Index");
        }

        [HttpPost]
        public RedirectToRouteResult Delete(Int32 id)
        {
            Service.Delete(id);

            return RedirectIfAuthorized("Index");
        }
    }
}
