using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Products.ProductGroup.ProductGroupView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class ProductGroupValidator : BaseValidator, IProductGroupValidator
    {
        public ProductGroupValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductGroupView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(ProductGroupView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 productID, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<ProductGroup>()
                .Any(product =>
                    product.Id != productID &&
                    product.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<ProductGroupView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }

    }
}
