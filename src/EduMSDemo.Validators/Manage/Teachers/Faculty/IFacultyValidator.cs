using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IFacultyValidator : IValidator
    {
        Boolean CanCreate(FacultyView view);
        Boolean CanEdit(FacultyView view);
    }
}
