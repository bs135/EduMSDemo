using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ISubjectValidator : IValidator
    {
        Boolean CanCreate(SubjectView view);
        Boolean CanEdit(SubjectView view);
    }
}
