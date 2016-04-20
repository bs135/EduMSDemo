using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IBuildingValidator : IValidator
    {
        Boolean CanCreate(BuildingView view);
        Boolean CanEdit(BuildingView view);
    }
}
