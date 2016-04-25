using EduMSDemo.Objects;
using System;
using System.Linq;
using System.Security.Principal;

namespace EduMSDemo.Services
{
    public interface IScoreRecordDetailService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ScoreRecordDetailView> GetViews();

        IQueryable<ScoreRecordView> GetScoreRecordViews();
        void Create(ScoreRecordDetailView view);
        void Edit(ScoreRecordDetailView view);
        void Delete(Int32 id);

    }
}
