using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IStaffValidator : IValidator
    {
        Boolean CanCreate(StaffView view);
        Boolean CanEdit(StaffView view);
    }
}
