using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IFacultyManageBoardValidator : IValidator
    {
        Boolean CanCreate(FacultyManageBoardView view);
        Boolean CanEdit(FacultyManageBoardView view);
    }
}
