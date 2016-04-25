using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Subjects.Subject.SubjectView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class SubjectValidator : BaseValidator, ISubjectValidator
    {
        public SubjectValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SubjectView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(SubjectView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Subject>()
                .Any(Subject =>
                    Subject.Id != id &&
                    Subject.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<SubjectView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }
        private Boolean IsUniqueCode(Int32 id, String code)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Subject>()
                .Any(Subject =>
                    Subject.Id != id &&
                    Subject.Code.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<SubjectView>(Subject => Subject.Code, Validations.UniqueCode);

            return isUnique;
        }

    }
}
