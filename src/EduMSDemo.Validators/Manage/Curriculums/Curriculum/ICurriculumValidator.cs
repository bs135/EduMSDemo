using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ICurriculumValidator : IValidator
    {
        Boolean CanCreate(CurriculumView view);
        Boolean CanEdit(CurriculumView view);
    }
}
