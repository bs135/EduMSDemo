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
    public class ScoreRecordsController : ValidatedController<IScoreRecordValidator, IScoreRecordService>
    {
        public ScoreRecordsController(IScoreRecordValidator validator, IScoreRecordService service)
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
            ViewBag.SubjectClassId = new SelectList(Service.GetStudentViews(), "Id", "Name");
            ViewBag.SubjectId = new SelectList(Service.GetStudentViews(), "Id", "Name");
            ViewBag.StudentId = new SelectList(Service.GetStudentViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] ScoreRecordView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.SubjectClassId = new SelectList(Service.GetStudentViews(), "Id", "Name", model.SubjectClassId);
                ViewBag.SubjectId = new SelectList(Service.GetStudentViews(), "Id", "Name", model.SubjectId);
                ViewBag.StudentId = new SelectList(Service.GetStudentViews(), "Id", "Name", model.StudentId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            ScoreRecordView view = Service.Get<ScoreRecordView>(id);
            ViewBag.SubjectClassId = new SelectList(Service.GetStudentViews(), "Id", "Name", view.SubjectClassId);
            ViewBag.SubjectId = new SelectList(Service.GetStudentViews(), "Id", "Name", view.SubjectId);
            ViewBag.StudentId = new SelectList(Service.GetStudentViews(), "Id", "Name", view.StudentId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoreRecordView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.SubjectClassId = new SelectList(Service.GetStudentViews(), "Id", "Name", model.SubjectClassId);
                ViewBag.SubjectId = new SelectList(Service.GetStudentViews(), "Id", "Name", model.SubjectId);
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
