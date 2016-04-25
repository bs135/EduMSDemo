using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ISubjectClassValidator : IValidator
    {
        Boolean CanCreate(SubjectClassView view);
        Boolean CanEdit(SubjectClassView view);
    }
}
