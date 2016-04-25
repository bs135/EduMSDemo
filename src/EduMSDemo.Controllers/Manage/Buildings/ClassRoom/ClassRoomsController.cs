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
    public class ClassRoomsController : ValidatedController<IClassRoomValidator, IClassRoomService>
    {
        public ClassRoomsController(IClassRoomValidator validator, IClassRoomService service)
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
            ViewBag.BuildingId = new SelectList(Service.GetBuildingViews(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] ClassRoomView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.BuildingId = new SelectList(Service.GetBuildingViews(), "Id", "Name", model.BuildingId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            ClassRoomView view = Service.Get<ClassRoomView>(id);
            ViewBag.BuildingId = new SelectList(Service.GetBuildingViews(), "Id", "Name", view.BuildingId);

            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassRoomView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.BuildingId = new SelectList(Service.GetBuildingViews(), "Id", "Name", model.BuildingId);
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
