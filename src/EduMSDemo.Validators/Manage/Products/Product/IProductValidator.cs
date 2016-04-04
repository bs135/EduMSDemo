using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IProductValidator : IValidator
    {
        Boolean CanCreate(ProductView view);
        Boolean CanEdit(ProductView view);
    }
}
