using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Subjects.PreSubject.PreSubjectView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class PreSubjectValidator : BaseValidator, IPreSubjectValidator
    {
        public PreSubjectValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(PreSubjectView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(PreSubjectView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }

    }
}
