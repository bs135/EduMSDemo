using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class CurriculumTypesController : ValidatedController<ICurriculumTypeValidator, ICurriculumTypeService>
    {
        public CurriculumTypesController(ICurriculumTypeValidator validator, ICurriculumTypeService service)
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
        public ActionResult Create([Bind(Exclude = "Id")] CurriculumTypeView model)
        {
            if (!Validator.CanCreate(model))
                return View(model);

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            CurriculumTypeView view = Service.Get<CurriculumTypeView>(id);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CurriculumTypeView model)
        {
            if (!Validator.CanEdit(model))
                return View(model);

            Service.Edit(model);

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
