using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Curriculums.CurriculumDetail.CurriculumDetailView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class CurriculumDetailValidator : BaseValidator, ICurriculumDetailValidator
    {
        public CurriculumDetailValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CurriculumDetailView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(CurriculumDetailView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }

    }
}
