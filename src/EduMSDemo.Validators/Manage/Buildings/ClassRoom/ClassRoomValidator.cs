using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Buildings.Building.ClassRoomView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class ClassRoomValidator : BaseValidator, IClassRoomValidator
    {
        public ClassRoomValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ClassRoomView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(ClassRoomView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<ClassRoom>()
                .Any(ClassRoom =>
                    ClassRoom.Id != id &&
                    ClassRoom.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<ClassRoomView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }
        private Boolean IsUniqueCode(Int32 id, String code)
        {
            Boolean isUnique = !UnitOfWork
                .Select<ClassRoom>()
                .Any(ClassRoom =>
                    ClassRoom.Id != id &&
                    ClassRoom.Code.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<ClassRoomView>(ClassRoom => ClassRoom.Code, Validations.UniqueCode);

            return isUnique;
        }

    }
}
