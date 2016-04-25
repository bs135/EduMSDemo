using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Studies.SubjectClass.SubjectClassView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class SubjectClassValidator : BaseValidator, ISubjectClassValidator
    {
        public SubjectClassValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SubjectClassView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(SubjectClassView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }

    }
}
