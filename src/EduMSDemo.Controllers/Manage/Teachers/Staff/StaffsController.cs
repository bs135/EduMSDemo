using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class StaffsController : ValidatedController<IStaffValidator, IStaffService>
    {
        public StaffsController(IStaffValidator validator, IStaffService service)
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
            ViewBag.DepartmentId = new SelectList(Service.GetDepartmentViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] StaffCreateView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.DepartmentId = new SelectList(Service.GetDepartmentViews(), "Id", "Name", model.DepartmentId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            StaffEditView view = Service.GetEditView(id);

            ViewBag.DepartmentId = new SelectList(Service.GetDepartmentViews(), "Id", "Name", view.DepartmentId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffEditView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.DepartmentId = new SelectList(Service.GetDepartmentViews(), "Id", "Name", model.DepartmentId);
                return View(model);
            }

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
