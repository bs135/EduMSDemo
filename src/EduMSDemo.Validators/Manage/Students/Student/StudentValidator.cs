using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Students.Student.StudentView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class StudentValidator : BaseValidator, IStudentValidator
    {
        public StudentValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(StudentView view)
        {
            Boolean isValid = IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(StudentView view)
        {
            Boolean isValid = IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueCode(Int32 id, String code)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Student>()
                .Any(Student =>
                    Student.Id != id &&
                    Student.Code.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<StudentView>(Student => Student.Code, Validations.UniqueCode);

            return isUnique;
        }

    }
}
