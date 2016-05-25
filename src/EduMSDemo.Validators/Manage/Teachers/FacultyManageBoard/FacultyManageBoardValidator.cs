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
            isValid &= IsEndAfterStart(view.StartDate, view.EndDate);
            return isValid;
        }
        public Boolean CanEdit(FacultyManageBoardView view)
        {
            Boolean isValid = ModelState.IsValid;
            isValid &= IsEndAfterStart(view.StartDate, view.EndDate);
            return isValid;
        }

        private Boolean IsEndAfterStart(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                ModelState.AddModelError<SemesterView>(model => model.EndDate, Validations.EndAfterStart);

                return false;
            }

            return true;
        }
    }
}
