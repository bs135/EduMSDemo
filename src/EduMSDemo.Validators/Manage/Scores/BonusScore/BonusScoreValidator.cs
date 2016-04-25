using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Scores.BonusScore.BonusScoreView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class BonusScoreValidator : BaseValidator, IBonusScoreValidator
    {
        public BonusScoreValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(BonusScoreView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(BonusScoreView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }

    }
}
