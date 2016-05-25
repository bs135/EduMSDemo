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
        private IHasher Hasher { get; set; }
        private IAccountValidator AAccountValidator { get; set; }
        public StaffValidator(IUnitOfWork unitOfWork, IHasher hasher)
            : base(unitOfWork)
        {
            Hasher = hasher;
            AAccountValidator = new AccountValidator(unitOfWork, hasher);
        }

        public Boolean CanCreate(StaffCreateView view)
        {
            AccountCreateView accView = UnitOfWork.To<AccountCreateView>(view);
            Boolean isValid = AAccountValidator.CanCreate(accView);
            foreach (var item in AAccountValidator.ModelState)
            {
                ModelState.Add(item);
            }

            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(StaffEditView view)
        {
            AccountEditView accView = UnitOfWork.To<AccountEditView>(view);
            Boolean isValid = AAccountValidator.CanEdit(accView);
            foreach (var item in AAccountValidator.ModelState)
            {
                ModelState.Add(item);
            }

            isValid = IsUniqueCode(view.Id, view.Code);
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
