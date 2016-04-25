using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ICurriculumDetailValidator : IValidator
    {
        Boolean CanCreate(CurriculumDetailView view);
        Boolean CanEdit(CurriculumDetailView view);
    }
}
