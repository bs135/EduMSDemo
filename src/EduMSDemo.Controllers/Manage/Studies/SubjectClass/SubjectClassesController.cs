using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class SubjectClassesController : ValidatedController<ISubjectClassValidator, ISubjectClassService>
    {
        public SubjectClassesController(ISubjectClassValidator validator, ISubjectClassService service)
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
            ViewBag.RoomOfMidtermExamId = new SelectList(Service.GetClassRoomViews(), "Id", "Name");
            ViewBag.RoomOfTermExamId = new SelectList(Service.GetClassRoomViews(), "Id", "Name");
            ViewBag.RoomOfClassId = new SelectList(Service.GetClassRoomViews(), "Id", "Name");
            ViewBag.SemesterId = new SelectList(Service.GetSemesterViews(), "Id", "Name");
            ViewBag.SubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] SubjectClassView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.RoomOfMidtermExamId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", model.RoomOfMidtermExamId);
                ViewBag.RoomOfTermExamId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", model.RoomOfTermExamId);
                ViewBag.RoomOfClassId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", model.RoomOfClassId);
                ViewBag.SemesterId = new SelectList(Service.GetSemesterViews(), "Id", "Name", model.SemesterId);
                ViewBag.SubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", model.SubjectId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            SubjectClassView view = Service.Get<SubjectClassView>(id);
            ViewBag.RoomOfMidtermExamId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", view.RoomOfMidtermExamId);
            ViewBag.RoomOfTermExamId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", view.RoomOfTermExamId);
            ViewBag.RoomOfClassId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", view.RoomOfClassId);
            ViewBag.SemesterId = new SelectList(Service.GetSemesterViews(), "Id", "Name", view.SemesterId);
            ViewBag.SubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", view.SubjectId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectClassView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.RoomOfMidtermExamId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", model.RoomOfMidtermExamId);
                ViewBag.RoomOfTermExamId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", model.RoomOfTermExamId);
                ViewBag.RoomOfClassId = new SelectList(Service.GetClassRoomViews(), "Id", "Name", model.RoomOfClassId);
                ViewBag.SemesterId = new SelectList(Service.GetSemesterViews(), "Id", "Name", model.SemesterId);
                ViewBag.SubjectId = new SelectList(Service.GetSubjectViews(), "Id", "Name", model.SubjectId);
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
