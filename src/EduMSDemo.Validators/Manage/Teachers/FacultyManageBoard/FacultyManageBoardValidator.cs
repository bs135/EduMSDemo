using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Teachers.FacultyManageBoard.FacultyManageBoardView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class FacultyManageBoardValidator : BaseValidator, IFacultyManageBoardValidator
    {
        public FacultyManageBoardValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(FacultyManageBoardView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(FacultyManageBoardView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }

    }
}
