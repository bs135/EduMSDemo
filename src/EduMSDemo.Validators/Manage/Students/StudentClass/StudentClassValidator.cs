using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Students.StudentClass.StudentClassView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class StudentClassValidator : BaseValidator, IStudentClassValidator
    {
        public StudentClassValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(StudentClassView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueAbbreviation(view.Id, view.Abbreviation);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(StudentClassView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueAbbreviation(view.Id, view.Abbreviation);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<StudentClass>()
                .Any(StudentClass =>
                    StudentClass.Id != id &&
                    StudentClass.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<StudentClassView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }

        private Boolean IsUniqueAbbreviation(Int32 id, String abbreviation)
        {
            Boolean isUnique = !UnitOfWork
                .Select<StudentClass>()
                .Any(StudentClass =>
                    StudentClass.Id != id &&
                    StudentClass.Abbreviation.ToString().ToLower() == abbreviation.ToLower());

            if (!isUnique)
                ModelState.AddModelError<StudentClassView>(StudentClass => StudentClass.Abbreviation, Validations.UniqueAbbreviation);

            return isUnique;
        }

    }
}
