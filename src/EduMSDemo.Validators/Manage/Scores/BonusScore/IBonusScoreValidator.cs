using EduMSDemo.Objects;
using System;

namespace EduMSDemo.Validators
{
    public interface IBonusScoreValidator : IValidator
    {
        Boolean CanCreate(BonusScoreView view);
        Boolean CanEdit(BonusScoreView view);
    }
}
