using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Teachers.Staff.StaffView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class StaffValidator : BaseValidator, IStaffValidator
    {
        public StaffValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(StaffView view)
        {
            Boolean isValid = IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(StaffView view)
        {
            Boolean isValid = IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueCode(Int32 id, String code)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Staff>()
                .Any(Staff =>
                    Staff.Id != id &&
                    Staff.Code.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<StaffView>(Staff => Staff.Code, Validations.UniqueCode);

            return isUnique;
        }

    }
}
