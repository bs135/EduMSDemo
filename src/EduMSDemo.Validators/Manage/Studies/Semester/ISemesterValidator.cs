using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ISemesterValidator : IValidator
    {
        Boolean CanCreate(SemesterView view);
        Boolean CanEdit(SemesterView view);
    }
}
