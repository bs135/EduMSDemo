using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Administration.SystemSettings.SystemSettingView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class SystemSettingValidator : BaseValidator, ISystemSettingValidator
    {
        public SystemSettingValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SystemSettingView view)
        {
            Boolean isValid = IsUniqueKey(view.Id, view.Key);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(SystemSettingView view)
        {
            Boolean isValid = IsUniqueKey(view.Id, view.Key);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueKey(Int32 systemSettingID, String key)
        {
            Boolean isUnique = !UnitOfWork
                .Select<SystemSetting>()
                .Any(systemSetting =>
                    systemSetting.Id != systemSettingID &&
                    systemSetting.Key.ToLower() == key.ToLower());

            if (!isUnique)
                ModelState.AddModelError<SystemSettingView>(model => model.Key, Validations.UniqueKey);

            return isUnique;
        }

    }
}
