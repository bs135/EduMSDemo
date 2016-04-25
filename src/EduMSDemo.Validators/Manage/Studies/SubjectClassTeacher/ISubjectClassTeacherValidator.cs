using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ISubjectClassTeacherValidator : IValidator
    {
        Boolean CanCreate(SubjectClassTeacherView view);
        Boolean CanEdit(SubjectClassTeacherView view);
    }
}
