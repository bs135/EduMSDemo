using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Students.Course.CourseView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class CourseValidator : BaseValidator, ICourseValidator
    {
        public CourseValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CourseView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(CourseView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Course>()
                .Any(Course =>
                    Course.Id != id &&
                    Course.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<CourseView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }

        private Boolean IsUniqueCode(Int32 id, String code)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Course>()
                .Any(Course =>
                    Course.Id != id &&
                    Course.Code.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<CourseView>(Course => Course.Code, Validations.UniqueCode);

            return isUnique;
        }

    }
}
