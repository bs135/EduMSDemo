using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ISystemSettingValidator : IValidator
    {
        Boolean CanCreate(SystemSettingView view);
        Boolean CanEdit(SystemSettingView view);
    }
}
