using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Student
{
    [Area("Student")]
    public class SubjectRegisterController : ValidatedController<ISubjectRegisterValidator, ISubjectRegisterService>
    {
        public SubjectRegisterController(ISubjectRegisterValidator validator, ISubjectRegisterService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            Semester currentSemester = Service.GetCurrentSemester();
            StudentView studentView = Service.GetCurrentStudent(User);
            ViewBag.CurrentSemester = currentSemester;
            ViewBag.StudentView = studentView;

            if (currentSemester != null && studentView != null)
                return View(Service.GetScoreRecordViews(studentView.Id, currentSemester.Id));

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            Semester currentSemester = Service.GetCurrentSemester();
            StudentView studentView = Service.GetCurrentStudent(User);
            ViewBag.CurrentSemester = currentSemester;
            ViewBag.StudentView = studentView;

            ViewBag.SubjectClassId = new SelectList(Service.GetSubjectClassViews(User), "Id", "SubjectName");

            return View();
        }

        [HttpPost]
        public ActionResult Register(SubjectRegisterCreateView view)
        {
            Semester currentSemester = Service.GetCurrentSemester();
            StudentView studentView = Service.GetCurrentStudent(User);
            ViewBag.CurrentSemester = currentSemester;
            ViewBag.StudentView = studentView;

            ViewBag.SubjectClassId = new SelectList(Service.GetSubjectClassViews(User), "Id", "SubjectName", view.SubjectClassId);
            if (!ModelState.IsValid)
                return View();

            view.StudentId = studentView.Id;
            Service.AddSubject(view);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToRouteResult Delete(Int32 id)
        {
            Service.Delete(id);

            return RedirectIfAuthorized("Index");
        }


        [HttpGet]
        public ActionResult ScoreBoard()
        {
            //Semester currentSemester = Service.GetCurrentSemester();
            StudentView studentView = Service.GetCurrentStudent(User);
            //ViewBag.CurrentSemester = currentSemester;
            ViewBag.StudentView = studentView;

            if (studentView != null)
                return View(Service.GetScoreBoards(studentView.Id));

            return View();
        }
    }
}
