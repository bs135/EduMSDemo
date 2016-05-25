using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Students.Student.StudentView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class StudentValidator : BaseValidator, IStudentValidator
    {
        private IHasher Hasher { get; set; }
        private IAccountValidator AAccountValidator { get; set; }
        public StudentValidator(IUnitOfWork unitOfWork, IHasher hasher)
            : base(unitOfWork)
        {
            Hasher = hasher;
            AAccountValidator = new AccountValidator(unitOfWork, hasher);
        }

        public Boolean CanCreate(StudentCreateView view)
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
        public Boolean CanEdit(StudentEditView view)
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
                .Select<Student>()
                .Any(Student =>
                    Student.Id != id &&
                    Student.Code.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<StudentView>(Student => Student.Code, Validations.UniqueCode);

            return isUnique;
        }

    }
}
