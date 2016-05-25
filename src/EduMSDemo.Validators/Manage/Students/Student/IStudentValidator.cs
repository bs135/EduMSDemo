using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IStudentValidator : IValidator
    {
        Boolean CanCreate(StudentCreateView view);
        Boolean CanEdit(StudentEditView view);
    }
}
