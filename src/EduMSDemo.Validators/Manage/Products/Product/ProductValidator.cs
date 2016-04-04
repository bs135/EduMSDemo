using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Products.Product.ProductView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class ProductValidator : BaseValidator, IProductValidator
    {
        public ProductValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueSKU(view.Id, view.SKU);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(ProductView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueSKU(view.Id, view.SKU);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 productID, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Product>()
                .Any(product =>
                    product.Id != productID &&
                    product.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<ProductView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }
        private Boolean IsUniqueSKU(Int32 productID, String sku)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Product>()
                .Any(product =>
                    product.Id != productID &&
                    product.SKU.ToString().ToLower() == sku.ToLower());

            if (!isUnique)
                ModelState.AddModelError<ProductView>(product => product.SKU, Validations.UniqueSKU);

            return isUnique;
        }

    }
}
