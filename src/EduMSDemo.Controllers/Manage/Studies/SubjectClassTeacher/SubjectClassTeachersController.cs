using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class SubjectClassTeachersController : ValidatedController<ISubjectClassTeacherValidator, ISubjectClassTeacherService>
    {
        public SubjectClassTeachersController(ISubjectClassTeacherValidator validator, ISubjectClassTeacherService service)
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
            ViewBag.StaffId = new SelectList(Service.GetStaffViews(), "Id", "Name");
            ViewBag.SubjectClassId = new SelectList(Service.GetSubjectClassViews(), "Id", "SubjectName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] SubjectClassTeacherView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.StaffId = new SelectList(Service.GetStaffViews(), "Id", "Name", model.StaffId);
                ViewBag.SubjectClassId = new SelectList(Service.GetSubjectClassViews(), "Id", "SubjectName", model.SubjectClassId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            SubjectClassTeacherView view = Service.Get<SubjectClassTeacherView>(id);
            ViewBag.StaffId = new SelectList(Service.GetStaffViews(), "Id", "Name", view.StaffId);
            ViewBag.SubjectClassId = new SelectList(Service.GetSubjectClassViews(), "Id", "SubjectName", view.SubjectClassId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectClassTeacherView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.StaffId = new SelectList(Service.GetStaffViews(), "Id", "Name", model.StaffId);
                ViewBag.SubjectClassId = new SelectList(Service.GetSubjectClassViews(), "Id", "SubjectName", model.SubjectClassId);
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
