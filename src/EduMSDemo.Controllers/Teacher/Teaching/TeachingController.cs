using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Teacher
{
    [Area("Teacher")]
    public class TeachingController : ValidatedController<ITeachingValidator, ITeachingService>
    {
        public TeachingController(ITeachingValidator validator, ITeachingService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ViewResult Index()
        {
            Semester currentSemester = Service.GetCurrentSemester();
            StaffView teacherView = Service.GetCurrentTeacher(User);
            ViewBag.CurrentSemester = currentSemester;
            ViewBag.StudentView = teacherView;

            if (currentSemester != null && teacherView != null)
                return View(Service.GetSubjectClassViews(teacherView.Id, currentSemester.Id));

            return View();
        }

        public ActionResult Details(Int32 id)
        {
            Semester currentSemester = Service.GetCurrentSemester();
            //StaffView teacherView = Service.GetCurrentTeacher(User);
            SubjectClassView subjectClassView = Service.GetSubjectClassView(id);
            ViewBag.CurrentSemester = currentSemester;
            //ViewBag.TeacherView = teacherView;
            ViewBag.SubjectClassView = subjectClassView;

            return View(Service.GetScoreRecordViews(id));
        }

        [HttpGet]
        public ActionResult UpdateScore(Int32 id)
        {

            Semester currentSemester = Service.GetCurrentSemester();
            ViewBag.CurrentSemester = currentSemester;

            ScoreRecordView scoreRecordView = Service.GetScoreRecordView(id);
            ViewBag.ScoreRecordView = scoreRecordView;

            UpdateScoreView model = new UpdateScoreView();
            model.MidTermScore = scoreRecordView.MidTermScore;
            model.TermScore = scoreRecordView.TermScore;
            model.FinalScore = scoreRecordView.FinalScore;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateScore(UpdateScoreView model)
        {

            Semester currentSemester = Service.GetCurrentSemester();
            ViewBag.CurrentSemester = currentSemester;

            ScoreRecordView scoreRecordView = Service.GetScoreRecordView(model.Id);
            ViewBag.ScoreRecordView = scoreRecordView;

            if (ModelState.IsValid)
            {
                Service.UpdateScoreRecord(model);
                return RedirectToAction("Details", new { id = Service.GetSubjectClassId(model) });
            }

            return View(model);
        }


    }
}
