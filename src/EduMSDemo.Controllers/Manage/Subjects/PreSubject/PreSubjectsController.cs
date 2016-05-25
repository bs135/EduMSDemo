using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class PreSubjectsController : ValidatedController<IPreSubjectValidator, IPreSubjectService>
    {
        public PreSubjectsController(IPreSubjectValidator validator, IPreSubjectService service)
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
            ViewBag.PreOfSubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name");
            ViewBag.SubjectOfPreId = new SelectList(Service.GetSubjectViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] PreSubjectView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.PreOfSubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", model.PreOfSubjectId);
                ViewBag.SubjectOfPreId = new SelectList(Service.GetSubjectViews(), "Id", "Name", model.SubjectOfPreId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            PreSubjectView view = Service.Get<PreSubjectView>(id);
            ViewBag.PreOfSubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", view.PreOfSubjectId);
            ViewBag.SubjectOfPreId = new SelectList(Service.GetSubjectViews(), "Id", "Name", view.SubjectOfPreId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PreSubjectView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.PreOfSubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", model.PreOfSubjectId);
                ViewBag.SubjectOfPreId = new SelectList(Service.GetSubjectViews(), "Id", "Name", model.SubjectOfPreId);
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
