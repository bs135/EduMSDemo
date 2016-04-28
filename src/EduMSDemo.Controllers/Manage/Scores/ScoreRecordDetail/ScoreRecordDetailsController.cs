using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class ScoreRecordDetailsController : ValidatedController<IScoreRecordDetailValidator, IScoreRecordDetailService>
    {
        public ScoreRecordDetailsController(IScoreRecordDetailValidator validator, IScoreRecordDetailService service)
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
            ViewBag.ScoreRecordId = new SelectList(Service.GetScoreRecordViews(), "Id", "RegigterDate");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] ScoreRecordDetailView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.ScoreRecordId = new SelectList(Service.GetScoreRecordViews(), "Id", "RegigterDate", model.ScoreRecordId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            ScoreRecordDetailView view = Service.Get<ScoreRecordDetailView>(id);
            ViewBag.ScoreRecordId = new SelectList(Service.GetScoreRecordViews(), "Id", "RegigterDate", view.ScoreRecordId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoreRecordDetailView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.ScoreRecordId = new SelectList(Service.GetScoreRecordViews(), "Id", "RegigterDate", model.ScoreRecordId);
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
