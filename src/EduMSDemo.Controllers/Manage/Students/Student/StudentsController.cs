using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class StudentsController : ValidatedController<IStudentValidator, IStudentService>
    {
        public StudentsController(IStudentValidator validator, IStudentService service)
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
            ViewBag.StudentClassId = new SelectList(Service.GetStudentClassViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] StudentView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.StudentClassId = new SelectList(Service.GetStudentClassViews(), "Id", "Name", model.StudentClassId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            StudentView view = Service.Get<StudentView>(id);
            ViewBag.StudentClassId = new SelectList(Service.GetStudentClassViews(), "Id", "Name", view.StudentClassId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.StudentClassId = new SelectList(Service.GetStudentClassViews(), "Id", "Name", model.StudentClassId);
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
