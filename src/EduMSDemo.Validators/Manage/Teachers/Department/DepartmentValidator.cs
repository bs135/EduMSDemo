using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Teachers.Department.DepartmentView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class DepartmentValidator : BaseValidator, IDepartmentValidator
    {
        public DepartmentValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(DepartmentView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueAbbreviation(view.Id, view.Abbreviation);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(DepartmentView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueAbbreviation(view.Id, view.Abbreviation);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Department>()
                .Any(Department =>
                    Department.Id != id &&
                    Department.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<DepartmentView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }
        private Boolean IsUniqueAbbreviation(Int32 id, String code)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Department>()
                .Any(Department =>
                    Department.Id != id &&
                    Department.Abbreviation.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<DepartmentView>(Department => Department.Abbreviation, Validations.UniqueAbbreviation);

            return isUnique;
        }

    }
}
