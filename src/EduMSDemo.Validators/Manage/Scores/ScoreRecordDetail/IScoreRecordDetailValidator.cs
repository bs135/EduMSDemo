using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IScoreRecordDetailValidator : IValidator
    {
        Boolean CanCreate(ScoreRecordDetailView view);
        Boolean CanEdit(ScoreRecordDetailView view);
    }
}
