using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IClassRoomValidator : IValidator
    {
        Boolean CanCreate(ClassRoomView view);
        Boolean CanEdit(ClassRoomView view);
    }
}
