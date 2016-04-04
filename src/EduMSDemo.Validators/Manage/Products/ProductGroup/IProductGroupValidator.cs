using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IProductGroupValidator : IValidator
    {
        Boolean CanCreate(ProductGroupView view);
        Boolean CanEdit(ProductGroupView view);
    }
}
