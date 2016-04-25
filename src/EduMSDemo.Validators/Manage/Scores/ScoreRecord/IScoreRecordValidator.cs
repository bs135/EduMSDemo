using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IScoreRecordValidator : IValidator
    {
        Boolean CanCreate(ScoreRecordView view);
        Boolean CanEdit(ScoreRecordView view);
    }
}
