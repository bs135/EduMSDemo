using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IStaffValidator : IValidator
    {
        Boolean CanCreate(StaffCreateView view);
        Boolean CanEdit(StaffEditView view);
    }
}
