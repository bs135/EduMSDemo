using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ICurriculumTypeValidator : IValidator
    {
        Boolean CanCreate(CurriculumTypeView view);
        Boolean CanEdit(CurriculumTypeView view);
    }
}
