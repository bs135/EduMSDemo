using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IPreSubjectValidator : IValidator
    {
        Boolean CanCreate(PreSubjectView view);
        Boolean CanEdit(PreSubjectView view);
    }
}
