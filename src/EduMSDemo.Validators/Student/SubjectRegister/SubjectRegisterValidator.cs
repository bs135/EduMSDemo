using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Teachers.Faculty.FacultyView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class SubjectRegisterValidator : BaseValidator, ISubjectRegisterValidator
    {
        public SubjectRegisterValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }


    }
}
