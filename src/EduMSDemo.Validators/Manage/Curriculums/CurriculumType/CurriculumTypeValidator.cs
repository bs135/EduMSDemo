using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Curriculums.CurriculumType.CurriculumTypeView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class CurriculumTypeValidator : BaseValidator, ICurriculumTypeValidator
    {
        public CurriculumTypeValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CurriculumTypeView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(CurriculumTypeView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<CurriculumType>()
                .Any(CurriculumType =>
                    CurriculumType.Id != id &&
                    CurriculumType.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<CurriculumTypeView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }

    }
}
