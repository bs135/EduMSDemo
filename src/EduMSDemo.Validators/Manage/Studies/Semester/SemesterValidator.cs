using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Studies.Semester.SemesterView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class SemesterValidator : BaseValidator, ISemesterValidator
    {
        public SemesterValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SemesterView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(SemesterView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Semester>()
                .Any(Semester =>
                    Semester.Id != id &&
                    Semester.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<SemesterView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }

    }
}
