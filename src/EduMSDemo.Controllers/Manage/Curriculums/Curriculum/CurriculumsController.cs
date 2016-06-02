using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class CurriculumsController : ValidatedController<ICurriculumValidator, ICurriculumService>
    {
        public CurriculumsController(ICurriculumValidator validator, ICurriculumService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(Service.GetViews());
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return RedirectToAction("Index", "CurriculumDetails", new { curriculumId = id });
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.FacultyId = new SelectList(Service.GetFacultyViews(), "Id", "Name");
            ViewBag.CourseId = new SelectList(Service.GetCourseViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] CurriculumView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.FacultyId = new SelectList(Service.GetFacultyViews(), "Id", "Name", model.FacultyId);
                ViewBag.CourseId = new SelectList(Service.GetCourseViews(), "Id", "Name", model.CourseId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            CurriculumView view = Service.Get<CurriculumView>(id);
            ViewBag.FacultyId = new SelectList(Service.GetFacultyViews(), "Id", "Name", view.FacultyId);
            ViewBag.CourseId = new SelectList(Service.GetCourseViews(), "Id", "Name", view.CourseId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CurriculumView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.FacultyId = new SelectList(Service.GetFacultyViews(), "Id", "Name", model.FacultyId);
                ViewBag.CourseId = new SelectList(Service.GetCourseViews(), "Id", "Name", model.CourseId);
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
