using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Teachers.Faculty.FacultyView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class TeachingValidator : BaseValidator, ITeachingValidator
    {
        public TeachingValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }


    }
}
