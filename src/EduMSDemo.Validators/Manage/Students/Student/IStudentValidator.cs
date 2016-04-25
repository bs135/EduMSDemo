using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IStudentValidator : IValidator
    {
        Boolean CanCreate(StudentView view);
        Boolean CanEdit(StudentView view);
    }
}
