using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IDepartmentValidator : IValidator
    {
        Boolean CanCreate(DepartmentView view);
        Boolean CanEdit(DepartmentView view);
    }
}
