using EduMSDemo.Components.Mvc;
using EduMSDemo.Components.Security;
using EduMSDemo.Data.Core;
using EduMSDemo.Objects;
using EduMSDemo.Resources.Views.Manage.Scores.ScoreRecordDetail.ScoreRecordDetailView;
using System;
using System.Linq;

namespace EduMSDemo.Validators
{
    public class ScoreRecordDetailValidator : BaseValidator, IScoreRecordDetailValidator
    {
        public ScoreRecordDetailValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ScoreRecordDetailView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }
        public Boolean CanEdit(ScoreRecordDetailView view)
        {
            Boolean isValid = ModelState.IsValid;

            return isValid;
        }

    }
}
