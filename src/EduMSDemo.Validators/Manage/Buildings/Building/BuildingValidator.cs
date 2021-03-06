﻿using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Buildings.Building.BuildingView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class BuildingValidator : BaseValidator, IBuildingValidator
    {
        public BuildingValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(BuildingView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(BuildingView view)
        {
            Boolean isValid = IsUniqueName(view.Id, view.Name);
            isValid &= IsUniqueCode(view.Id, view.Code);
            isValid &= ModelState.IsValid;

            return isValid;
        }

        private Boolean IsUniqueName(Int32 id, String name)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Building>()
                .Any(Building =>
                    Building.Id != id &&
                    Building.Name.ToLower() == name.ToLower());

            if (!isUnique)
                ModelState.AddModelError<BuildingView>(model => model.Name, Validations.UniqueName);

            return isUnique;
        }
        private Boolean IsUniqueCode(Int32 id, String code)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Building>()
                .Any(Building =>
                    Building.Id != id &&
                    Building.Code.ToString().ToLower() == code.ToLower());

            if (!isUnique)
                ModelState.AddModelError<BuildingView>(Building => Building.Code, Validations.UniqueCode);

            return isUnique;
        }

    }
}
