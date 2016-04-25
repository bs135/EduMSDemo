using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IStudentClassValidator : IValidator
    {
        Boolean CanCreate(StudentClassView view);
        Boolean CanEdit(StudentClassView view);
    }
}
