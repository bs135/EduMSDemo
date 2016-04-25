using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IBonusScoreService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<BonusScoreView> GetViews();

        IQueryable<StudentView> GetStudentViews();
        void Create(BonusScoreView view);
        void Edit(BonusScoreView view);
        void Delete(Int32 id);

    }
}
