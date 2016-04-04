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
    public class ProductsController : ValidatedController<IProductValidator, IProductService>
    {
        public ProductsController(IProductValidator validator, IProductService service)
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
            ViewBag.ProductGroupId = new SelectList(Service.GetGroupViews(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] ProductView product)
        {
            if (!Validator.CanCreate(product))
                return View(product);

            Service.Create(product);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            ViewBag.ProductGroupId = new SelectList(Service.GetGroupViews(), "Id", "Name");

            return NotEmptyView(Service.Get<ProductView>(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductView product)
        {
            if (!Validator.CanEdit(product))
                return View(product);

            Service.Edit(product);

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
