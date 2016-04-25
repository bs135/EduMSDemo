using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Scores.ScoreRecord.ScoreRecordView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class ScoreRecordValidator : BaseValidator, IScoreRecordValidator
    {
        public ScoreRecordValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ScoreRecordView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(ScoreRecordView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }

    }
}
