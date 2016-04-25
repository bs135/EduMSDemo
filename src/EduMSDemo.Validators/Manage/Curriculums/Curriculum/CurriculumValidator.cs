using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Curriculums.Curriculum.CurriculumView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class CurriculumValidator : BaseValidator, ICurriculumValidator
    {
        public CurriculumValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CurriculumView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(CurriculumView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Curriculum>()
                .Any(Curriculum =>
                    Curriculum.Id != id &&
                    Curriculum.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<CurriculumView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }

    }
}
