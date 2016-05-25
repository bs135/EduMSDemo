using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class FacultyManageBoardsController : ValidatedController<IFacultyManageBoardValidator, IFacultyManageBoardService>
    {
        public FacultyManageBoardsController(IFacultyManageBoardValidator validator, IFacultyManageBoardService service)
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
            ViewBag.DeanId = new SelectList(Service.GetStaffViews(), "Id", "Name");
            ViewBag.ViceDean1Id = new SelectList(Service.GetStaffViews(), "Id", "Name");
            ViewBag.ViceDean2Id = new SelectList(Service.GetStaffViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] FacultyManageBoardView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.DeanId = new SelectList(Service.GetStaffViews(), "Id", "Name", model.DeanId);
                ViewBag.ViceDean1Id = new SelectList(Service.GetStaffViews(), "Id", "Name", model.ViceDean1Id);
                ViewBag.ViceDean2Id = new SelectList(Service.GetStaffViews(), "Id", "Name", model.ViceDean2Id);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            FacultyManageBoardView view = Service.Get<FacultyManageBoardView>(id);
            ViewBag.DeanId = new SelectList(Service.GetStaffViews(), "Id", "Name", view.DeanId);
            ViewBag.ViceDean1Id = new SelectList(Service.GetStaffViews(), "Id", "Name", view.ViceDean1Id);
            ViewBag.ViceDean2Id = new SelectList(Service.GetStaffViews(), "Id", "Name", view.ViceDean2Id);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacultyManageBoardView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.DeanId = new SelectList(Service.GetStaffViews(), "Id", "Name", model.DeanId);
                ViewBag.ViceDean1Id = new SelectList(Service.GetStaffViews(), "Id", "Name", model.ViceDean1Id);
                ViewBag.ViceDean2Id = new SelectList(Service.GetStaffViews(), "Id", "Name", model.ViceDean2Id);
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
