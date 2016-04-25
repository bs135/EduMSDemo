using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Teachers.Faculty.FacultyView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class FacultyValidator : BaseValidator, IFacultyValidator
    {
        public FacultyValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(FacultyView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueAbbreviation(view.Id, view.Abbreviation);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(FacultyView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueAbbreviation(view.Id, view.Abbreviation);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Faculty>()
                .Any(Faculty =>
                    Faculty.Id != id &&
                    Faculty.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<FacultyView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }
        private Boolean IsUniqueAbbreviation(Int32 id, String code)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Faculty>()
                .Any(Faculty =>
                    Faculty.Id != id &&
                    Faculty.Abbreviation.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<FacultyView>(Faculty => Faculty.Abbreviation, Validations.UniqueAbbreviation);

            return isUnique;
        }

    }
}
