using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class StudentClassesController : ValidatedController<IStudentClassValidator, IStudentClassService>
    {
        public StudentClassesController(IStudentClassValidator validator, IStudentClassService service)
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
            ViewBag.CourseId = new SelectList(Service.GetCourseViews(), "Id", "Name");
            ViewBag.StaffId = new SelectList(Service.GetStaffViews(), "Id", "Name");
            ViewBag.CurriculumId = new SelectList(Service.GetCurriculumViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] StudentClassView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.CourseId = new SelectList(Service.GetCourseViews(), "Id", "Name", model.CourseId);
                ViewBag.StaffId = new SelectList(Service.GetStaffViews(), "Id", "Name", model.StaffId);
                ViewBag.CurriculumId = new SelectList(Service.GetCurriculumViews(), "Id", "Name", model.CurriculumId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            StudentClassView view = Service.Get<StudentClassView>(id);
            ViewBag.CourseId = new SelectList(Service.GetCourseViews(), "Id", "Name", view.CourseId);
            ViewBag.StaffId = new SelectList(Service.GetStaffViews(), "Id", "Name", view.StaffId);
            ViewBag.CurriculumId = new SelectList(Service.GetCurriculumViews(), "Id", "Name", view.CurriculumId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentClassView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.CourseId = new SelectList(Service.GetCourseViews(), "Id", "Name", model.CourseId);
                ViewBag.StaffId = new SelectList(Service.GetStaffViews(), "Id", "Name", model.StaffId);
                ViewBag.CurriculumId = new SelectList(Service.GetCurriculumViews(), "Id", "Name", model.CurriculumId);
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
