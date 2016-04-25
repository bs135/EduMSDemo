using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface ICourseValidator : IValidator
    {
        Boolean CanCreate(CourseView view);
        Boolean CanEdit(CourseView view);
    }
}
