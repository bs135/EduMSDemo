using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;
using System.Linq;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class CurriculumDetailsController : ValidatedController<ICurriculumDetailValidator, ICurriculumDetailService>
    {
        public CurriculumDetailsController(ICurriculumDetailValidator validator, ICurriculumDetailService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ViewResult Index(int curriculumId = 0)
        {
            ViewBag.CurriculumName = "--All--";
            CurriculumView curr = Service.GetCurriculumViews().FirstOrDefault(o => o.Id == curriculumId);
            if (curr != null)
                ViewBag.CurriculumName = curr.Name;
            return View(Service.GetViews(curriculumId));
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.SubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name");
            ViewBag.CurriculumTypeId = new SelectList(Service.GetCurriculumTypeViews(), "Id", "Name");
            ViewBag.CurriculumId = new SelectList(Service.GetCurriculumViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] CurriculumDetailView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.SubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", model.SubjectId);
                ViewBag.CurriculumTypeId = new SelectList(Service.GetCurriculumTypeViews(), "Id", "Name", model.CurriculumTypeId);
                ViewBag.CurriculumId = new SelectList(Service.GetCurriculumViews(), "Id", "Name", model.CurriculumId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            CurriculumDetailView view = Service.Get<CurriculumDetailView>(id);
            ViewBag.SubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", view.SubjectId);
            ViewBag.CurriculumTypeId = new SelectList(Service.GetCurriculumTypeViews(), "Id", "Name", view.CurriculumTypeId);
            ViewBag.CurriculumId = new SelectList(Service.GetCurriculumViews(), "Id", "Name", view.CurriculumId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CurriculumDetailView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.SubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", model.SubjectId);
                ViewBag.CurriculumTypeId = new SelectList(Service.GetCurriculumTypeViews(), "Id", "Name", model.CurriculumTypeId);
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
