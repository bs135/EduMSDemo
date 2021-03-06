﻿using EduMSDemo.Components.Mvc;
using EduMSDemo.Objects;
using EduMSDemo.Services;
using EduMSDemo.Validators;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Controllers.Manage
{
    [Area("Manage")]
    public class CoursesController : ValidatedController<ICourseValidator, ICourseService>
    {
        public CoursesController(ICourseValidator validator, ICourseService service)
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
            ViewBag.FacultyId = new SelectList(Service.GetFacultyViews(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] CourseView model)
        {
            if (!Validator.CanCreate(model))
            {
                ViewBag.FacultyId = new SelectList(Service.GetFacultyViews(), "Id", "Name", model.FacultyId);
                return View(model);
            }

            Service.Create(model);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            CourseView view = Service.Get<CourseView>(id);
            ViewBag.FacultyId = new SelectList(Service.GetFacultyViews(), "Id", "Name", view.FacultyId);
            return NotEmptyView(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseView model)
        {
            if (!Validator.CanEdit(model))
            {
                ViewBag.FacultyId = new SelectList(Service.GetFacultyViews(), "Id", "Name", model.FacultyId);
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
