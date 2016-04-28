using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class BonusScoresController : ValidatedController<IBonusScoreValidator, IBonusScoreService>
    {
        public BonusScoresController(IBonusScoreValidator validator, IBonusScoreService service)
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
            ViewBag.StudentId = new SelectList(Service.GetStudentViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] BonusScoreView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.StudentId = new SelectList(Service.GetStudentViews(), "Id", "Name", model.StudentId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            BonusScoreView view = Service.Get<BonusScoreView>(id);
            ViewBag.StudentId = new SelectList(Service.GetStudentViews(), "Id", "Name", view.StudentId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BonusScoreView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.StudentId = new SelectList(Service.GetStudentViews(), "Id", "Name", model.StudentId);
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
