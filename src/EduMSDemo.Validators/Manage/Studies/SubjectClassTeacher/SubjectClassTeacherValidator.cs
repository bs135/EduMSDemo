using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Studies.SubjectClassTeacher.SubjectClassTeacherView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class SubjectClassTeacherValidator : BaseValidator, ISubjectClassTeacherValidator
    {
        public SubjectClassTeacherValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SubjectClassTeacherView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(SubjectClassTeacherView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }

    }
}
